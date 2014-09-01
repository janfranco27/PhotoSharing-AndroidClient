using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using Android.Graphics;

namespace WS
{
	public class ImageAdapter : BaseAdapter
	{
		Context context;
		List<Bitmap> images;

		public ImageAdapter (Context c, List<Bitmap> i)
		{
			context = c;
			images = i;
		}

		public override int Count { get { return images.Count; } }

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			ImageView i = new ImageView (context);
			i.SetImageBitmap (images [position]);
			i.LayoutParameters = new Gallery.LayoutParams (710, 710);
			i.SetScaleType (ImageView.ScaleType.FitXy);

			return i;
		}
	}
}

