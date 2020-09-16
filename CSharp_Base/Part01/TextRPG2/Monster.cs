using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public enum eMonsterType
    {
        None = 0,
        Slime,
        Orc,
        Skeleton
    }

    class Monster : Creature
    {
        protected eMonsterType type = eMonsterType.None;
        protected Monster(eMonsterType type) : base(eCreatureType.Monster)
        {
            this.type = type;
        }

        public eMonsterType GetMonsterType() { return this.type; }
    }

    class Slime : Monster
    {
        public Slime() : base(eMonsterType.Slime)
        {
            SetInfo(10, 10);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(eMonsterType.Orc)
        {
            SetInfo(20, 15);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(eMonsterType.Skeleton)
        {
            SetInfo(15, 20);
        }
    }
}
