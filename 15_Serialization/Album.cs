using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _15_Serialization
{
    public class Album
    {
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public int YearPublication { get; set; }
        public double Duration { get; set; }
        public string RecordingCompany { get; set; }
        public List<Song> Songs { get; set; }



        public Album(string albumName, string artist, int yearPublication, int duration, string recordingCompany, List<Song> songs)
        {
            AlbumName = albumName;
            Artist = artist;
            YearPublication = yearPublication;
            Duration = duration;
            RecordingCompany = recordingCompany;
            Songs = songs;
        }

        public Album()
            : this("NoName", "NoArtist", 1900, 0, "NoRecordingCompany", new List<Song>())
        { }

        public void Print()
        {
            Console.WriteLine($"Album: {AlbumName} \nArtist: {Artist} \nYear of publication: {YearPublication} \nDuration: {Duration} \nRecording Company: {RecordingCompany}\n\nSongs:\n {String.Join<Song>("\n", Songs)}");
        }


        public void Input()
        {
            Console.Write("Input name of Album: ");
            AlbumName = Console.ReadLine()!;
            Console.Write("Input name of Artist: ");
            Artist = Console.ReadLine()!;
            Console.Write("Input year of publication: ");
            try
            {
                YearPublication = int.Parse(Console.ReadLine()!);
                Duration = double.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect number!");
                Console.ResetColor();
            }
            Console.Write("Input name of Recording Company: ");
            RecordingCompany = Console.ReadLine()!;
            Console.WriteLine("Do you want to add a song?");
            char choice = (char)Console.Read()!;
            if (choice == 'y')
            {
                Console.Write("Input name of song: ");
                string name_song = Console.ReadLine()!;
                Console.Write("Input duration: ");
                double song_duration = 0.00;
                try
                {
                    song_duration = double.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect number");
                    Console.ResetColor();
                }
                Console.Write("Input genre of song: ");
                string genre = Console.ReadLine()!;
                AddSong(new Song(name_song, song_duration, genre));
            }

        }


        public void Serialization(string path)
        {
            string json = JsonSerializer.Serialize<Album>(this);

            File.WriteAllText(path, json);
        }


        static public Album Deserialization(string path)
        {
            Album res = JsonSerializer.Deserialize<Album>(File.ReadAllText(path))!;
            return res;
        }


        public override string ToString()
        {
            return $"Album: {AlbumName} \nArtist: {Artist} \nYear of publication: {YearPublication} \nDuration: {Duration} \nRecording Company: {RecordingCompany} \nSongs:\n {String.Join<Song>("\n", Songs)}";
        }


        // Task 2

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }

        public void PrintSongs()
        {
            Console.WriteLine(String.Join<Song>(",", Songs));
        }
    }
}
