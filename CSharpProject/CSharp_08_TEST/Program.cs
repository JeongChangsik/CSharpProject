namespace CSharp_08;

class Program
{
    // 문제 5-6. 캐릭터 직업을 나타내는 JobClass enum을 만드세요. (전사 Warrior , 마법사 Mage , 궁수 Archer )
    enum JobClass
    {
        Warrior = 0,
        Mage,
        Archer
    }
    
    //문제 7-2. 아래 Monster 클래스를 완성하세요. (이름과 체력 프로퍼티, 그리고 둘을 받는 생성자)
    class Monster
    {
        public string Name { get; set; }
        public float Hp { get; set; }
        
        // 생성자를 작성하세요
        public Monster(string name, float hp)
        {
            Name = name;
            Hp = hp;
        }
    }

    static void Main(string[] args)
    {
        // 문제 1-1. 다음 중 float 변수를 올바르게 선언한 것은? - B
        // (A) float speed = 5.5;
        // (B) float speed = 5.5f;
        // (C) float speed = "5.5";
        // (D) int speed = 5.5f;
        
        // 문제 1-2. 아래 빈칸에 들어갈 자료형을 채우세요.
        string characterName = "마법사"; // 캐릭터 이름
        bool isBoss = false; // 보스 여부
        int manaPoint = 80; // 정수 마나
        
        // 문제 1-3. 다음 코드를 작성하세요.
        // * mana 라는 이름의 변수에 정수 30 을 저장하고
        // * "현재 마나: 30" 형태로 화면에 출력하기 ( $ 보간 사용)
        int mana = 30;
        Console.WriteLine($"현재 마나: {mana}");
        
        // 문제 2-1. 다음 코드의 출력값은? - 1
        int score = 7;
        Console.WriteLine(score % 2);
        
        // 문제 2-2. 플레이어가 스킬을 쓰려면 체력이 0보다 크고 AND 마나가 50 이상이어야 합니다. 빈칸을 채우세요.
        float hp = 30f;
        float mana2 = 60f;
        bool canUseSkill = (hp > 0) && (mana2 >= 50);
        
        // 문제 2-3. 다음 코드의 최종 gold 값은? - 240
        int gold = 100;
        gold += 50; // 퀘스트 보상
        gold -= 30; // 물약 구매
        gold *= 2; // 골드 부스터 이벤트
        Console.WriteLine(gold);

        // 문제 3-1. score 가 90 이상이면 "S" , 80 이상이면 "A" , 그 외에는 "B" 를 출력하는 if문을 작성하세요. ( score = 85 가정)
        int score2 = 85;
        if (score2 >= 90) Console.WriteLine("S");
        else if (score2 >= 80) Console.WriteLine("A");
        else Console.WriteLine("B");
        
        // 문제 3-2. 다음 switch 식의 출력값은? - 해독
        int potionType = 3;
        string effect = potionType switch
        {
            1 => "체력 회복",
            2 => "마나 회복",
            3 => "해독",
            _ => "알 수 없음"
        };
        Console.WriteLine(effect);

        // 문제 3-3. 아래 코드에서 잘못된 부분을 찾아 고치세요.
        int hp2 = 50;
        if (/*hp = 0*/ hp2 == 0)
        {
            /*Console.WriteLine("사망")*/
            Console.WriteLine("사망");
        } 

        // 문제 4-1. for 문으로 "체크포인트 1" 부터 "체크포인트 5" 까지 출력하세요
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"체크포인트 {i + 1}");
        }
        
        // 문제 4-2. 다음 반복문은 몇 번 실행될까요? - 5
        for (int i = 0; i < 10; i += 2)
        {
            Console.WriteLine("반복!");
        }
        
        // 문제 4-3. 1부터 100까지 더한 합계를 구하는 코드를 완성하세요.
        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum += i;
        }
        Console.WriteLine(sum); // 5050이 나와야 함
        
        // 문제 5-1. 다음 코드의 출력값은? - 30
        int[] scores = { 10, 20, 30, 40 };
        Console.WriteLine(scores[2]);

        // 문제 5-2. List 와 배열 의 가장 큰 차이를 한 문장으로 설명하세요.
        // - List는 선언 이후에 가변적으로 배열의 사이즈를 늘리거나 줄일 수 있음.
        // 답: List 크기를 자유롭게 조절할 수 있다.
        
        // 문제 5-3. 빈칸을 채워 적 3마리를 List에 추가하고 총 마릿수를 출력하세요.
        List<string> enemies = new List<string>();
        enemies.Add("슬라임");
        enemies.Add("고블린");
        enemies.Add("오크");
        Console.WriteLine($"적 수: {enemies.Count}"); // 리스트는 Length -> Count로 자동 변환됨. *** 중요

        // 문제 5-4. 문자열 대신 enum을 쓰면 좋은 이유를 한 문장으로 설명하세요.
        // - switch문 사용이 용이함
        // 답: 소스코드의 가독성과 오타를 방지하기 위함
        
        // 문제 5-6. 위에 작성
        
        // 문제 5-7. 다음 코드의 출력값은? - 2
        // enum Direction { Up, Down, Left, Right }
        // Console.WriteLine((int)Direction.Left);

        // 문제 6-1. 두 정수를 곱해서 돌려주는 Multiply 메서드를 작성하세요.
        int Multiply(int a, int b)
        {
            return a * b;
        }
        
        // 문제 6-2. 다음 메서드의 반환값은? - 70
        // static int GetExp(int monsterLevel)
        // {
        //     return monsterLevel * 10;
        // }
        // int exp = GetExp(7);
        
        // 문제 6-3. 아래 코드에서 잘못된 부분을 고치세요.
        static /*void*/int PrintScore(int score)
        {
            return score; // 점수를 출력하려는 의도
        }

        // 문제 6-4. 사용자에게 골드를 입력받아, 숫자면 "{입력값} G 획득!" , 숫자가 아니면 "잘못된 입력" 을 출력하는 코드를 TryParse 로 작성하세요
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int gold2))
        {
            Console.WriteLine($"{gold2} G 획득!");
        }
        else
        {
            Console.WriteLine($"잘못된 입력");
        }

        // 문제 6-5. static 메서드와 일반 메서드의 차이를 한 문장으로 설명하세요.
        // - static은 인스턴스 없이 접근이 가능하나, 일반 메서드는 인스턴스에 메모리 할당 후 접근이 가능

        // 문제 7-1. 클래스와 객체의 관계를 "붕어빵"에 비유해서 설명하세요.
        // - 객체가 붕어빵이라면 클래스는 붕어빵틀이다.
        
        // 문제 7-2. 위에 작성
        
        // 문제 7-3. 다음 코드에서 객체를 생성하는 부분은 몇 번째 줄인가요?  - 2
        //     class Item { public string Name; } // 1
        //     Item potion = new Item(); // 2
        //     potion.Name = "물약"; // 3
    }
    
}