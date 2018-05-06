using System;

namespace OOP
{
    class Program
    {
        static void Main()
        {
            Garage smallGarage = new Garage(2);
            Car car1 = new Car("Toyota", "white");
            Car car2 = new Car("Honda", "silver");
            Car car3 = new Car("Volvo", "aqua");

            Car[] parkedCars = new Car[] {car2, car3};
            int[] spots = new int[] {0, 1};
            Person person1 = new Person("Nancy");
            Person person2 = new Person("Pedro");
            Person person3 = new Person("Quentin");
            Person[] peopleInCar = new Person[] { person2, person3, person1 };

            smallGarage.ParkCars(parkedCars, spots);
            Console.WriteLine(smallGarage.Cars);
            Console.WriteLine(car1.PutPeopleInCar(peopleInCar));
            Console.WriteLine(person1.Name);
            Console.Write ("In car1 we have ");
            foreach (var person in car1.people)
            {
                if (person != null)
                {
                    Console.Write($"{person.Name}, ");
                }
            }
            Console.WriteLine("and no one else.");
            Console.WriteLine("");
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
    class Car
    {
        public string model;
        public Person[] people = new Person[5];
        public Car(string model, string initialColor)
        {
            this.model = model;
            Color = initialColor;
        }
        public string Color { get; private set; }

        public string PutPeopleInCar(Person[] peopleInCar)
        {
            for (int i = 0; i < peopleInCar.Length; i ++)
            {
                if (peopleInCar[i] != null)
                    {
                        this.people[i] = peopleInCar[i]; 
                    }
            }
            return $"People in car: {peopleInCar.Length}";
        }
    }
    class Garage
    {
        private Car[] spaces;
        public Garage(int initialSize)
        {
            Size = initialSize;
            this.spaces = new Car[initialSize];
            Console.WriteLine(this.spaces.Length);
        }
        public int Size { get; private set; }

        public string Cars 
        {
            get
            {
                return $"The car in space 0 is a {spaces[0].model} and the car in space 1 is a {spaces[1].model}.";
            }
            set
            {
                
            }
        }

        public void ParkCars(Car[] cars, int[] spots)
        {
            for (int i = 0; i < cars.Length; i ++)
            {
                if (cars[i] != null)
                    {
                        spaces[spots[i]] = cars[i];
                    }
            }

        }
    }

}
