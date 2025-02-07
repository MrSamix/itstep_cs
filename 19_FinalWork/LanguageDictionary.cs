using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _19_FinalWork
{
    public class LanguageDictionary
    {
        public delegate void AutoSaver();
        public event AutoSaver AutoSaveEvent;
        public string Path_File { get; set; }
        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }
        public bool IsAutoSave { get; set; }
        public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>(); // word - List of translations

        public LanguageDictionary(string languageFrom, string languageTo, bool autoSave = false)
        {
            LanguageFrom = languageFrom;
            LanguageTo = languageTo;
            IsAutoSave = autoSave;
            if (autoSave)
            {
                Console.Write("Input a path to file: ");
                Path_File = Console.ReadLine()!;
                if (String.IsNullOrWhiteSpace(Path_File))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Path is empty! Autosave is disabled!");
                    Console.ResetColor();
                    IsAutoSave = false;
                    return;
                }
                AutoSaveEvent += AutoSave;
                if (File.Exists(Path_File))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("This file exists. Import?(y/n): ");
                    Console.ResetColor();
                    string choice = Console.ReadLine()!;
                    if (choice == "y")
                    {
                        string json = File.ReadAllText(Path_File);
                        dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Dictionary imported!");
                        Console.ResetColor();
                    }
                }
            }

        }

        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine($"Language Dictionary({LanguageFrom}-{LanguageTo}): ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Add new word");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[2] Edit word");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[3] Delete word");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[4] Search word");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[5] Show all words");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[6] Import from file");
                Console.WriteLine("[7] Save to file");
                Console.WriteLine("[8] Export word to file");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[9] Add Translation");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[10] Edit Translations");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[11] Remove Translations");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[12] {(IsAutoSave == true ? "Disable" : "Enable")} autosave");
                Console.ResetColor();
                Console.WriteLine("[0] Exit");
                Console.WriteLine("Choice a number: ");
                try
                {
                    int choice = int.Parse(Console.ReadLine()!);
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddWord();
                            break;
                        case 2:
                            Console.Clear();
                            EditWord();
                            break;
                        case 3:
                            Console.Clear();
                            RemoveWord();
                            break;
                        case 4:
                            Console.Clear();
                            SearchWord();
                            break;
                        case 5:
                            Console.Clear();
                            ShowAllWords();
                            break;
                        case 6:
                            Console.Clear();
                            ImportFromFile();
                            break;
                        case 7:
                            Console.Clear();
                            ExportToFile();
                            break;
                        case 8:
                            Console.Clear();
                            ExportWord();
                            break;
                        case 9:
                            Console.Clear();
                            AddTranslation();
                            break;
                        case 10:
                            Console.Clear();
                            EditTranslations();
                            break;
                        case 11:
                            Console.Clear();
                            RemoveTranslation();
                            break;
                        case 12:
                            Console.Clear();
                            ChangeAutoSave();
                            break;
                        case 0:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Exiting...");
                            Console.ResetColor();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid number! Please try again!");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
            
        }

        public void AddTranslation()
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Enter a new translation: ");
            string translation = Console.ReadLine()!;
            if (dictionary[word].Contains(translation))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This translation already exists");
                Console.ResetColor();
                return;
            }
            dictionary[word].Add(translation);
            Console.WriteLine("Translation added!");
        }

        public void AddWord()
        {
            Console.Write("Enter a new word: ");
            string word = Console.ReadLine();
            if (dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word already exists in the dictionary");
                Console.ResetColor();
                return;
            }
            dictionary.Add(word, new List<string>());
            Console.WriteLine("Enter a new translations(tranlation1, translation2...)");
            string[] translations = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.TrimEntries).Where(word=>!String.IsNullOrWhiteSpace(word)).ToArray();
            foreach (var translation in translations)
            {
                dictionary[word].Add(translation);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Word added!");
            Console.ResetColor();
            AutoSaveEvent?.Invoke();
        }
        
        public void PrintWord(string word)
        {
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            Console.WriteLine(word + " - " + string.Join(", ", dictionary[word]));
        }


        public void EditWord()
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            PrintWord(word);
            while (true)
            {
                Console.WriteLine("[1] Change translations to word");
                Console.WriteLine("[2] Change word");
                Console.WriteLine("[0] Return to menu");
                Console.Write("Enter a number: ");
                try
                {
                    int choice = int.Parse(Console.ReadLine()!);
                    switch (choice)
                    {
                        case 1:
                            EditTranslations(word);
                            break;
                        case 2:
                            Console.WriteLine("Enter a new word: ");
                            string newWord = Console.ReadLine()!;
                            dictionary.Add(newWord, dictionary[word]);
                            dictionary.Remove(word);
                            Console.WriteLine("Word edited!");
                            AutoSaveEvent?.Invoke();
                            break;
                        case 0:
                            Console.Clear();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid number! Please try again!");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }


        public void RemoveWord()
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            dictionary.Remove(word);
            Console.WriteLine("Word removed!");
            AutoSaveEvent?.Invoke();
        }

        public void RemoveWord(string word)
        {
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            dictionary.Remove(word);
            Console.WriteLine("Word removed!");
            AutoSaveEvent?.Invoke();
        }


        public void RemoveTranslation()
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.Clear();
                return;
            }
            if (dictionary[word].Count() <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word have only one translation. You don't remove it!");
                Console.ResetColor();
                return;
            }
            Console.WriteLine($"Translations of word {word}: ");
            int counter = 0;
            foreach (var translation in dictionary[word])
            {
                Console.WriteLine($"[{counter}] {translation}");
                counter++;
            }
            Console.WriteLine("Enter a number of translation to remove: ");
            try
            {
                int index = int.Parse(Console.ReadLine()!);
                if (index < counter && index >= 0)
                {
                    dictionary[word].RemoveAt(index);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Translation removed!");
                    Console.ResetColor();
                    AutoSaveEvent?.Invoke();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void SearchWord()
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            PrintWord(word);
        }

        public void ShowAllWords()
        {
            if (dictionary.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dictionary is empty!");
                Console.ResetColor();
                return;
            }
            foreach (var word in dictionary)
            {
                PrintWord(word.Key);
            }
        }

        public void ImportFromFile()
        {
            if (String.IsNullOrWhiteSpace(Path_File))
            {
                Console.WriteLine("Enter a path to file: ");
                Path_File = Console.ReadLine()!;

                if (!File.Exists(Path_File))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File doesn't exist!");
                    Console.ResetColor();
                    return;
                }
                string json = File.ReadAllText(Path_File);
                dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dictionary imported!");
                Console.ResetColor();
            }
        }

        public void ExportToFile()
        {
            if (String.IsNullOrWhiteSpace(Path_File))
            {
                Console.WriteLine("Enter a path to file: ");
                Path_File = Console.ReadLine()!;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Export to {Path_File}?(y/n): ");
                string choice = Console.ReadLine()!;
                if (choice == "n")
                {
                    Console.Write("Enter a path to file, this path will be set by default: ");
                    Console.ResetColor();
                    Path_File = Console.ReadLine()!;
                }
            }
            string json = JsonSerializer.Serialize<Dictionary<string, List<string>>>(dictionary);
            File.WriteAllText(Path_File, json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dictionary exported!");
            Console.ResetColor();
        }

        public void ExportWord(string word, string path)
        {
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            File.WriteAllText(path, $"{word} - {string.Join(", ", dictionary[word])}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Word exported!");
            Console.ResetColor();
        }

        public void ExportWord()
        {
            ShowAllWords();
            Console.Write("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter a path to file: ");
            string path = Console.ReadLine()!;
            File.WriteAllText(path, $"{word} - {string.Join(", ", dictionary[word])}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Word exported!");
            Console.ResetColor();
        }



        public void EditTranslations(string word)
        {
            Console.WriteLine("Enter new translations: ");
            string[] translations = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.TrimEntries).Where(word => !String.IsNullOrWhiteSpace(word)).ToArray();
            dictionary[word].Clear();
            foreach (var translation in translations)
            {
                dictionary[word].Add(translation);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Word edited!");
            Console.ResetColor();
            AutoSaveEvent?.Invoke();
        }

        public void EditTranslations()
        {
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine()!;
            if (!dictionary.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word does not exist in the dictionary");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Enter new translations: ");
            string[] translations = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.TrimEntries).Where(word => !String.IsNullOrWhiteSpace(word)).ToArray();
            dictionary[word].Clear();
            foreach (var translation in translations)
            {
                dictionary[word].Add(translation);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Word edited!");
            Console.ResetColor();
            AutoSaveEvent?.Invoke();
        }

        private void AutoSave()
        {
            string json = JsonSerializer.Serialize<Dictionary<string, List<string>>>(dictionary);
            File.WriteAllText(Path_File, json);
        }

        public void ChangeAutoSave()
        {
            if (!IsAutoSave)
            {
                if (String.IsNullOrWhiteSpace(Path_File))
                {
                    Console.Write("Path to file is empty. Please enter a path to file: ");
                    Path_File = Console.ReadLine()!;
                    if (String.IsNullOrWhiteSpace(Path_File))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Path is empty! Autosave is disabled!");
                        Console.ResetColor();
                        return;
                    }
                }
                AutoSaveEvent += AutoSave;
                IsAutoSave = true;
                AutoSaveEvent?.Invoke();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Autosave enabled!");
                Console.ResetColor();
            }
            else
            {
                IsAutoSave = false;
                AutoSaveEvent -= AutoSave;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Autosave disabled!");
                Console.ResetColor();
            }
        }

    }
}
