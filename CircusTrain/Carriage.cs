using System.Collections.Generic;
using System.Linq;

namespace CircusTrain
{
    internal class Carriage
    {
        private List<Animal> Animals { get; }

        public bool AddAnimal(Animal animal)
        {
            if (Animals.Sum(Animal => Animal.Size) + animal.Size <= 10)
            {
                if (AnimalCompatible(animal))
                {
                    Animals.Add(animal);
                    return true;
                }
            }
            return false;
        }

        private bool AnimalCompatible(Animal animal)
        {
            bool containscarnivores = Animals.Where(animal_ => animal.Type == Type.carnivore).Count() > 0;
            if (containscarnivores)
            {
                switch (animal.Type)
                {
                    case Type.carnivore:
                        return false;
                    case Type.herbivore:
                        return EqualOrBiggerCarnivoreCount(animal) == 0;
                }
            }
            else
            {
                switch (animal.Type)
                {
                    case Type.carnivore:
                        return EqualOrSmallerHerbivoreCount(animal) == 0;
                    case Type.herbivore:
                        return true;
                }
            }
            return false;
        }

        private int EqualOrBiggerCarnivoreCount(Animal animal)
        {
            return Animals.Where(animal_ => animal.Type == Type.carnivore).Select(animal_ => animal.Size).ToList()
                            .Where(size => animal.Size <= size).Count();
        }

        private int EqualOrSmallerHerbivoreCount(Animal animal)
        {
            return Animals.Where(animal_ => animal.Type == Type.herbivore).Select(animal_ => animal.Size).ToList()
                .Where(size => animal.Size >= size).Count(); ;
        }
    }
}