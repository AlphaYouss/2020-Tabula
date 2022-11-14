namespace ClassLibrary
{
    public class Animal
    {
        public Size size { get; private set; }
        public Type type { get; private set; }

        public enum Size
        {
            small = 1,
            medium = 3,
            large = 5
        }

        public enum Type
        {
            carnivore,
            herbivore
        }

        public Animal(Type type, Size size)
        {
            this.type = type;
            this.size = size;
        }
    }
}