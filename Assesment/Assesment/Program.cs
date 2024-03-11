using System.Runtime.CompilerServices;

namespace Assesment
{


    public interface IVechicle {
        public void drive();
    }

    public class Vehicle : IVechicle
    {
        private string _name;
        private int _speed;
        public Vehicle(string name,int speed)
        {
            Name = name;
            Speed = speed;
        }
        public string Name { get; set; }
        public int Speed { get; set; }

        public virtual void drive(int speed,string name)
        {
            Console.WriteLine($"Driving {name} with speed {speed}");
        }

        public void drive()
        {
            Console.WriteLine("Driving...");
        }
    }

    public class AutoVehicle : Vehicle , IVechicle
    {
        private int _engineDispalcement;
        public AutoVehicle(string name, int speed,int engineDisplacement) : base(name, speed)
        {
            EngineDisplacement = engineDisplacement;
        }

        public override void drive(int speed, string name)
        {
            base.drive(speed, name);
            Console.WriteLine("Overrident drive method from parent class");
        }

        public int EngineDisplacement { get; set; }

        public void drive(AutoVehicle auto)
        {
            Console.WriteLine($"Driving {auto.Name} with {auto.EngineDisplacement}L engine vehicle with {auto.Speed} speed");
        }
        public void drive()
        {
            Console.WriteLine("Driving motorcycle...");
        }
    }

    public class Car : AutoVehicle, IVechicle
    {
        private string _brand;
        private string optional;
        public Car(string name, int speed, int engineDisplacement,string brand) : base(name, speed, engineDisplacement)
        {
            Brand = brand;
        }

        public void drive()
        {
            Console.WriteLine("Driving car...");
        }
        public void drive(Car car)
        {
            Console.WriteLine($"Driving {car.Name} {car.Brand} with {car.EngineDisplacement}L engine vehicle with {car.Speed} speed");
        }

        
        public void optionalParam(int required, string optionalstr = "default string")
        {
            Console.WriteLine($"if you see text after the dots it means that the optional parameter was given... : s{optional}");
            Console.WriteLine($"required was:{required}");
        }

        public string Brand { get; set; }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Vehicle bike = new Vehicle("bike", 10);
            AutoVehicle motorcycle = new AutoVehicle("motorcycle", 100, 1);
            Car car = new Car("car", 250, 6, "Porsche");
            bike.drive();
            motorcycle.drive();
            motorcycle.drive(100,"motorcycle");
            car.drive(car:car);
            car.optionalParam(required:10,optionalstr:"test string");
        }
    }
}