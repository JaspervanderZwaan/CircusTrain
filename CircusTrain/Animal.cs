namespace CircusTrain
{
    internal class Animal
    {
        public int Size { get; }
        public Type Type { get; }

        public Animal(int size, Type type)
        {
            Size = size;
            Type = type;
        }
    }
}