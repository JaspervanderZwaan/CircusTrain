using System.Collections.Generic;

namespace CircusTrain
{
    internal class Train
    {
        private List<Carriage> Carriages { get; }
        public Train() => Carriages.Add(new Carriage());

        public void AddAnimal(Animal animal)
        {
            foreach (Carriage carriage in Carriages)
            {
                if (carriage.AddAnimal(animal))
                {
                    break;
                }
                else
                {
                    Carriages.Add(new Carriage());
                    AddAnimal(animal);
                }
            }
        }
    }
}