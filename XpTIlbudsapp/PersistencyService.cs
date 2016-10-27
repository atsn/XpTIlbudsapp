using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;


namespace XpTIlbudsapp.Persistency
{
    //Json.Net er downloaded til projektet via NuGet: Højreklik på projektet -> Manage NuGet Package

    class PersistencyService
    {
        private static bool hasbeenshown = false;
        private static string JsonFileName = "NotesAsJson.dat";

        public static async Task<string> SaveNotesAsJsonAsync(ObservableCollection<VareMedTilbud> notes)
        {
            string notesJsonString = JsonConvert.SerializeObject(notes);
            string c = await SerializeNotesFileAsync(notesJsonString, JsonFileName);
            return c;
        }

        public static async Task<ObservableCollection<VareMedTilbud>> LoadNotesFromJsonAsync()
        {
            string notesJsonString = await DeserializeNotesFileAsync(JsonFileName);
            if (notesJsonString != null)
                return (ObservableCollection<VareMedTilbud>)JsonConvert.DeserializeObject(notesJsonString, typeof(ObservableCollection<VareMedTilbud>));
            return null;
        }



        private static async Task<string> SerializeNotesFileAsync(string notesJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, notesJsonString);
            string c;
            return c = notesJsonString;
        }


        private static async Task<string> DeserializeNotesFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                if (hasbeenshown == false)
                {
                    MessageDialogHelper.Show("Din inkøbsliste er tom og vil ikke vise nogle vare før du tiæføjer den via vare eller kædesøgning", "Tom Inkøbsliste");
                    hasbeenshown = true;


                }
                return null;


            }
        }


        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }

    }
}
