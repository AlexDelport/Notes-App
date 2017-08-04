using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace NotesApp
{
    class DataAdapter : BaseAdapter<Notes>
    {

        List<Notes> items;

        Activity context;
        public DataAdapter(Activity context, List<Notes> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Notes this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.notesRow, null);
                        
            view.FindViewById<TextView>(Resource.Id.lblTitle).Text = item.NoteTitle;
            view.FindViewById<TextView>(Resource.Id.lblDetails).Text = item.NoteDetails;
            view.FindViewById<TextView>(Resource.Id.lblDate).Text = item.NoteDate;
            return view;
        }

    }

}