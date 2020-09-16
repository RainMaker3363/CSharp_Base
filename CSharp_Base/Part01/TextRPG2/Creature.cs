using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public enum eCreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        eCreatureType type;

        protected Creature(eCreatureType type)
        {
            this.type = type;
        }

        protected int Hp = 0;
        protected int Attack = 0;

        public void SetInfo(int hp, int attack)
        {
            this.Hp = hp;
            this.Attack = attack;
        }

        public int GetHp() { return this.Hp; }
        public int GetAttack() { return this.Attack; }

        public bool IsDead() { return Hp <= 0; }
        public void OnDamged(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
                Hp = 0;
        }
    }
}
