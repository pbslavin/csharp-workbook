using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Company
    {
        public string name;
        public List<Warehouse> warehouses;

        public Dictionary<string, List<string[]>> index = 
            new Dictionary<string, List<string[]>>();

        public Company(string name)
        {
            this.name = name;
            this.warehouses = new List<Warehouse>();
        }

        public void Manifest()
        {
            Console.WriteLine("\n" + this.name);
            foreach (Warehouse warehouse in this.warehouses)
            {
                Console.WriteLine($"  {warehouse.location}");
                foreach (Container container in warehouse.containers)
                {
                    Console.WriteLine($"    {container.id}");
                    foreach (Item item in container.items)
                    {
                        Console.WriteLine($"      {item.name}");
                    }
                }
            }
        }
    }

    class Warehouse
    {
        public string location;
        public int size;
        public List<Container> containers;

        public Warehouse(string location, int size)
        {
            this.location = location;
            this.size = size;
            this.containers = new List<Container>();
        }

        public string AddContainer(Container container)
        {
            if (this.containers.Count < this.size)
            {
                this.containers.Add(container);
                return $"Added container {container.id}";
            }
            else
            {
                return "No more room";
            }
        }
    }

    class Container
    {
        public List<Item> items;
        public int size;
        public string id;

        public Container(int size, string id)
        {
            this.size = size;
            this.id = id;
            this.items = new List<Item>();
        }

        public string AddItem(Item item)
        {
            if (this.items.Count < this.size)
            {
                this.items.Add(item);
                return $"Added {item.name}";
            }
            else
            {
                return "No more room";
            }
        }
    }

    class Item
    {
        public string name;
        public double price;
        
        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Company rainforest = new Company("Rainforest LLC");

            string[] cities = new string[] { "Austin", "Houston", "Dallas", "San Antonio" };
            string[] items = new string[] { "Banana", "Toothpaste", "Baseball", "Laptop" };
            string[] items2 = new string[] { "Shovel", "Banana", "TV", "Cat Litter" };
            

            foreach (string city in cities)
            {
                Warehouse warehouse = new Warehouse(city, 2);
                rainforest.warehouses.Add(warehouse);
            }

            for (int i = 0; i < rainforest.warehouses.Count; i ++)
            {
                Warehouse warehouse = rainforest.warehouses[i];
                Container container = new Container(i + 2, $"{warehouse.location}-01");
                Console.WriteLine(rainforest.warehouses[i].AddContainer(container));
            }

            for (int i = 0; i < rainforest.warehouses.Count; i ++)
            {
                Container container = rainforest.warehouses[i].containers[0];
                Item item = new Item(items2[i], i); 
                
                Console.WriteLine(container.AddItem(item));
                if (rainforest.index.ContainsKey(item.name))
                {
                    rainforest.index[item.name].Add(new string[] { container.id, 
                        rainforest.warehouses[i].location });
                }
                else
                {
                    rainforest.index[item.name] = new List<string[]>();
                    rainforest.index[item.name].Add(new string[]
                    { container.id, 
                        rainforest.warehouses[i].location });
                }
            }

            for (int i = 0; i < rainforest.warehouses.Count; i ++)
            {
                Container container = rainforest.warehouses[i].containers[0];
                Item item = new Item(items[i], i); 
                
                Console.WriteLine(container.AddItem(item));
                if (rainforest.index.ContainsKey(item.name))
                {
                    rainforest.index[item.name].Add(new string[] { container.id, 
                        rainforest.warehouses[i].location });
                }
                else
                {
                    rainforest.index[item.name] = new List<string[]>();
                    rainforest.index[item.name].Add(new string[]
                    { container.id, 
                        rainforest.warehouses[i].location });
                }
            }

            rainforest.Manifest();

            string searchItem = "Banana";
            for (int i = 0; i < rainforest.index[searchItem].Count; i ++)
            {
                Console.Write($"\n{searchItem}: ");
                for (int j = 0; j < 2; j ++)
                {
                    Console.WriteLine($"{rainforest.index[searchItem][i][j]}");
                }
            }
            
        }
    }
}
