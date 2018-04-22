using System;

namespace ClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Instantiation
            int points;

            Students student1 = new Students("Kevin");
            student1.HoursStudiedProp = 24;
            Console.WriteLine(student1.ToString());
            points = student1.CalculatePoints(100, 40);
            Console.WriteLine("Points = {0}", points);

            Students student2 = new Students("Chris");
            student2.HoursStudiedProp = 66;
            Console.WriteLine(student2.ToString());
            points = student2.CalculatePoints(50, 30);
            Console.WriteLine("Points = {0}", points);

            Students student3 = new Students("Luke");
            student3.HoursStudiedProp = 98;
            Console.WriteLine(student3.ToString());
            points = student3.CalculatePoints(20, 100);
            Console.WriteLine("Points = {0}", points);

            Students student4 = new Students("Peter");
            student4.HoursStudiedProp = 80;
            Console.WriteLine(student4.ToString());
            points = student4.CalculatePoints(15, 50);
            Console.WriteLine("Points = {0}", points);

            Students student5 = new Students("Renee");
            student5.HoursStudiedProp = 110;
            Console.WriteLine(student5.ToString());
            points = student5.CalculatePoints();
            Console.WriteLine("Points = {0}", points);
        }
    }

    class Students
    {

        //fields
        private string nameOfStudent;
        private const int hourlyPoints = 10;
        private int hoursStudied;

        //properties
        public int HoursStudiedProp
        {
            get
            {
                return hoursStudied;
            }
            set
            {
                if (value > 0)
                    hoursStudied = value;
                else
                    hoursStudied = 0;
            }

        }

        //methods
        public void PrintMessage()
        {
            Console.WriteLine("Calculating study points...");
        }

        public int CalculatePoints()
        {
            PrintMessage();

            int studyPoints;
            studyPoints = hoursStudied * hourlyPoints;

            if (hoursStudied > 0)
            {
                return studyPoints;
            }
            else
            {
                return 0;
            }
        }

        //Used another method with the same name, but its okay because it accepts different parameters. 
        public int CalculatePoints(int bonus, int allowance)
        {
            PrintMessage();
            if (hoursStudied > 0)
                return hoursStudied + hourlyPoints + bonus + allowance;
            else
                return 0;
        }

        //This method returns a string. We're using override to use this method in the way that we want. 
        public override string ToString()
        {
            return "Name of Student = " + nameOfStudent + ", hourlyPoints = " + hourlyPoints + ", hoursStudied = " + hoursStudied;
        }

        //constructors
        public Students(string name)
        {
            nameOfStudent = name;
            Console.WriteLine("\n" + nameOfStudent);
        }

        public Students(string firstName, string lastName)
        {
            nameOfStudent = firstName + " " + lastName;
            Console.WriteLine("\n" + nameOfStudent);
        }
    }
}
