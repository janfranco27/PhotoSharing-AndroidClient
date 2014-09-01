using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WS
{
	[Activity (Label = "WS", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			Button bSearch = FindViewById<Button> (Resource.Id.bSearch);
			EditText edTagService = FindViewById<EditText> (Resource.Id.etTagWord);	

			Intent i = new Intent (this, typeof(ResultActivity));

			bSearch.Click  += delegate {

				string sTagService = edTagService.Text;
				Console.WriteLine(sTagService + " tag");

				i.PutExtra("TagService", sTagService);
				StartActivity(i);

			};		

		}
	}
}


