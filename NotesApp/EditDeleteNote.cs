using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace NotesApp
{
    [Activity(Label = "Notes - Edit / Delete", NoHistory =true)]
    public class EditDeleteNote : Activity
    {
        int NoteListId;
        string NoteTitle;
        string NoteDetails;

        EditText txtEditTitle;
        EditText txtEditDetails;
        ImageView imgSave;
        ImageView imgDelete;

        DatabaseManager objDB;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.editDeleteNote);

            txtEditTitle = FindViewById<EditText>(Resource.Id.txtEditTitle);
            txtEditDetails = FindViewById<EditText>(Resource.Id.txtEditDetails);

            imgSave = FindViewById<ImageView>(Resource.Id.imgSave);
            imgDelete = FindViewById<ImageView>(Resource.Id.imgDelete);

            imgSave.Click += OnImgSave_Click;
            imgDelete.Click += OnImgDelete_Click; ;

            NoteListId = Intent.GetIntExtra("ListID", 0);
            NoteDetails = Intent.GetStringExtra("Details");
            NoteTitle = Intent.GetStringExtra("Title");

            txtEditTitle.Text = NoteTitle;
            txtEditDetails.Text = NoteDetails;

            objDB = new DatabaseManager();
        }

        private void OnImgSave_Click(object sender, EventArgs e)
        {            
                try
            {
                if (txtEditTitle.Text != "")
                {
                    objDB.EditNote(txtEditTitle.Text, txtEditDetails.Text, NoteListId);
                    Toast.MakeText(this, "Note Edited", ToastLength.Long).Show();
                    this.Finish();
                    StartActivity(typeof(MainActivity));
                }
                else
                {
                    Toast.MakeText(this, "Enter a Title", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred: " + ex.Message);
            }
        }

        private void OnImgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objDB.DeleteNote(NoteListId);
                Toast.MakeText(this, "Note Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred: " + ex.Message);
            }
        }

    }

}