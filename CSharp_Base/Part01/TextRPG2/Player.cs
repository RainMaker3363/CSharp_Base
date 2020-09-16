using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public enum ePlayerType
    {
        None = 0,
        Knight,
        Archer,
        Mage
    }

    class Player : Creature
    {
        protected ePlayerType Type = ePlayerType.None;

        protected Player(ePlayerType type) : base(eCreatureType.Player)
        {
            this.Type = type;
        }
    }

    class Knight : Player
    {
        public Knight() : base(ePlayerType.Knight)
        {
            base.SetInfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(ePlayerType.Archer)
        {
            base.SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage() : base(ePlayerType.Mage)
        {
            base.SetInfo(50, 20);
        }
    }
}
