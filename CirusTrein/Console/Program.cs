using ClassLibrary;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            Animal cSmall = new Animal(Animal.Type.carnivore, Animal.Size.small);
            Animal cMedium = new Animal(Animal.Type.carnivore, Animal.Size.medium);
            Animal cLarge = new Animal(Animal.Type.carnivore, Animal.Size.large);

            Animal hSmall = new Animal(Animal.Type.herbivore, Animal.Size.small);
            Animal hMedium = new Animal(Animal.Type.herbivore, Animal.Size.medium);
            Animal hLarge = new Animal(Animal.Type.herbivore, Animal.Size.large);

            // nr.1
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);

            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);

            train.AddAnimal(hLarge);

            // nr.2
            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);

            //train.AddAnimal(cSmall);

            //train.AddAnimal(cMedium);
            //train.AddAnimal(cMedium);
            //train.AddAnimal(cMedium);

            //train.AddAnimal(cLarge);
            //train.AddAnimal(cLarge);

            // nr.3
            //train.AddAnimal(hSmall);
            //train.AddAnimal(hSmall);
            //train.AddAnimal(hSmall);
            //train.AddAnimal(hSmall);
            //train.AddAnimal(hSmall);

            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);

            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);

            //train.AddAnimal(cSmall);
            //train.AddAnimal(cSmall);

            //train.AddAnimal(cMedium);
            //train.AddAnimal(cMedium);

            //train.AddAnimal(cLarge);
            //train.AddAnimal(cLarge);

            // nr.5
            //train.AddAnimal(hSmall);

            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);

            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);

            // nr.6
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);
            //train.AddAnimal(hMedium);

            //train.AddAnimal(hLarge);
            //train.AddAnimal(hLarge);

            //train.AddAnimal(cSmall);

            train.StartDividing();

            int x = train.GetWagons().Count;
        }
    }
}