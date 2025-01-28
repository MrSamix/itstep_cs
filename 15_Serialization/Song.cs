using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Serialization
{
    public class Song
    {
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }

        public Song(string name, double duration, string genre)
        {
            Name = name;
            Duration = duration;
            Genre = genre;
        }

        public Song()
            : this("NoName", 0.00, "NoGenre")
        { }

        public override string ToString()
        {
            return $"Name: {Name,-10} Duration: {Duration,-10} Genre: {Genre,-10}";
        }
    }
}
