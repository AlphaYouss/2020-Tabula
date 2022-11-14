using System.Collections.Generic;

namespace ClassLibrary
{
    public class Wagon
    {
        private IReadOnlyCollection<Animal> animals = new List<Animal>();

        public void SetAnimals(IReadOnlyCollection<Animal> animals)
        {
            this.animals = animals;
        }

        public IReadOnlyCollection<Animal> GetAnimals()
        {
            return animals;
        }
    }
}