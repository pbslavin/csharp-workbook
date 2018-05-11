using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Person leia = new Person("Leia", "Organa", "Rebel");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Ship falcon = new Ship("Rebel", "smuggling", 2);
            Ship tie = new Ship("Imperial", "fighter", 1);
            Console.WriteLine("");

        }
    }

     class Person 
    {
        private string firstName;
        private string lastName;
        private string alliance;
        public Person(string firstName, string lastName, string alliance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.alliance = alliance;
        }

        public string FullName
        {
            get
            {
                return this.firstName + " " + this.lastName;
            }

            set
            {
                string [] names = value.Split(' ');
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }
    }

    class Ship
    {
        private Person[] passengers;

        public Ship(string type, string alliance, int size)
        {
            this.Type = type;
            this.Alliance = alliance;
            this.passengers = new Person[size];
        }

        public string Type { get; set; }

        public string Alliance { get; set; }

        public string Passengers 
        {
            get
            {
                string names = "Passenger list: ";
                foreach (var person in passengers)
                {
                    if (person != null)
                    {
                        names += person.FullName + " ";
                    }
                }
                return names;
                
            }
        }

        public void EnterShip(Person person, int seat)
        {
            this.passengers[seat] = person;
        }

        public void ExitShip(int seat)
        {
            this.passengers[seat] = null;
        }
    }
}
