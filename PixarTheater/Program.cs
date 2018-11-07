using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixarTheater
{
    class Program
    {
        // Name of the data file
        private static string file;
        private static bool readFile = false;

        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcome to PIXAR THEATER-----------");
            Console.WriteLine("                   ____________          ");
            Console.WriteLine("                  /            \\         ");
            Console.WriteLine("                  |             |        ");
            Console.WriteLine("               ___|             |        ");
            Console.WriteLine("              /  /               \\       ");
            Console.WriteLine("             /  /                 \\      ");
            Console.WriteLine("            /|  |__________________|     ");
            Console.WriteLine("           / |                           ");
            Console.WriteLine("          / /                            ");
            Console.WriteLine("         / /                             ");
            Console.WriteLine("        / /                              ");
            Console.WriteLine("       / /                               ");
            Console.WriteLine("      | |                                ");
            Console.WriteLine("      | |                                ");
            Console.WriteLine("      | |                                ");
            Console.WriteLine("      | |                                ");
            Console.WriteLine("      | |            ________            ");
            Console.WriteLine("      | |           /        \\           ");
            Console.WriteLine("      | |          |          |          ");
            Console.WriteLine("   ___| |___       |          |          ");
            Console.WriteLine("  /         \\      \\          /          ");
            Console.WriteLine(" |___________|      \\________/           ");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("\t          Press enter to continue     ");
            Console.ReadKey();

            // Clear screen 
            Console.Clear();

            Console.WriteLine("Previous visit to P|I|X|A|R Theater");
            string path = "./PixarMovieChoice.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to
                string createText = "You haven't watched a movie at P|I|X|A|R yet." + Environment.NewLine;
                File.WriteAllText(path, createText);
                Console.WriteLine(createText);
            }
            else
            {
                string text = File.ReadAllText("./PixarMovieChoice.txt");
                Console.WriteLine(text);
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("Please choose a menu item below:");
            Console.WriteLine("1. Choose a Pixar Movie");
            Console.WriteLine("2. Display List of Pixar Movies by Box Office Gross");
            Console.WriteLine("3. Display List of Pixar Movies by Rotten Tomatoes Score");
            Console.WriteLine("4. Display Previous Pixar Movie That Was Watched");
            Console.Write(Environment.NewLine);
            Console.WriteLine("5. Quit");
            Console.WriteLine("This is a test");

            Console.ReadLine();
            Console.Write(Environment.NewLine);
            Console.Clear();

            string getOption = Console.ReadLine();
            if (int.TryParse(getOption, out int option))
            {
                if (option == 1)
                {
                    // Display list of Pixar movies from JSON file
                    Console.WriteLine("Please choose which Pixar movie you would like to watch: ");
                    var movieChoice = Console.ReadLine();
                    Console.WriteLine("Success");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Pixar Movies Sorted by Box Office Gross Highest to Lowest");
                    DisplayGross(fileContents);
                }
                else if (option == 3)
                {
                    Console.WriteLine("Pixar Movies Sorted by Rotten Tomatoes Score");
                    DisplayScore(fileContents);
                }
                else if (option == 4)
                {
                    Console.WriteLine("The previous movie watched at Pixar Theater was ");
                }
                else if (option == 5)
                {
                    // Exit program
                }
                else
                {
                    Console.WriteLine("You must select an option between 1 and 4.");
                }
            }
        }
            // End of menu
            // get the filename folders
            public static string getFileName(string fileName)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo directory = new DirectoryInfo(currentDirectory);
                // set path and file name and return it
                return Path.Combine(directory.FullName, file);
            }

        public static void displayFileName()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            string[] entries = Directory.GetFileSystemEntries(directory.FullName, "*.*");
            int number = 1;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].Contains(".txt") || entries[i].Contains(".csv"))
                {
                    Console.WriteLine("\t {0}. " + entries[i], number);
                    number++;
                }
            }
        }

        //read data from file
        public static List<AllPixar> ReadData(string fileName)
        {
            //create a new object using AllPixar class
            var totalGross = new List<AllPixar>();
            // reading data from file
            using (var sr = new StreamReader(fileName))
            {
                //read header line to skip header line
                sr.ReadLine();
                string line;
                //read data
                while ((line=sr.ReadLine()) != null)
                {
                    //instantiate class allpixar
                    var allPixar = new AllPixar();
                }
            }
        }
    }
}
