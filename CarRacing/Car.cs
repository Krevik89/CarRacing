using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    public abstract class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract void Move();
    }

    public class SportsCar : Car
    {
        public SportsCar(string name, int speed) : base(name, speed)
        {
        }

        public override void Move()
        {
            // двигаться со случайной скоростью в пределах от 80 до 120
            Random random = new Random();
            int speed = random.Next(80, 121);
            Speed = speed;
        }
    }

    public class PassengerCar : Car
    {
        public PassengerCar(string name, int speed) : base(name, speed)
        {
        }

        public override void Move()
        {
            // двигаться со случайной скоростью в пределах от 60 до 100
            Random random = new Random();
            int speed = random.Next(60, 101);
            Speed = speed;
        }
    }

    public class Truck : Car
    {
        public Truck(string name, int speed) : base(name, speed)
        {
        }

        public override void Move()
        {
            // двигаться со случайной скоростью в пределах от 40 до 70
            Random random = new Random();
            int speed = random.Next(40, 71);
            Speed = speed;
        }
    }

    public class Bus : Car
    {
        public Bus(string name, int speed) : base(name, speed)
        {
        }

        public override void Move()
        {
            // двигаться со случайной скоростью в пределах от 50 до 90
            Random random = new Random();
            int speed = random.Next(50, 91);
            Speed = speed;
        }
    }
}
