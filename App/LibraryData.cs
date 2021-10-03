using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksLibrary.App
{
    public static class LibraryData
    {
        public static void Save(string fileName, LibraryModel data )
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(data, options);
            
            File.WriteAllText(fileName+".json", jsonString);
        }
        public static LibraryModel Load(string fileName)
        {          
            if (File.Exists(fileName + ".json"))
            {
                string jsonString = File.ReadAllText(fileName + ".json");
               
                LibraryModel libraryModel = JsonSerializer.Deserialize<LibraryModel>(jsonString);
                return libraryModel;
            }          
            else return new LibraryModel();
        }        
    }
}
