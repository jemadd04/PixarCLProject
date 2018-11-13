﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PixarTheater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fun Pixar logo opening window
            Console.WriteLine("\t----------Welcome to PIXAR THEATER-----------");
            Console.WriteLine("\t                   ____________          ");
            Console.WriteLine("\t                  /            \\         ");
            Console.WriteLine("\t                  |             |        ");
            Console.WriteLine("\t               ___|             |        ");
            Console.WriteLine("\t              /  /               \\       ");
            Console.WriteLine("\t             /  /                 \\      ");
            Console.WriteLine("\t            /|  |__________________|     ");
            Console.WriteLine("\t           / |                           ");
            Console.WriteLine("\t          / /                            ");
            Console.WriteLine("\t         / /                             ");
            Console.WriteLine("\t        / /                              ");
            Console.WriteLine("\t       / /                               ");
            Console.WriteLine("\t      | |                                ");
            Console.WriteLine("\t      | |                                ");
            Console.WriteLine("\t      | |                                ");
            Console.WriteLine("\t      | |                                ");
            Console.WriteLine("\t      | |            ________            ");
            Console.WriteLine("\t      | |           /        \\           ");
            Console.WriteLine("\t      | |          |          |          ");
            Console.WriteLine("\t   ___| |___       |          |          ");
            Console.WriteLine("\t  /         \\      \\          /          ");
            Console.WriteLine("\t |___________|      \\________/           ");

            Console.Write(Environment.NewLine);

            //Prompts user for name
            Console.Write("\tPlease type your name and press <Enter> to continue: ");
            var userName = Console.ReadLine();
            // Validation - ensures name is typed in
            while (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("\tName can't be empty. Please enter your name.");
                userName = Console.ReadLine();
            }

            Console.Clear();

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "PixarMovies.csv");
            var fileContents = ReadMovieList(fileName);
            fileName = Path.Combine(directory.FullName, "PixarMovies.json");
            var movies = DeserializeMovies(fileName);

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Title);
            }

            Console.Write(Environment.NewLine);
            // Prompts user to enter desired movie to watch and logged into variable selectedMovie
            Console.Write($"Welcome {userName}! Please choose a movie to watch from the list above: ");
            Console.Write(Environment.NewLine);

            //bool nullAnswer = true;
            //while (nullAnswer)
            //{
                var selectedMovie = Console.ReadLine();
                Console.Write(Environment.NewLine);

                var movieAnswer = movies.FirstOrDefault(r => string.Equals(r.Title, selectedMovie, StringComparison.InvariantCultureIgnoreCase));
                if (movieAnswer == null)
                {
                    Console.WriteLine("That is an invalid option. Please select a movie from the list.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(userName + ", you have chosen to watch " + movieAnswer.Title + ". This movie came out in " + movieAnswer.Year + " and grossed " + movieAnswer.BoxOfficeGross + " at the box office!");
                    Console.WriteLine("Also, it ended up with a Rotten Tomatoes Score of " + movieAnswer.RTScore + "%.");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("We hope you enjoy your movie " + userName + " and please come back to visit soon. Enjoy the show!");
                    Console.WriteLine("Press <Enter> to enter the theater");

                }



                Console.ReadLine();
                Console.Write(Environment.NewLine);

            //}


            // Clear screen 
            Console.Clear();

            // While loop is here so that if one of the options are chosen they can easily go back to the main menu by hitting enter unless otherwise noted with a break
            while (true)
            {
                Console.WriteLine("\tWelcome " + userName);
                Console.Write(Environment.NewLine);
                Console.WriteLine("\t1. View List of Pixar Movies");
                Console.WriteLine("\t2. Display List of Pixar Movies Sorted by Box Office Gross");
                Console.WriteLine("\t3. Display List of Pixar Movies Sorted by Rotten Tomatoes Score");
                Console.WriteLine("\t4. Display Previous Pixar Movie That Was Watched");
                Console.Write(Environment.NewLine);
                Console.WriteLine("\t5. Quit");

                Console.Write(Environment.NewLine);

                // Prompt for menu selection and logged in getOption string
                Console.Write("\tPlease choose a menu item below: ");
                string getOption = Console.ReadLine();
                Console.Clear();

                //If clause as opposed to switch 
                if (int.TryParse(getOption, out int option))
                {
                    // Option 1- Display all Pixar movies and choose one to watch
                    if (option == 1)
                    {

                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.Title);
                        }

                        Console.Write(Environment.NewLine);
                        Console.ReadLine();
                        Console.Clear();

                    }
                    //Option 2 - Lists all Pixar movies by box office gross, highest to lowest
                    else if (option == 2)
                    {
                        GetBoxOfficeGross();
                    }
                    //Option 3 - Lists all Pixar movies by Rotten Tomatoes score, highest to lowest
                    else if (option == 3)
                    {
                        GetRTScoreData();
                    }
                    //Option 4 - Displays saved data that is written to file
                    else if (option == 4)
                    {
                        Console.WriteLine("Here is a list of recent theater visitors:");
                        const string path = "guestbook.txt";
                        if (!File.Exists(path))
                        {
                            string createText = "No recent visitors." + Environment.NewLine;
                            File.WriteAllText(path, createText);
                            Console.WriteLine(createText);
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine($"{userName} watched {selectedMovie} at the theater");
                            }
                            try
                            {
                                using (StreamReader sr = new StreamReader(path, true))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        Console.WriteLine(line);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("The file could not be read:");
                                Console.WriteLine(e.Message);
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    //Exits the program
                    else if (option == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("That is not a valid option. Please choose between options 1 through 5.");
                    }
                }
            } //end of While loop
        } //end of Main

        //Methods
        public static List<MovieData> ReadMovieList(string fileName)
        {
            var movieList = new List<MovieData>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine(); // throw away header line
                while((line = reader.ReadLine()) != null)
                {
                    var movieData = new MovieData();
                    string[] values = line.Split(',');
                    movieData.Title = values[0];
                    int parseInt;
                    if (int.TryParse(values[1], out parseInt))
                    {
                        movieData.Year = parseInt;
                    }
                    if (int.TryParse(values[2], out parseInt))
                    {
                        movieData.RTScore = parseInt;
                    }
                    if (int.TryParse(values[3], out parseInt))
                    {
                        movieData.BoxOfficeGross = parseInt;
                    }
                    movieList.Add(movieData);
                }
            }
            return movieList;
        } //End of ReadMovieList()

        public static List<MovieData> DeserializeMovies(string fileName)
        {
            var movies = new List<MovieData>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                movies = serializer.Deserialize<List<MovieData>>(jsonReader);
            }
                
            return movies;
        } //End of DeserializeMovies()

        //public static void SerializeMoviesToFile(List<MovieData> movies, string fileName)
        //{
        //    var serializer = new JsonSerializer();
        //    using (var writer = new StreamWriter(fileName))
        //    using (var jsonWriter = new JsonTextWriter(writer))
        //    {
        //        serializer.Serialize(jsonWriter, movies);
        //    }
        //}

        static void GetBoxOfficeGross()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "PixarMovies.csv");
            var fileContents = ReadMovieList(fileName);
            fileName = Path.Combine(directory.FullName, "PixarMovies.json");
            var movies = DeserializeMovies(fileName);

            var topGrossingMovies = GetTopGrossing(movies);
            foreach (var movie in topGrossingMovies)
            {
                Console.WriteLine(movie.Title + " | Box Office Gross: {0:C2}", movie.BoxOfficeGross);
            }

            Console.ReadLine();
            Console.WriteLine("Please press <Enter> to return to the Main Menu");

            Console.Clear();
        } //End of GetBoxOfficeGross()

        static void GetRTScoreData()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "PixarMovies.csv");
            var fileContents = ReadMovieList(fileName);
            fileName = Path.Combine(directory.FullName, "PixarMovies.json");
            var movies = DeserializeMovies(fileName);

            var topScoreMovies = GetTopScore(movies);
            foreach (var movie in topScoreMovies)
            {
                Console.WriteLine(movie.Title + " | Rotten Tomatoes Score: " + movie.RTScore);
            }

            Console.ReadLine();
            Console.WriteLine("Please press <Enter> to return to the Main Menu");

            Console.Clear();
        } //End of GetRTScoreData()

        public static List<MovieData> GetTopGrossing(List<MovieData> movies)
        {
            var topGrossingMovies = new List<MovieData>();
            movies.Sort(new MovieComparer());
            int counter = 0;
            foreach(var movie in movies)
            {
                topGrossingMovies.Add(movie);
                counter++;
                if (counter == 20)
                    break;
            }
            return topGrossingMovies;
        }

        public static List<MovieData> GetTopScore(List<MovieData> movies)
        {
            var topScoreMovies = new List<MovieData>();
            movies.Sort(new ScoreComparer());
            int counter = 0;
            foreach (var movie in movies)
            {
                topScoreMovies.Add(movie);
                counter++;
                if (counter == 20)
                    break;
            }
            return topScoreMovies;
        } // End of GetTopGrossing()

    }
}


//// PROJECT GUIDELINES
////1. Does project read from a dataset?
////2. Does project have a class that models at least some of the data?
////3. Does the above class have at least two instances, representing two seperate pieces of data?
////4. Does project write to a database or file?
////5. Is the user able to view or manipulate the data in any manner?
////6. Does the project have comments?
////7. Does the project have a README file on Github?