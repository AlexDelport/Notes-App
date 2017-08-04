using System.Threading.Tasks;

using Android.App;
using Android.OS;

namespace NotesApp
{
    [Activity(Label = "Notes", MainLauncher=true, NoHistory=true, Icon = "@drawable/notesicon")]
    public class NotesAppSplash : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.notesAppSplash);

            await waitGUI();
        }

        public async Task waitGUI()
        {
            await Task.Delay(4000);
            StartActivity(typeof(MainActivity));
        }
    }
}