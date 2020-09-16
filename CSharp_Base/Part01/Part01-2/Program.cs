using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01_2
{
    // 객체 (OOP object Oriented Programming)
    class Player
    {
        protected int HP;
        protected int Attack;

        public virtual void Move()
        {

        }
    }

    class Knight : Player
    {
        public override void Move()
        {
            
        }
    }

    class Mage : Player
    {
        public int mp;

        public override void Move()
        {

        }
    }

    class Program
    {
        static void ChangeName(string str)
        {
            str = "Change!";
        }

        static void Main(string[] args)
        {
            string name = "Harry Potter";

            ChangeName(name);

            // 1. 찾기
            bool bFound = name.Contains("Harry");
            int index = name.IndexOf("H");

            // 2. 변형
            name = name + " Wizard";

            string LowerName = name.ToLower();
            string UpperName = name.ToUpper();
            string newName = name.Replace('r', 'l');

            // 3. 분활
            string[] names = name.Split(new char[] {' ' });
        }
    }
}
