using System;
using System.Linq;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Divider
    {
        List<Wagon> wagons = new List<Wagon>();

        List<Animal> allAnimals = new List<Animal>();

        IReadOnlyCollection<Animal> wagonAnimals = new List<Animal>();
        List<Animal> anAnimalCollection = new List<Animal>();

        public List<Wagon> StartDividing(List<Animal> animals)
        {
            allAnimals.AddRange(animals);

            for (int i = 0; i < allAnimals.Count; i++)
            {
                bool has = allAnimals.Any(x => x.type == Animal.Type.carnivore);

                if (has == true)
                {
                    anAnimalCollection = new List<Animal>();

                    if (allAnimals[i].size == Animal.Size.large && allAnimals[i].type == Animal.Type.carnivore)
                    {
                        DivideLargeCarnivore(allAnimals[i]);
                        allAnimals.RemoveAt(i);
                    }
                    else if (allAnimals.Any(x => x.type == Animal.Type.carnivore && x.size == Animal.Size.medium))
                    {
                        DivideMediumCarnivore(allAnimals[i]);
                        allAnimals.RemoveAt(i);
                    }
                    else if (allAnimals.Any(x => x.type == Animal.Type.carnivore && x.size == Animal.Size.small))
                    {
                        DivideSmallCarnivore(allAnimals[i]);
                        allAnimals.RemoveAt(i);
                    }
                     i--;
                }
                else
                {
                    anAnimalCollection = new List<Animal>();
                    int pointsLeft = 10;

                    for (int ii = 0; ii < allAnimals.Count; ii++)
                    {
                        if (pointsLeft >= 0 && pointsLeft - Convert.ToInt32(allAnimals[ii].size) >= 0)
                        {
                            anAnimalCollection.Add(allAnimals[ii]);
                            pointsLeft = pointsLeft - Convert.ToInt32(allAnimals[ii].size);
                            allAnimals.Remove(allAnimals[ii]);

                            ii--;
                        }
                    }
                    wagonAnimals = anAnimalCollection.AsReadOnly();
                    wagons.Add(NewWagon(wagonAnimals));
                }
            }

            return wagons;
        }

        private void DivideLargeCarnivore(Animal animal)
        {
            anAnimalCollection.Add(animal);
            wagonAnimals = anAnimalCollection.AsReadOnly();

            wagons.Add(NewWagon(wagonAnimals));
        }

        private void DivideMediumCarnivore(Animal animal)
        {
            anAnimalCollection.Add(animal);

            if (allAnimals.Any(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.large))
            {
                Animal foundAnimal = allAnimals.FirstOrDefault(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.large);
                anAnimalCollection.Add(foundAnimal);

                allAnimals.Remove(foundAnimal);
            }

            wagonAnimals = anAnimalCollection.AsReadOnly();
            wagons.Add(NewWagon(wagonAnimals));
        }

        private void DivideSmallCarnivore(Animal animal)
        {
            anAnimalCollection.Add(animal);

            int countMedium = allAnimals.Where(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.medium).Count();
            int countLarge = allAnimals.Where(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.large).Count();

            int pointsLeft = 9;

            if (countMedium >= 1)
            {
                List<Animal> mediumAnimals = allAnimals.Where(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.medium).ToList();

                for (int ii = 0; ii < mediumAnimals.Count; ii++)
                {
                    if (pointsLeft >= 0 && pointsLeft - Convert.ToInt32(mediumAnimals[ii].size) >= 0)
                    {
                        anAnimalCollection.Add(mediumAnimals[ii]);

                        allAnimals.Remove(mediumAnimals[ii]);

                        pointsLeft = pointsLeft - 3;
                    }
                }
            }

            if (countLarge >= 1 && pointsLeft >= 0)
            {
                Animal foundAnimal = allAnimals.FirstOrDefault(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.large);
                if (allAnimals.Any(x => x.type == Animal.Type.herbivore && x.size == Animal.Size.large) && pointsLeft - Convert.ToInt32(foundAnimal.size) >= 0)
                {
                    anAnimalCollection.Add(foundAnimal);

                    allAnimals.Remove(foundAnimal);

                    pointsLeft = pointsLeft - 5;
                }
            }

            wagonAnimals = anAnimalCollection.AsReadOnly();
            wagons.Add(NewWagon(wagonAnimals));
        }

        private Wagon NewWagon(IReadOnlyCollection<Animal> animals)
        {
            Wagon wagon = new Wagon();
            wagon.SetAnimals(animals);

            return wagon;
        }
    }
}