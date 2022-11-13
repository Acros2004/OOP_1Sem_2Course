using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    class Game
    {

        public string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Game(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return Type;
        }
    }
}
