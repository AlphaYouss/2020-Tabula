using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrein
{
    [TestClass]
    public class UnitTest
    {
        Train train = new Train();

        Animal cSmall = new Animal(Animal.Type.carnivore, Animal.Size.small);
        Animal cMedium = new Animal(Animal.Type.carnivore, Animal.Size.medium);
        Animal cLarge = new Animal(Animal.Type.carnivore, Animal.Size.large);

        Animal hSmall = new Animal(Animal.Type.herbivore, Animal.Size.small);
        Animal hMedium = new Animal(Animal.Type.herbivore, Animal.Size.medium);
        Animal hLarge = new Animal(Animal.Type.herbivore, Animal.Size.large);

        [TestMethod()]
        public void DivideNoAnimals()
        {
            train.StartDividing();
            Assert.AreEqual(0, train.GetWagons().Count);
        }


        /*
            
            The method names you read below have a separate name. The name indicates how many animals there are with that type and size. 
            For example:

            H1x5 = Herbivore small x 5.
            H3x5 = Herbivore medium x 5.
            H5x5 = Herbivore large x 5.
            C1x5 = Carnivore small x 5.
            C3x5 = Carnivore medium x 5.
            C5x5 = Carnivore large x 5.

       */

        [TestMethod()]
        public void Divide_H1x5_H3x3_H5x1()
        {
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);

            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);

            train.AddAnimal(hLarge);

            train.StartDividing();
            Assert.AreEqual(2, train.GetWagons().Count);
        }

        [TestMethod()]
        public void Divide_H5x3_C1x1_C3x3_C5x2()
        {
            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);

            train.AddAnimal(cSmall);

            train.AddAnimal(cMedium);
            train.AddAnimal(cMedium);
            train.AddAnimal(cMedium);

            train.AddAnimal(cLarge);
            train.AddAnimal(cLarge);

            train.StartDividing();
            Assert.AreEqual(6, train.GetWagons().Count);
        }

        [TestMethod()]
        public void Divide_H1x5_H3x5_H5x5_C1x2_C3x2_C5x2()
        {
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);
            train.AddAnimal(hSmall);

            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);

            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);

            train.AddAnimal(cSmall);
            train.AddAnimal(cSmall);

            train.AddAnimal(cMedium);
            train.AddAnimal(cMedium);

            train.AddAnimal(cLarge);
            train.AddAnimal(cLarge);

            train.StartDividing();
            Assert.AreEqual(8, train.GetWagons().Count);
        }

        [TestMethod()]
        public void Divide_H1x1_H3x3_H5x2()
        {
            train.AddAnimal(hSmall);

            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);

            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);

            train.StartDividing();
            Assert.AreEqual(2, train.GetWagons().Count);
        }

        [TestMethod()]
        public void Divide_H3x3_H5x2_C1x1()
        {
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);
            train.AddAnimal(hMedium);

            train.AddAnimal(hLarge);
            train.AddAnimal(hLarge);

            train.AddAnimal(cSmall);

            train.StartDividing();
            Assert.AreEqual(2, train.GetWagons().Count);
        }
    }
}