using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace NotesApp
{
    [Activity(Label = "Notes", NoHistory =true)]
    public class MainActivity : Activity
    {
        ListView lstNotes;
        List<Notes> myList;
        ImageView imgAdd;
        EditText txtSearchNote;              

        static string dbName = "Notes.sqlite";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
        DatabaseManager objDB;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            lstNotes = FindViewById<ListView>(Resource.Id.lvNotes);
            imgAdd = FindViewById<ImageView>(Resource.Id.imgAdd);
            txtSearchNote = FindViewById<EditText>(Resource.Id.txtSearchNote);            

            CopyDatabase();

            objDB = new DatabaseManager();
            myList = objDB.ViewAllNotes();
            lstNotes.Adapter = new DataAdapter(this, myList);

            imgAdd.Click += OnImgAdd_Click;
            lstNotes.ItemClick += OnLstNotes_ItemClick;
            txtSearchNote.TextChanged += OnTxtSearchNote_TextChanged;          
        }

        private void OnTxtSearchNote_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            myList = objDB.SearchAllNotes(txtSearchNote.Text);
            lstNotes.Adapter = new DataAdapter(this, myList);
        }

        private void OnLstNotes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var notes = myList[e.Position];
            var editNote = new Intent(this, typeof(EditDeleteNote));

            editNote.PutExtra("Title", notes.NoteTitle);
            editNote.PutExtra("Details", notes.NoteDetails);
            editNote.PutExtra("ListID", notes.NoteID);

            StartActivity(editNote);
        }        

        private void OnImgAdd_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddNote));
        }

        public void CopyDatabase()
        {
            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) >0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
         }

        protected override void OnResume()
        {
            base.OnResume();
            objDB = new DatabaseManager();
            myList = objDB.ViewAllNotes();
            lstNotes.Adapter = new DataAdapter(this, myList);
        }

    }      
}

