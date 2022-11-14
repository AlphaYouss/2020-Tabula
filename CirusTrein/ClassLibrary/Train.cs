using System.Linq;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Train
    {
        private IReadOnlyCollection<Wagon> wagons { get; set; } = new List<Wagon>();
        private Divider divider { get; set; } = new Divider();

        List<Animal> allAnimals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            allAnimals.Add(animal);
        }

        public void StartDividing()
        {
            allAnimals = allAnimals.OrderBy(a => a.type).ThenByDescending(a => a.size).ToList();

            wagons = divider.StartDividing(allAnimals).AsReadOnly();
        }

        public IReadOnlyCollection<Wagon> GetWagons()
        {
            return wagons;
        }
    }
}