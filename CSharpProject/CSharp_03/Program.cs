using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;

namespace CSharp_03;


// 열거형 정의
enum MonsterRank
{
    Boss = 0, 
    Elite,
    Normal,
    Weak,
}

class Program
{
    static void Main(string[] args)
    {
        int monsterLevel = 47;  // 몬스터 레벨
        MonsterRank rank;    // 몬스터 등급
        
        // bool isGameOver = true;
        // if (isGameOver) return;

        if (monsterLevel >= 50)
        {
            rank = MonsterRank.Boss;
        } 
        else if (monsterLevel >= 30)
        {
            rank = MonsterRank.Elite;
        }
        else if (monsterLevel >= 10)
        {
            rank = MonsterRank.Normal;
        }
        else
        {
            rank = MonsterRank.Weak;
        }
        
        Console.WriteLine($"레벨: {monsterLevel}, 몬스터 등급: {rank}");
        Console.WriteLine();

        // 람다식(Lamda Expression)
        int reward = rank switch
        {
            MonsterRank.Boss => 1000,
            MonsterRank.Elite => 300,
            MonsterRank.Normal => 100,
            MonsterRank.Weak => 30,
            _ => 0,
        };
        Console.WriteLine($"처치 보상: {reward} G");
        Console.WriteLine();
        
        
        // 반복문 (for / foreach/ while / do-while)
        /*
         * for (시작점; 조건; 증감)
         * {
         *      반복 실행할 로직;
         * }
         */

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"적 {i+1}번째 소환");
            // 적 스폰시키는 로직...
        }
        Console.WriteLine();

        // while 문 - while(조건 = true 인 동안) {반복 로직}
        float bossHp = 100f;
        while (bossHp > 0f)
        {
            bossHp -= 25f;
            Console.WriteLine($"보스 체력 : {bossHp}");
        }
        Console.WriteLine();

        int index = 0;
        string[] items = { "검", "마나", "물약" };
        foreach (string item in items)
        {
            Console.WriteLine($"보유한 아이템({index++}): {item}");
        }
        Console.WriteLine();

        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"보유한 아이템({i}): {items[i]}");
        }
        Console.WriteLine();

        // break, continue
        for (int i = 0; i < 10; i++)
        {
            if (i == 5) break;
            if (i % 2 == 0) continue;
            Console.WriteLine($"{i}");
        }
        Console.WriteLine();
        
        
        Console.WriteLine("=== 웨이브 시작 ===");
        // 고블린 생성
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"고블린 {i}번째 생성");
        }
        
        // 보스 공격
        Console.WriteLine("\n=== 보스전 ===");
        bossHp = 100f;

        float playerDamage = 30f;
        // 턴 정보 저장
        int turn = 1;

        while (bossHp > 0f)
        {
            bossHp -= playerDamage;
            if (bossHp < 0f) bossHp = 0f;   // 음수 방지
            Console.WriteLine($"{turn++}턴 - 보스에서 {playerDamage}만큼 데미지 입힘!(보스 체력: {bossHp})");
        }
        if(bossHp == 0f) Console.WriteLine("보스 처리");
        Console.WriteLine();
        
        // List : 크기를 자유롭게 변경
        // 제너릭 문법 T
        List<string> inventory = new List<string>();
        inventory.Add("대용량 체력 물약");
        inventory.Add("소용량 마나 물약");
        inventory.Add("대용량 마나 물약");
        
        Console.WriteLine("");
        
        // Dictionary 딕셔너리 자료형 : Key로 저장된 값(Value)을 검색이 가능
        Dictionary<string, int> shop = new Dictionary<string, int>();   // new ();
        
        // Indexer 방식으로 추가 (중복시 업데이트하고 오류 X)
        shop["물약"] = 10;
        shop["검"] = 2;
        
        // Add로 추가(중복이 발생하면 오류 발생)
        shop.Add("마나", 3);
        
        Console.WriteLine($"{shop["물약"]}");
    }
}