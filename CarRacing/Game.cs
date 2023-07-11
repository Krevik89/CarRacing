using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRacing
{
    internal class Game
    {
        private List<Car> cars = new List<Car>();
        public delegate void RaceEventHandler(object sender, string message);

        public event RaceEventHandler RaceEvent;

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void StartRace()
        {
            int finishLine = 1000;

            while (true)
            {
                foreach (Car car in cars)
                {

                    car.Move();
                    RaceEvent?.Invoke(this, $"{car.Name} движется со скоростью {car.Speed} км/ч");
                    if (car.Speed  >= finishLine)
                    {
                        RaceEvent?.Invoke(this, $"{car.Name} прибыл на финиш");
                        RaceEvent?.Invoke(this, $"Победил автомобиль {car.Name}");
                        return;
                    }             
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }

    }
}
