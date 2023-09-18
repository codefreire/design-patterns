namespace _15_Interpreter;

public class Context
{
    public Dictionary<char, int> Variables { get; } = new Dictionary<char, int>();
}

public interface IExpression
{
    int Interpret(Context context);
}

public class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Context context)
    {
        return _number;
    }
}

public class VariableExpression : IExpression
{
    private char _variable;

    public VariableExpression(char variable)
    {
        _variable = variable;
    }

    public int Interpret(Context context)
    {
        if (context.Variables.ContainsKey(_variable))
        {
            return context.Variables[_variable];
        }
        else
        {
            throw new ArgumentException($"Variable {_variable} no definida.");
        }
    }
}

public class AddExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        return _left.Interpret(context) + _right.Interpret(context);
    }
}

public class SubtractExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        return _left.Interpret(context) - _right.Interpret(context);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var context = new Context();

        context.Variables['a'] = 5;
        context.Variables['b'] = 3;

        IExpression expression = new SubtractExpression(
            new AddExpression(new VariableExpression('a'), new VariableExpression('b')),
            new NumberExpression(2)
        );

        int result = expression.Interpret(context);

        Console.WriteLine("Resultado: " + result);
    }
}