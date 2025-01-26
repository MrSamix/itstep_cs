using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace _14_File
{
    internal class Moderator
    {
        public string Text_path { get; set; }
        public string BannedWords_path { get; set; }
        public Moderator(string text_pathfile, string bannedwords_pathfile)
        {
            Text_path = text_pathfile;
            BannedWords_path = bannedwords_pathfile;
        }
        public void CheckText()
        {
            string text, bannedwords;
            try
            {
                text = File.ReadAllText(Text_path);
            }
            catch (Exception) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File \"" + Text_path + "\" not opened! Maybe, you don't create it or enter incorrect path. Please create this file!");
                Console.ResetColor();
                return;
            }
            try
            {
                bannedwords = File.ReadAllText(BannedWords_path);
            }
            catch (Exception) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File \"" + BannedWords_path + "\" not opened! Maybe, you don't create it or enter incorrect path. Please create this file!");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("text: \n" + text);
            Console.WriteLine("Banwords: " + bannedwords);

            string[] banwords = bannedwords.Split(' ');

            foreach (string word in banwords) 
            {
                if (text.Contains(word))
                {
                    text = text.Replace(word, new string('*', word.Length));
                }
            }
            Console.WriteLine("Result text: \n" + text);
        }
    }
}
