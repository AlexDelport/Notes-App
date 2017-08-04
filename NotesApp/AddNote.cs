using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace NotesApp
{
    [Activity(Label = "Notes - Add", NoHistory = true)]

    public class AddNote: Activity
    {
        ImageView imgSave;  
        EditText txtAddTitle;
        EditText txtAddDetails;

        DatabaseManager objDB = new DatabaseManager();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);                

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.addNote);

            imgSave = FindViewById<ImageView>(Resource.Id.imgSave);
            txtAddTitle = FindViewById<EditText>(Resource.Id.txtAddTitle);
            txtAddDetails = FindViewById<EditText>(Resource.Id.txtAddDetails);

            imgSave.Click += onImgSave_Click;
        }

        private void onImgSave_Click(object sender, EventArgs e)
        {
            if (txtAddTitle.Text != "")
            {
                objDB.AddNote(txtAddTitle.Text, txtAddDetails.Text);
                Toast.MakeText(this, "Note Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Enter a Title", ToastLength.Long).Show();
            }
        }

    }
    
}