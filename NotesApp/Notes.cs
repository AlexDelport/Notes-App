using SQLite;

namespace NotesApp
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement]
        public int NoteID { get; set; }        
        public string NoteTitle { get; set; }
        public string NoteDetails { get; set; }
        public string NoteDate { get; set; }

        public Notes()
        {
        }

    }
}