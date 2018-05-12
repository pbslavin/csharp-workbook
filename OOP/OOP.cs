using System;
using System.Collections.Generic;

namespace OOP
{
					
    public class Program
    {
        public static void Main()
        {
            Person person1 = new Person("Nancy");
            Person person2 = new Person("Joan");
            Person person3 = new Person("Quentin");
            Person person4 = new Person("Pedro");
            Person person5 = new Person("Olene");
            Person person6 = new Person("Ric");
            Person person7 = new Person("Gary");
            List<Person> people1 = new List<Person>()
            { 
                person1,
                person2,
                person3
            };
            List<Person> people2 = new List<Person>()
            { 
                person4,
                person5,
            };
            List<Person> people3 = new List<Person>()
            { 
                person6,
                person7,
            };
            Car blueCar = new Car("blue", 5, people1);
            Console.WriteLine(blueCar.PeopleReport());
            blueCar.PutPeopleInCar(people2); 
            blueCar.PeopleReport();
            Car greyCar = new Car("grey", 2, people3);
            Garage smallGarage = new Garage(2);
            smallGarage.ParkCar(blueCar, 0);
            smallGarage.ParkCar(greyCar, 1);
            Console.WriteLine(smallGarage.Cars);
            Console.WriteLine("");
        }
    }

    class Car
    {
        private List<Person> people;
        
        public Car(string initialColor, int size, List<Person> initialPeople)
        {
            Color = initialColor;
            Size = size;
            People = initialPeople;
        }
        
        public string Color { get; private set; }

        public List<Person> People 
        { 
            get {
                return people;
            }
            set {
                people = value;
            }
        }


        public int Size { get; private set; }

        public string PeopleReport()
        {
            string driverAndPassengers = $"\nPeople in {Color} car: ";
            for (int i = 0; i < People.Count; i ++)
            {
                if (people[i] != null)
                {
                    driverAndPassengers += People[i].Name;
                    if (i < people.Count - 1 && People[i + 1] != null)
                    {
                        driverAndPassengers += ", ";
                    }
                }
            }
            return driverAndPassengers;
        }

        public void PutPeopleInCar(List<Person> people)
        {
            for (int i = 0; i < people.Count; i ++)
            {
                if (People.Count < Size)
                {
                    People.Add(people[i]); 
                }
            }
        }
    }

    class Garage
    {
        private Car[] cars;
        
        public Garage(int initialSize)
        {
            Size = initialSize;
            this.cars = new Car[initialSize];
        }
        
        public int Size { get; private set; }
        
        public void ParkCar (Car car, int spot)
        {
            cars[spot] = car;
        }
        
        public string Cars {
            get 
            {
                string report = "";
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i] != null) 
                    {
                        report += String.Format("\nThe {0} car is in spot {1}", cars[i].Color, i);
                        if (cars[i].People != null)
                        {
                            report += cars[i].PeopleReport();
                        }
                    }
                }
                return report;
            }
        }
    }

    class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}





// using System;

// namespace OOP
// {
//     class Program
//     {
//         static void Main()
//         {
//             Garage smallGarage = new Garage(2);
//             Car car1 = new Car("Toyota", "white");
//             Car car2 = new Car("Honda", "silver");
//             Car car3 = new Car("Volvo", "aqua");

//             Car[] parkedCars = new Car[] {car2, car3};
//             int[] spots = new int[] {0, 1};
//             Person person1 = new Person("Nancy");
//             Person person2 = new Person("Pedro");
//             Person person3 = new Person("Quentin");
//             Person[] peopleInCar = new Person[] { person2, person3, person1 };

//             smallGarage.ParkCars(parkedCars, spots);
//             Console.WriteLine(smallGarage.Cars);
//             car1.PutPeopleInCar(peopleInCar);
//             Console.WriteLine(car1.PeopleReport);
            // foreach (var person in car1.people)
            // {
            //     if (person != null)
            //     {
            //         Console.Write($"{person.Name}, ");
            //     }
            // }
            // Console.WriteLine("and no one else.");
//             Console.WriteLine("");
//         }
            
//     }

//     class Person
//     {
//         public Person(string name)
//         {
//             Name = name;
//         }

//         public string Name { get; private set; }
//     }
//     class Car
//     {
//         public Car(string model, string initialColor)
//         {
//             Model = model;
//             Color = initialColor;
//             Person[] people = People;
//         }

//         public string Model { get; private set;}

//         public string Color { get; private set; }

//         public Person[] People { get; set; }

//         public string PeopleReport {
//             get
//             {
//                 string driverAndPassengers = "People in car: ";
//                 for (int i = 0; i < People.Length; i ++)
//                 {
//                     if (People[i] != null)
//                     {
//                         driverAndPassengers += People[i];
//                         if (i < People.Length - 1 && People[i + 1] != null)
//                         {
//                             driverAndPassengers += ", ";
//                         }
//                     }
//                 }
//                 return driverAndPassengers;
//             }
//             private set
//             {

//             }
//         }

//         public void PutPeopleInCar(Person[] peopleInCar)
//         {
//             for (int i = 0; i < peopleInCar.Length; i ++)
//             {
//                 if (peopleInCar[i] != null)
//                     {
//                         People[i] = peopleInCar[i]; 
//                     }
//             }
//             // return $"People in car: {peopleInCar.Length}";
//         }
//     }
//     class Garage
//     {
//         private Car[] spaces;
//         public Garage(int initialSize)
//         {
//             Size = initialSize;
//             this.spaces = new Car[initialSize];
//             Console.WriteLine(this.spaces.Length);
//         }
//         public int Size { get; private set; }

//         public string Cars 
//         {
//             get
//             {
//                 return $"The car in space 0 is a {spaces[0].Model} and the car in space 1 is a {spaces[1].Model}.";
//             }
//             set
//             {
                
//             }
//         }

//         public void ParkCars(Car[] cars, int[] spots)
//         {
//             for (int i = 0; i < cars.Length; i ++)
//             {
//                 if (cars[i] != null)
//                     {
//                         spaces[spots[i]] = cars[i];
//                     }
//             }

//         }
//     }

// }
