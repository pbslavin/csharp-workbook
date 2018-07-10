using System;
					
public class Program
{
	public static void Main()
	{
		string name = "";
        string ageString = "";
		int age = 0;
        string yearString = "";
		int year = 0;
		
		Console.WriteLine("Please enter your name: ");
		name = Console.ReadLine();
		Console.WriteLine("Please enter your age: ");
        ageString = Console.ReadLine();
        bool validAge = int.TryParse(ageString, out age);
        while (!validAge)
        {
           Console.WriteLine("Please enter a valid age.");
           ageString = Console.ReadLine();
           validAge = int.TryParse(ageString, out age);
        }
		Console.WriteLine("Please enter the year: ");
        yearString = Console.ReadLine();
        bool validYear = int.TryParse(yearString, out year);
        while (!validYear)
        {
            Console.WriteLine("Please enter a valid year.");
            yearString = Console.ReadLine();
            validYear = int.TryParse(yearString, out year);
        }
		
		Console.WriteLine("Hello! My name is {0} and I am {1} years old. I was born in {2}.", name, age, year-age);
	}
}