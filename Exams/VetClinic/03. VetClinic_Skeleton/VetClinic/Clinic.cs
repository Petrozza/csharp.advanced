using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private readonly List<Pet> data;
        //int Count;

        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }

        public List<Pet> Data { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                Data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isExist = Data.Any(x => x.Name == name);

            if (isExist)
            {
                Pet currentPet = Data.FirstOrDefault(x => x.Name == name);
            }
            return isExist;
        }

        public Pet GetPet(string name, string owner)
        {
            bool isExist = Data.Any(x => x.Name == name && x.Owner == owner);

            if (!isExist)
            {
                return null;
            }

            return Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            Pet pet = Data.OrderByDescending(x => x.Age).FirstOrDefault();
            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in Data)
            {
                bb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return bb.ToString().TrimEnd();
        }
    }
}
