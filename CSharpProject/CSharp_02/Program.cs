namespace CSharp_02;

class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 3;
        // int a = 10, b = 3;
        
        // 산술 연산자(사칙연산 +, -, *, /, %)
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));
        Console.WriteLine();

        // 실수형
        float c = 10.0f;
        float d = 3.0f;
        
        Console.WriteLine("c + d = " + (c + d));
        Console.WriteLine("c - d = " + (c - d));
        Console.WriteLine("c * d = " + (c * d));
        Console.WriteLine("c / d = " + (c / d));
        Console.WriteLine("c % d = " + (c % d));
        Console.WriteLine();
       
        // 0 으로 나누는 경우 ==> 주의
        Console.WriteLine("c / 0 = " + (c / 0));
        Console.WriteLine();

        // 콘솔창 지우기
        // Console.Clear();
        
        // 복합 대입 연산자(게임 개발 시 많이 활용)
        float hp = 100f;
        
        // 데미지 적용
        hp -= 20f;  // hp = hp - 20f;
        Console.WriteLine("데미지 후 hp = " + hp);
        
        // 회복(물약 사용)
        hp += 15f;
        Console.WriteLine($"회복 후 hp = {hp}");
        
        // 스킬 사용
        hp *= 2f;
        Console.WriteLine($"스킬 사용 후 hp = {hp}");
        Console.WriteLine();
        
        // 증감 연산자(전치, 후치)
        int combo = 0;
        combo++;    // combo = combo + 1;
        Console.WriteLine($"combo = {combo}");

        int itemCount = 5;
        Console.WriteLine($"item count = {++itemCount}");   // 연산 후 6 출력
        Console.WriteLine($"item count = {itemCount++}");   // 6 출력 후 7
        Console.WriteLine($"item count = {--itemCount}");   // 연산 후 6 출력
        Console.WriteLine($"item count = {itemCount--}");   // 6 출력 후 5
        Console.WriteLine($"item count = {itemCount}");     // 5
        Console.WriteLine();

        // 비교 연산자 (>, >=, ==, !=)
        int level = 30;
        
        // bool isOver30 = level > 30;
        // bool isOver30 = level >= 30;
        // bool isOver30 = level == 30;
        bool isOver30 = level != 30;
        Console.WriteLine($"level = {level}");
        Console.WriteLine($"isOver30 = {isOver30}");
        Console.WriteLine();
        
        // 논리 연산자
        /* 
         * && (AND) : 둘 다 참
         * || (OR) : 둘 중 하나라도 참이면 참
         * ! (NOT) : true -> false, false -> true;
         */
        // 살아있고, 마나가 충분하면 스킬 시전 여부 확인
        int mp = 40;
        bool canCast = (hp > 0 && mp > 30);
        Console.WriteLine($"canCast = {canCast}");
        Console.WriteLine();

        // 전투 상황을 가정 : 공격력에서 방어력을 차감해서 데미지가 적용
        float attackPower = 45f;
        float defence = 12f;
        float enemyHp = 100f;
        
        // 1) 실제 데미지 계산
        float damage = attackPower - defence;
        Console.WriteLine($"실제 데미지 : {damage}");
        
        // 2) 적 체력 차감
        enemyHp -= damage;
        Console.WriteLine($"적의 남은 HP : {enemyHp}");
        
        // 3) 크리티컬 데미지
        bool isCritical = true;
        float criticalDamage = damage * 2f;
        enemyHp -= criticalDamage;
        Console.WriteLine($"적의 남은 HP : {enemyHp}");
        
        // 4) 적 캐릭터 사망 여부
        bool isDead = enemyHp <= 0;
        Console.WriteLine($"적 사망여부 : {isDead}");
        Console.WriteLine();
        
        /*
         * 조건문 (if / switch) : ~라면(이면) 이걸 처리해줘
         * if / else
         * if / else if
         * if (조건식) { 조건식이 true일 때 실행 }
         */

        hp = 25f;
        if (hp <= 0f)
        {
            Console.WriteLine("게임 오버");
        }
        else if (hp < 30f)
        {
            Console.WriteLine("물약 필요함");
        }
        else
        {
            Console.WriteLine("정상 체력");
        }
        Console.WriteLine();
        
        // switch 구문 : 값에 따라서 분기
        int weaponType = 1; // 0: 양손검, 1: 활, 2: 지팡이
        float weaponDamage = 0f;
        switch (weaponType)
        {
            case 0:
                Console.WriteLine("양손검");
                weaponDamage = 10f;
                break;
            case 1:
                Console.WriteLine("활");
                weaponDamage = 20f;
                break;
            case 2:
                Console.WriteLine("지팡이");
                weaponDamage = 5f;
                break;
            default:
                Console.WriteLine("무기 타입을 알 수 없습니다.");
                weaponDamage = 2f;
                break;
        }
        Console.WriteLine($"무기 데미지 : {weaponDamage}");
        
        // switch(.NET 8.0 최신 문법)
        // => goes to
        // Lamda Expression (람다식) => 람다
        // _ underscore
        weaponDamage = weaponType switch
        {
            0 => 10f,
            1 => 20f,
            2 => 5f,
            _ => 2f // default
        };
        Console.WriteLine($"최신 문법 - 무기 데미지 : {weaponDamage}");
        Console.WriteLine();
        
    }
}