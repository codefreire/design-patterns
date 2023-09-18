namespace _03_FactoryMethod
{
    public interface IProduct
    {
        string Operation();
    }

    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{a result of CONCRETEPRODUCT1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{a result of CONCRETEPRODUCT2}";
        }
    }

    abstract class Creator
    {
        public abstract IProduct FactoryMethod();
        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Creator: Worked with" + product.Operation();
            return result;
        }
    }

    class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    class Client
    {
        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: It works ..." + creator.SomeOperation());
        }
        
        public void Main()
        {
            Console.WriteLine("Launched with the ConcreteCreator1------");
            ClientCode(new ConcreteCreator1());
            Console.WriteLine("Launched with the ConcreteCreator2.-----");
            ClientCode(new ConcreteCreator2());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
