namespace _05_Singleton
{
    public sealed class Singleton
    {
        private Singleton() { }
        private static Singleton? _instance;
        public static Singleton GetInstance()
        {
            return _instance ??= new Singleton();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1 == s2)
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            else
                Console.WriteLine("Singleton failed, variables contain different instances.");
        }
    }
}
