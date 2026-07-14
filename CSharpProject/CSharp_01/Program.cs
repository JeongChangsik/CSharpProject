namespace CSharp_01;

class Program
{
    static void Main(string[] args)
    {
        // 변수 선언 - 타입 변수명 = 초깃값;
        int level = 1;  // 정수 (int, integer)
        float hp = 100.0f;  // 실수 (float)
        
        Console.WriteLine("게임 개발자의 세계로 오신 것을 환영합니다!");
        
        // Console.Write(level);
        // Console.Write(hp);
        
        // 문자열 연결 (+)
        Console.WriteLine("레벨: " + level);
        Console.WriteLine("HP: " + hp);
        
        // 문자열 보간 ($"...")
        Console.WriteLine($"레벨: {level}");
        Console.WriteLine($"HP: {hp}");
        
    }
}