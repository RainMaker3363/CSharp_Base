using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG1
{
    class Program
    {
        enum eClassType
        {
            NONE = 0,
            KNIGHT,
            ARCHER,
            MAGICIAN,
        }

        enum eMonsterType
        {
            NONE = 0,
            SLIME,
            ORC,
            SKELETON
        }


        struct Character
        {
            public int AttackPoint;
            public int HP;
        }

        struct Monster
        {
            public int AttackPoint;
            public int HP;
        }


        static eClassType PlayerJobSelect()
        {
            eClassType mPlayerClassType = eClassType.NONE;

            Console.WriteLine("=======================================================================================");
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            Int32 JobNumber = Convert.ToInt32(Console.ReadLine());
            switch (JobNumber)
            {
                case (int)eClassType.KNIGHT:
                    {
                        mPlayerClassType = eClassType.KNIGHT;
                    }
                    break;

                case (int)eClassType.ARCHER:
                    {
                        mPlayerClassType = eClassType.ARCHER;
                    }
                    break;

                case (int)eClassType.MAGICIAN:
                    {
                        mPlayerClassType = eClassType.MAGICIAN;
                    }
                    break;
            }

            return mPlayerClassType;
        }

        static void CreatePlayer(eClassType type, out Character Stat)
        {
            switch(type)
            {
                case eClassType.KNIGHT:
                    {
                        Stat.HP = 100;
                        Stat.AttackPoint = 10;
                    }
                    break;

                case eClassType.ARCHER:
                    {
                        Stat.HP = 75;
                        Stat.AttackPoint = 7;
                    }
                    break;

                case eClassType.MAGICIAN:
                    {
                        Stat.HP = 50;
                        Stat.AttackPoint = 15;
                    }
                    break;

                default:
                    {
                        Stat.HP = 0;
                        Stat.AttackPoint = 0;
                    }
                    break;
            }
        }
        static void CreateRandomMonster(out Monster Monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);

            switch(randMonster)
            {
                case (int)eMonsterType.SLIME:
                    {
                        Console.WriteLine("{0}이 스폰되었습니다.", eMonsterType.SLIME.ToString());
                        Monster.HP = 20;
                        Monster.AttackPoint = 2;
                    }
                    break;
                case (int)eMonsterType.ORC:
                    {
                        Console.WriteLine("{0}이 스폰되었습니다.", eMonsterType.ORC.ToString());
                        Monster.HP = 40;
                        Monster.AttackPoint = 4;
                    }
                    break;
                case (int)eMonsterType.SKELETON:
                    {
                        Console.WriteLine("{0}이 스폰되었습니다.", eMonsterType.SKELETON.ToString());
                        Monster.HP = 30;
                        Monster.AttackPoint = 3;
                    }
                    break;
                default:
                    {
                        Monster.HP = 0;
                        Monster.AttackPoint = 0;
                    }
                    break;
            }
        }

        static void Fight(ref Character Player, ref Monster monster)
        {
            while(true)
            {
                // 플레이어가 몬스터 공격
                monster.HP -= Player.AttackPoint;
                if(monster.HP <= 0)
                {
                    Console.WriteLine("승리했습니다.!");
                    Console.WriteLine($"남은 체력 : {Player.HP}");
                    break;
                }

                // 몬스터 반격
                Player.HP -= monster.AttackPoint;
                if(Player.HP <= 0)
                {
                    Console.WriteLine("패배했습니다.!");
                    break;
                }
            }
        }

        static void EnterField(ref Character Player)
        {
            while(true)
            {
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("필드에 접속했습니다.");

                // 랜덤으로 1~3 몬스터 중 하나를 리스폰
                // [1] 전투 모드로 돌입
                // [2] 일정 확률로 마을로 도망
                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] 전투에 돌입");
                Console.WriteLine("[2] 마을로 도망");

                Int32 input = Convert.ToInt32(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        {
                            Fight(ref Player, ref monster);
                        }
                        break;

                    case 2:
                        {
                            // 33% 확률로 도망
                            Random rand = new Random();
                            int randValue = rand.Next(0, 101);
                            if(randValue <= 33)
                            {
                                Console.WriteLine("도망치는데 성공했습니다.");
                                break;
                            }
                            else
                            {
                                Fight(ref Player, ref monster);
                            }

                        }
                        break;
                }
            }

        }

        static void EnterGame(ref Character Player)
        {
            while(true)
            {
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("게임에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        EnterField(ref Player);
                        break;

                    case 2:
                        return;
                }
            }

        }

        static void Main(string[] args)
        {
            eClassType PlayerClassType = eClassType.NONE;
            Character Player;

            while (true)
            {
                // 캐릭터 생성
                if (PlayerClassType == eClassType.NONE)
                    PlayerClassType = PlayerJobSelect();

                if (PlayerClassType != eClassType.NONE)
                {
                    // 기사(100/10), 궁수(75/7), 법사(50/15)
                    CreatePlayer(PlayerClassType, out Player);

                    Console.WriteLine($"HP{Player.HP} Attack{Player.AttackPoint}");

                    // 필드로 가서 몬스터랑 싸운다
                    EnterGame(ref Player);
                }
            }
        }
    }
}
