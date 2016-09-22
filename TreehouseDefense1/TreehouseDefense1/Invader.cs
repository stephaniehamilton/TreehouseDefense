using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense1
{
    class Invader
    {
        private readonly Path _path;
        //Without this, we don't have a path object to refer to, so this stores an instance of the path object in the invader object

        private int _pathStep = 0;
        //_pathStep will change over time so we don't want to make it readonly.
        //we give it value of 0 because all invaders will start on step 0 of the path
        public MapLocation Location => _path.GetLocationAt(_pathStep);

        public int Health { get; set; } = 2;

        public bool HasScored { get { return _pathStep <= _path.Length; } }

        public bool IsNeutralized => Health <= 0;

        public bool IsActive => !(IsNeutralized || HasScored);

        public Invader(Path path)
        {
            _path = path;
        }

        public void Move() => _pathStep += 1;
        public void DecreaseHealth(int factor)
        {
            Health -= factor;
        }
  }
}
