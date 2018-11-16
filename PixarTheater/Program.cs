using System;
using System.Linq;
using System.IO;

namespace PixarTheater
{
    class Program
    {
        static void Main(string[] args)
        {

            //this is your actual application.
            var pixar = new PixarTheater.Logic.PixarTheater();

            pixar.Start();

            Console.Clear();

        }

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