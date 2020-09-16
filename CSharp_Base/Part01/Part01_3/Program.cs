using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01_3
{
    class Monster
    {
        public int id;

        public Monster(int _id)
        {
            this.id = _id;
        }
    }

    class Map
    {
        int[,] tiles = { 
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 }
        };

        public void Render()
        {
            var color = Console.ForegroundColor;

            for(int y = 0; y<tiles.GetLength(1); ++y)
            {
                for(int x = 0; x< tiles.GetLength(0); ++x)
                {
                    if (tiles[y, x] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write('\u25cf');
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = color;
        }
    }

    class Program
    {
        static int GetHighestScore(int[] scores)
        {
            int result = 0;

            if (scores.Length <= 0)
            {
                return -1;
            }

            foreach (int score in scores)
            {
                if (result <= score)
                    result = score;
            }

            return result;
        }

        static int GetAverageScore(int[] scores)
        {
            int result = 0;

            if(scores.Length <= 0)
            {
                return -1;
            }

            foreach(int score in scores)
            {
                result += score;
            }

            result = (result / scores.Length);

            return result;
        }

        static int GetIndexOf(int[] Scores, int value)
        {
            int index = 0;
            if (Scores.Length <= 0)
            {
                return -1;
            }

            foreach (int score in Scores)
            {
                if (score == value)
                    return index;
                else
                {
                    ++index;
                }
            }

            return index;
        }

        static void Sort(int[] scores)
        {
            if (scores.Length <= 0)
            {
                return;
            }

            int minIndex = 0;

            for(int i = 0; i<scores.Length; ++i)
            {
                minIndex = i;

                for(int j = i; j<scores.Length; ++j)
                {
                    if(scores[j] < scores[minIndex])
                    {
                        minIndex = j;
                    }

                }


                int temp = scores[i];
                scores[i] = scores[minIndex];
                scores[minIndex] = temp;
            }
        }

        static void Main(string[] args)
        {
            // 배열
            int[] scores = new int[] { 10, 30, 40, 20, 50 };
            int[,] arr = new int[2, 3] { { 1, 2, 3}, {1, 2, 3 } };

            // List <- 동적 배열
            List<int> list = new List<int>();

            // Dictionary <= 이진 트리
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            for(int i = 0; i < 1000; ++i)
            {
                dic.Add(i, new Monster(i));
            }

            for (int i = 0; i<5; ++i)
                list.Add(i);

            list.RemoveAt(0);
            //list.Remove(3);

            Monster mon;
            bool bFound = dic.TryGetValue(100, out mon);

            foreach(int num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
