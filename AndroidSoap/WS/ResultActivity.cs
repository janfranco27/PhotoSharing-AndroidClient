
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Android.Graphics;
using System.Net;

namespace WS
{
	[Activity (Label = "ResultActivity")]			
	public class ResultActivity : Activity
	{
		private static String NAMESPACE = "http://WS.PhotoSharing.unsa.com";
		private static String MAIN_REQUEST_URL = "http://192.168.1.34:8080/PhotoSharing/services/WS?wsdl";
		private static String MAIN_URL = "http://192.168.1.34:8080/PhotoSharing/";
		private ProgressDialog progressDialog;
		private String[] results;
		private Gallery gallery;
		private List<Bitmap> images;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.ListImages); 
			String tagService = Intent.GetStringExtra ("TagService");


			gallery = (Gallery)FindViewById <Gallery> (Resource.Id.gallery);
			images = new List<Bitmap> ();

			progressDialog = new ProgressDialog(this) { Indeterminate = true };
			progressDialog.SetTitle("Carga de Datos");
			progressDialog.SetMessage("Wait");

			searchImagesByTag (tagService);
		}

		private void searchImagesByTag (string tagService)
		{
			progressDialog.Show ();
			new Thread(new ThreadStart(() =>
				{
					load(tagService);
					RunOnUiThread(() => progressDialog.Hide());
					RunOnUiThread(() => showAlertMessage());
					RunOnUiThread(() => loadImages());
				})).Start();
		}

		private void load(string tagService)
		{
			var client = new WS.servicio.WS();
			results = client.servicio (tagService);
			foreach (var r in results) 
			{
				images.Add(GetImageBitmapFromUrl(MAIN_URL + r));
			}

		}

		private void showAlertMessage()
		{

			new AlertDialog.Builder(this)
				.SetTitle("Resultado")
				.SetMessage("Se encontraron " + results.Length +" imagenes")
				.Show();
		}
			
		private void loadImages()
		{
			gallery.Adapter = new ImageAdapter (this, images);
			Console.WriteLine (images.Count);
		}
		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}
	}
}

