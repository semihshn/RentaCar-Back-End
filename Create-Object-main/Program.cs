using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Persons
    {
        //Person object id
        public int id { get; set; }

        //Persons name
        public string name { get; set; }

        //Persons adress
        public string adress { get; set; }

        //Persons age
        public int age { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many persons you want to add?: ");
            int count = int.Parse(Console.ReadLine());

            var newPersons = new System.Collections.Generic.List<Persons>();

			for (int i = 0; i < count; i++)
			{
                newPersons.Add(new Persons());
			}

            for (int i = 0; i < count; i++)
            {
                newPersons[i].id = i;

                Console.Write("Write name for person " + i);
                newPersons[i].name = Console.ReadLine();

                Console.Write("Write age for person " + i);
                newPersons[i].age = int.Parse(Console.ReadLine());

                Console.Write("Write adress for person " + i);
                newPersons[i].adress = Console.ReadLine();

            }

            Console.WriteLine("\nPersons \tName \tAge \tAdress");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\t" + newPersons[i].name + "\t" + newPersons[i].age + "\t" + newPersons[i].adress);
            }

            Console.ReadKey();
        }
    }
}
