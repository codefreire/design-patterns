namespace _06_Adapter;

public interface ITarget
{
    string GetRequest();
}


public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific Request.";
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee _adaptee)
    {
        this._adaptee = _adaptee;
    }

    public string GetRequest()
    {
        return $"This is {_adaptee.GetSpecificRequest()}";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");
            Console.WriteLine(target.GetRequest());
        }
    }
}