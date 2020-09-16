using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01_4
{
    class MyList<T>
    {
        T[] arr = new T[10];

        public T Getitem(int i)
        {
            return arr[i];
        }
    }

    #region Interface
    /*
    abstract class Monster
    {
        public abstract void Shout();
    }

    interface IFlyable
    {
        void Fly();
    }

    class Orc : Monster
    {
        public override void Shout()
        {
            Console.WriteLine("록타르 오가르!");
        }
    }

    class FlyableOrc : Orc, IFlyable
    {
        public void Fly()
        {

        }
    }
    */
    #endregion

    #region Property
    /*
    class Knight
    {
        protected int hp;

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }
    }
    */
    #endregion

    #region Delegate

    delegate int OnClicked();
    // delegate -> 형식은 형식인데, 함수 자체를 인자로 넘겨주는 그런 형식
    #endregion

    #region Lambda

    enum eItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring,
    }

    enum eRarity
    {
        Normal,
        Uncommon,
        Rare,
    }

    class Item
    {
        public eItemType itemType;
        public eRarity itemRarity;
    }

    #endregion

    #region Exception

    class TestException : Exception
    {
        
    }

    #endregion

    #region Reflection

    class Important : System.Attribute
    {
        string msg;

        public Important(string message)
        {
            this.msg = message;
        }
    }

    class ReflectionClass
    {
        [Important("Very Important")]
        public int hp;
        protected int attack;
        private float speed;

        void Attack()
        {

        }
    }

    #endregion

    #region Nullable

    class NullableMonster
    {

    }

    #endregion

    class Program
    {
        static void Test<T>(T input)
        {

        }

        static void ButtonPressed(OnClicked clickedFunc)
        {
            clickedFunc();
        }

        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }

        static List<Item> _items = new List<Item>();
        delegate Return MyFunc<T, Return>(T item);
        static Item Finditem(MyFunc<Item, bool> selector)
        {
            foreach(Item item in _items)
            {
                if (selector(item))
                    return item;
            }

            return null;
        }

        static void Main(string[] args)
        {
            //MyList<int> myIntList = new MyList<int>();

            InputManager inputmanager = new InputManager();
            inputmanager.Inputkey += () =>
            {
                Console.WriteLine("그아아아앗");
            };
            inputmanager.Inputkey += () =>
            {
                Console.WriteLine("Input Received!");
            };

            _items.Add(new Item() { itemType = eItemType.Weapon, itemRarity = eRarity.Normal });
            _items.Add(new Item() { itemType = eItemType.Armor, itemRarity = eRarity.Uncommon });
            _items.Add(new Item() { itemType = eItemType.Ring, itemRarity = eRarity.Rare });

            Finditem((Item item) => { return item.itemType == eItemType.Armor; });


            ReflectionClass mon = new ReflectionClass();
            Type type = mon.GetType();

            var fieldInfo = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);

            foreach(var field in fieldInfo)
            {
                string access = "Protected";
                if (field.IsPublic)
                    access = "Public";
                else if (field.IsPrivate)
                    access = "Private";

                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }

            int? number = null;
            if(number.HasValue)
            {
                int a = number.Value;
                Console.WriteLine("{0}", a);
            }
        }
    }
}
