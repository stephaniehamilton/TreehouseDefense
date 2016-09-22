using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense1
{
    class Tower
    {
        private const int _range = 1;
        private const int _power = 1;
        private const double _accuracy = .75;

        private static readonly System.Random _random = new System.Random();

        private readonly MapLocation _location;

        public Tower(MapLocation location)
        {
            _location = location;
        }
        public bool IsSuccessfulShot()
        {
            return _random.NextDouble() < _accuracy;
        }
        public void FireOnInvaders(Invader[] invaders)
        {
            foreach (Invader Invader in invaders)
            {
                if (Invader.IsActive && _location.InRangeOf(Invader.Location, _range))
                {
                    if (IsSuccessfulShot())
                    {
                        Invader.DecreaseHealth(_power);
                        Console.WriteLine("shot at and hit an invader!");
                     
                   if(Invader.IsNeutralized)
                        {
                            Console.WriteLine("Neutralized invader");
                        }
                     }
                    else
                    {
                        Console.WriteLine("shot and missed the invader.");
                    }
                    break;
                }
            }
        }
    }
}
