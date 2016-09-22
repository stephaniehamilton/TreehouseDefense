using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense1
{
    class Game
    {
        public static Tower[] Towers { get; private set; }

        public static void Main()
        {
            Map map = new Map(8, 5);
            try
            {
                Path path = new Path(
                    new[]{

                        new TreehouseDefense1.MapLocation(0,2, map),
                        new TreehouseDefense1.MapLocation(1,2, map),
                        new TreehouseDefense1.MapLocation(2,2, map),
                        new TreehouseDefense1.MapLocation(3,2, map),
                        new TreehouseDefense1.MapLocation(4,2, map),
                        new TreehouseDefense1.MapLocation(5,2, map),
                        new TreehouseDefense1.MapLocation(6,2, map),
                        new TreehouseDefense1.MapLocation(7,2, map)
                        }
                    );
                Invader[] invaders =
                {
                    new TreehouseDefense1.Invader(path),
                    new TreehouseDefense1.Invader(path),
                    new TreehouseDefense1.Invader(path)
                };
                Tower[] towers =
                {
                    new TreehouseDefense1.Tower(new MapLocation(1,3, map)),
                    new TreehouseDefense1.Tower(new MapLocation(3,3, map)),
                    new TreehouseDefense1.Tower(new MapLocation(5,3, map))
                };

                Level level = new TreehouseDefense1.Level(invaders);
                {
                    Towers = towers;
                };
                bool playerWon = level.Play();
                Console.WriteLine("Player " + (playerWon? "won" : "lost"));
             }
            catch (OutOfBoundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TreehouseDefenseException)
            {
                Console.WriteLine("unhandled TreehouseDefenseException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Exception: " + ex);
            }
        }
    }
}
