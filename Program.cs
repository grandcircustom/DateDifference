using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateDifference
{
    class Program
    {

        private static int[] ConvStringDateToInt(string Input)
        {
            // This method takes a date in the format of a string and returns
            // an integer array with the contents = {Year, Month, Day}
            // More comments
            char[] delimiterChars = { ' ', '/' };
            string[] words = Input.Split(delimiterChars);
            int Year = ConvToIntWithErrorCheck(words[2]); 
            int Month = ConvToIntWithErrorCheck(words[0]);
            int Day = ConvToIntWithErrorCheck(words[1]);
            int[] Test = { Year, Month, Day } ;
            int[] Bad = { 0, 0, 0 };
            if (Year == 0 || Month == 0 || Day == 0)
            {
                return Bad;
            }
            else
            {
                return Test;
            }

        }
    

        private static int ConvToIntWithErrorCheck(string Input)
        {
            // This method converts a string to integer using Convert.ToInteger().
            // It uses System error checking to make sure the input valid.
            // If the input is valid, it returns the input converted to integer.
            // If the input is invalid, it returns a 0  

            var Space = "\n";
            try
            {
                // Verify user input is in correct format 
                int Output = Convert.ToInt32(Input);
                return Output;
            }
            catch (System.OverflowException)
            {
                Console.WriteLine(Space);
                System.Console.WriteLine(
                    "The conversion from string to number overflowed.");
                Console.WriteLine(Space);
                return 0;
            }
            catch (System.FormatException)
            {
                Console.WriteLine(Space);
                System.Console.WriteLine(
                    "The string is not formatted as a number.");
                Console.WriteLine(Space);
                return 0;
            }
            catch (System.ArgumentNullException)
            {
                Console.WriteLine(Space);
                System.Console.WriteLine(
                    "The string is null.");
                Console.WriteLine(Space);
                return 0;
            }

        }

        static void Main(string[] args)
        {
            // Get the two dates from the user.  These are strings.
            Console.WriteLine("This program will give the difference between two dates in days.");
            Console.WriteLine("Please enter the first date in this format Month/Day/Year [Using only numbers]");
            string FirstDateString = Console.ReadLine();
            Console.WriteLine("Please enter the second date in this format Month/Day/Year [Using only numbers]");
            string SecondDateString = Console.ReadLine();

            // Convert the dates to integers to pass to DateTime program
            int[] FirstDateInt = ConvStringDateToInt(FirstDateString);
            int FirstYear = FirstDateInt[0];
            int FirstMonth = FirstDateInt[1];
            int FirstDay = FirstDateInt[2];

            int[] SecondDateInt = ConvStringDateToInt(SecondDateString);
            int SecondYear = SecondDateInt[0];
            int SecondMonth = SecondDateInt[1];
            int SecondDay = SecondDateInt[2];

            // Make sure user didn't enter bad data
            if (FirstDateInt[0] == 0 || SecondDateInt[0] == 0)
            {             
                Console.WriteLine("There are issues with your dates");
                return;
            }

            // Convert dates to numbers
            DateTime oldDate = new DateTime(FirstYear, FirstMonth, FirstDay);
            DateTime newDate = new DateTime(SecondYear, SecondMonth, SecondDay);

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            Console.WriteLine("Difference in days: {0} ", differenceInDays);

        }
    }
}
