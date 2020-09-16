using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public enum eGameMode
    {
        None = 0,
        Lobby,
        Town,
        Field
    }

    class Game
    {
        private eGameMode mode = eGameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch(mode)
            {
                case eGameMode.Lobby:
                    {
                        ProcessLobby();
                    }
                    break;

                case eGameMode.Town:
                    {
                        ProcessTown();
                    }
                    break;

                case eGameMode.Field:
                    {
                        ProcessField();
                    }
                    break;

            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            Int32 input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    {
                        player = new Knight();
                        mode = eGameMode.Town;
                    }
                    break;

                case 2:
                    {
                        player = new Archer();
                        mode = eGameMode.Town;
                    }
                    break;

                case 3:
                    {
                        player = new Mage();
                        mode = eGameMode.Town;
                    }
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("마을에 입장했습니다!");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            Int32 input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    {
                        mode = eGameMode.Field;
                    }
                    break;

                case 2:
                    {
                        mode = eGameMode.Lobby;
                    }
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("필드에 입장했습니다!");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRandomMonster();

            Int32 input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    {
                        ProcessFight();
                    }
                    break;

                case 2:
                    {
                        TryEscape();
                    }
                    break;
            }
        }

        private void CreateRandomMonster()
        {

            int randValue = rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    {
                        monster = new Slime();
                        Console.WriteLine("슬라임이 생성되었습니다.");
                    }
                    break;

                case 1:
                    {
                        monster = new Orc();
                        Console.WriteLine("오크가 생성되었습니다.");
                    }
                    break;

                case 2:
                    {
                        monster = new Skeleton();
                        Console.WriteLine("스켈레톤이 생성되었습니다.");
                    }
                    break;
            }
        }

        private void ProcessFight()
        {
            while(true)
            {
                int damage = player.GetAttack();
                monster.OnDamged(damage);

                if(monster.IsDead())
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력{player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamged(damage);
                if(player.IsDead())
                {
                    Console.WriteLine("패배했습니다.");
                    mode = eGameMode.Lobby;
                    break;
                }
            }
        }

        private void TryEscape()
        {
            int randValue = rand.Next(0, 101);
            if(randValue < 33)
            {
                mode = eGameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }
    }
}
