using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230622_ForestQuest
{
    public class ForestBattle
    {
        int playerHp = 50;
        int playerDamage = 20;

        int monsterHp = 100;
        int monsterDamage = 7;

        public void BattleGame()
        {
            Console.WriteLine("전투를 시작합니다");

            while (playerHp > 0 && monsterHp > 0)
            {
                monsterHp -= playerDamage;
                Console.WriteLine("플레이어가 몬스터에게 {0}의 데미지를 입혔습니다", playerDamage);

                if (monsterHp <= 0)
                {
                    Console.WriteLine("몬스터를 처치했습니다");
                    
                }

                playerHp -= monsterDamage;
                Console.WriteLine("몬스터가 플레이어에게 {0}의 데미지를 입혔습니다", monsterDamage);

                if (playerHp <= 0)
                {
                    Console.WriteLine("플레이어가 사망했습니다");
                    Console.WriteLine("맵으로 돌아갑니다");
                    
                }
            }

            Console.WriteLine("플레이어의 남은 HP: {0}", playerHp);
            
        }
    }
}