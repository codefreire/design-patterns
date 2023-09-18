namespace _04_Prototype
{
    internal class IdInfo
    {
        public int IdNumber { get; set; }
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    internal class Prototype : ICloneable
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Name { get; set; }
        public IdInfo IdInfo { get; set; }

        public object Clone() //ShallowCopy
        {
            return (Prototype)this.MemberwiseClone();
            
        }

        public Prototype DeepCopy()
        {
            Prototype clone = (Prototype)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Prototype p1 = new() { Age=21,BirthDate= Convert.ToDateTime("1900-01-01"),Name="C",IdInfo=new(444)};
            Prototype p2 = (Prototype)p1.Clone();
            Prototype p3 = p1.DeepCopy();

            Console.WriteLine("RECIEN CREADOS---------");
            Console.WriteLine($"p1 -> Age:{p1.Age}, Birthdate:{p1.BirthDate}, Name:{p1.Name}, IdInfo:{p1.IdInfo},");
            Console.WriteLine($"p1 -> Age:{p2.Age}, Birthdate:{p2.BirthDate}, Name:{p2.Name}, IdInfo:{p2.IdInfo},");
            Console.WriteLine($"p1 -> Age:{p3.Age}, Birthdate:{p3.BirthDate}, Name:{p3.Name}, IdInfo:{p3.IdInfo},");
            
            p1.Age = 40;
            Console.WriteLine("MODIFICADO P1------------");
            Console.WriteLine($"p1 -> Age:{p1.Age}, Birthdate:{p1.BirthDate}, Name:{p1.Name}, IdInfo:{p1.IdInfo},");
            Console.WriteLine($"p1 -> Age:{p2.Age}, Birthdate:{p2.BirthDate}, Name:{p2.Name}, IdInfo:{p2.IdInfo},");
            Console.WriteLine($"p1 -> Age:{p3.Age}, Birthdate:{p3.BirthDate}, Name:{p3.Name}, IdInfo:{p3.IdInfo},");
        }
    }
}
