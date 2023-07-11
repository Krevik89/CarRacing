using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Game game = new Game();
             game.RaceEvent += (sender, message) => Console.WriteLine(message);

             Car sportsCar = new SportsCar("Спортивный автомобиль", 0);
             Car passengerCar = new PassengerCar("Легковой автомобиль", 0);
             Car truck = new Truck("Грузовик", 0);
             Car bus = new Bus("Автобус", 0);

             game.AddCar(sportsCar);
             game.AddCar(passengerCar);
             game.AddCar(truck);
             game.AddCar(bus);

             game.StartRace();*/
            Player player1 = new Player("Игрок 1");
            Player player2 = new Player("Игрок 2");

            List<Player> players = new List<Player>() { player1, player2 };
            Game1 game = new Game1(players);

            game.Play();

            Console.ReadLine();

        }
    }
}
