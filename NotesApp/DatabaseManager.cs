using System;
using System.IO;
using System.Collections.Generic;

namespace NotesApp
{
    class DatabaseManager
    {
        static string dbName = "Notes.sqlite";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        public DatabaseManager()
        {
        }

        public List<Notes> ViewAllNotes()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "select * from tblNotes";
                    var NoteList = cmd.ExecuteQuery<Notes>();
                    return NoteList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
                return null;
            }
        }

        public List<Notes> SearchAllNotes(string searchnotes)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "select * from tblNotes where NoteTitle like '%" + searchnotes + "%' or NoteDetails like '%" + searchnotes + "%'";                  
                    var NoteList = cmd.ExecuteQuery<Notes>();
                    return NoteList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
                return null;
            }
        }

        public void AddNote (string title, string details)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "insert into tblNotes(NoteTitle, NoteDetails) values('" + title + "','" + details +"')";
                    var NoteList = cmd.ExecuteQuery<Notes>();                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);               
            }
        }

        public void EditNote(string title, string details, int listid)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "update tblNotes set NoteTitle= '" + title + "', NoteDetails= '" + details + "' where NoteID= " + listid;
                    var NoteList = cmd.ExecuteQuery<Notes>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
        }

        public void DeleteNote(int listid)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "delete from tblNotes where NoteID= " + listid;
                    var NoteList = cmd.ExecuteQuery<Notes>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
        }
    }   
}