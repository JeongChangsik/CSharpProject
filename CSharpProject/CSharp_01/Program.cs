namespace CSharp_01;

class Program
{
    static void Main(string[] args)
    {
        // 변수 선언 - 타입 변수명 = 초깃값;
        string playerName = "Zack";
        int level;  // 정수 (int, integer)
        float hp = 100.0f;  // 실수 (float)
        bool isDead = false;

        level = 1;
        
        Console.WriteLine("게임 개발자의 세계로 오신 것을 환영합니다!");
        Console.WriteLine();
        
        // 문장 넘기기(\n) 없이
        // Console.Write("이름: " + playerName);
        // Console.Write(" 레벨: " + level);
        // Console.Write(" HP: " + hp);
        // Console.Write(" 사망 여부: " + isDead);
        // Console.Write();
        
        // 문자열 연결 (+)
        Console.WriteLine("이름: " + playerName);
        Console.WriteLine("레벨: " + level);
        Console.WriteLine("HP: " + hp);
        Console.WriteLine("사망 여부: " + isDead);
        Console.WriteLine();
        
        level = level + 1;
        
        // 문자열 보간 ($"...")
        // Console.WriteLine($"이름: {playerName}");
        // Console.WriteLine($"레벨: {level}");
        // Console.WriteLine($"HP: {hp}");
        // Console.WriteLine($"사망 여부: {isDead}");
        Console.WriteLine($"이름 : {playerName}, 레벨 : {level}, HP : {hp}, 사망 여부: {isDead}");
        
    }
}