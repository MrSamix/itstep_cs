using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _15_Serialization
{
    public class AlbumList
    {
        public List<Album> Albums { get; set; }

        public AlbumList(string path)
        {
            Albums = new List<Album>();
            DeserializeFromFile(path);
        }

        public AlbumList()
        {
            Albums = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album);
        }


        public void Print()
        {
            int counter = 0;
            foreach (Album album in Albums)
            {
                Console.WriteLine($"Album #{counter++} \n{album}");
                Console.WriteLine();
            }
        }

        public void SerializeToFile(string path)
        {
            string json = JsonSerializer.Serialize<List<Album>>(Albums);
            try
            {
                File.WriteAllText(path, json);
                Console.WriteLine("Saved to " + path);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error! Message: {e.Message}");
                Console.ResetColor();
            }
        }

        public void DeserializeFromFile(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<List<Album>>(json);
                if (res == null)
                {
                    throw new Exception("File is empty! Not imported!");
                }
                else
                {
                    Albums = new List<Album>(res);
                    Console.WriteLine("DONE!");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error! Message: {e.Message}");
                Console.ResetColor();
            }
        }
    }
}
