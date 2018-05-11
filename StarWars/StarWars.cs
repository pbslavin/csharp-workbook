using System;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Person leia = new Person("Leia", "Organa", "Rebel");
            Person luke = new Person("Luke", "Skywalker", "Alliance");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Person han = new Person("Han", "Solo", "Alliance");
            Person palpatine = new Person("Emperor", "Palpatine", "Imperial");
            Person obiwan = new Person("Obi-wan", "Kenobi", "Alliance");
            Ship falcon = new Ship("Millennium Falcon", "Rebel", "smuggling", 3);
            Ship tie = new Ship("Tie Fighter", "Imperial", "fighter", 1);
            Ship dtie = new Ship("Darth Vader's Tie Fighter", "Imperial", "fighter", 1);
            Ship xwing = new Ship("X-Wing", "Alliance", "fighter", 1);
            xwing.EnterShip(obiwan, 0);
            dtie.EnterShip(darth, 0);
            falcon.EnterShip(han, 0);
            falcon.EnterShip(leia, 1);
            falcon.EnterShip(luke, 2);
            tie.EnterShip(palpatine, 0);
            Ship[] initialDSShips = { tie, dtie };
            Ship[] initialRSShips = { falcon, xwing };
            Station deathStar = new Station("Death Star", "Imperial", 5, initialDSShips);
            Station rebelSpaceStation = new Station("Rebel Space Station", "Alliance", 2, initialRSShips);
            deathStar.Roster();
            rebelSpaceStation.Roster();

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
        internal Person[] passengers;

        public Ship(string name, string type, string alliance, int size)
        {
            this.Name = name;
            this.Type = type;
            this.Alliance = alliance;
            this.passengers = new Person[size];
        }

        public string Name { get; private set; }

        public string Type { get; set; }

        public string Alliance { get; set; }

        public string Passengers 
        {
            get
            {
                string names = "Passenger list: ";
                for (int i = 0; i < passengers.Length; i ++)
                {
                    if (passengers[i] != null)
                    {
                        names += passengers[i].FullName;
                        if (i < passengers.Length - 1 && passengers[i + 1] != null)
                        {
                            names += ", ";
                        }
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

    class Station 
    {
        public Station(string name, string alliance, int capacity, Ship[] ships)
        {
            Name = name;
            Alliance = alliance;
            Capacity = capacity;
            Ships = ships;
        }

        public string Name { get; private set; } 

        public string Alliance { get; private set; }

        public int Capacity { get; private set; }

        public Ship[] Ships { get; private set; }

        public void Roster()
        {
            foreach (Ship ship in Ships)
            {
                Console.WriteLine("");
                Console.Write("Ship: ");
                Console.WriteLine(ship.Name);
                Console.WriteLine(ship.Passengers);
            }
        }
    }
}
