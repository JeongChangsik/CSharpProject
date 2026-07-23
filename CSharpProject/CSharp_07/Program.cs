namespace CSharp_07;

/*
 * abstract vs interface
 * 
 *  abstract
 * - 하나만 상속이 가능 (ex. class Dragon : Enemy)
 * - 필드(멤버 변수) 선언 허용, 프로퍼티 허용
 * 
 *  interface
 * - 여러 개 상속이 가능
 * - 필드 선언 불가, 프로퍼티는 허용
 */

// 인터페이스 정의(선언) : 항상 public
interface IDamageable
{
    int Hp { get; set; }
    void TakeDamage(int damage);    // 구현부(로직), 구현체없이 "뼈대"만 선언
}

interface IAttackable
{
    void Attack();
}

interface IFlyable
{
    void Fly();
}

class Player : IDamageable, IAttackable
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public Player()
    {
        Name = "Player";
        Hp = 200;
    }

    // 인터페이스에서 요구한 메서드를 반드시 구현해야 함
    public void TakeDamage(int damage)
    {
        // 구현하지 않을 시 예외 발생
        // throw new NotImplementedException();
        
        // 실제 로직 작성
        Hp -= damage;
        Console.WriteLine($"[{Name}]이 {damage}의 데미지를 입었습니다. - 남은 체력 : {Hp}");
    }

    public void Attack()
    {
        // throw new NotImplementedException();
    }
}

// abstract 클래스(추상 클래스) : 로직을 정의할 수 없고, 상속받은 클래스에서 로직을 구현하도록 강제
// 반면, virtual은 부모 클래스에서 로직을 작성할 수 있고 상속할 수 있음
abstract class Enemy : IDamageable, IAttackable
{
    public string Name { get; set; }
    public int Hp { get; set; }

    public Enemy() {}
    public Enemy(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }

    public abstract void Attack();
    
    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
        if(Hp < 0) Hp = 0;
        Console.WriteLine($"[{Name}]이 {damage}의 데미지를 입었습니다. - 남은 체력 : {Hp}");
    }
}

// C# 언어 설계 철학
// - 다중 상속을 허용하지 않는다.
// - 단일 클래스로부터 상속 받는다. Dragon은 Enemy 클래스로부터 상속을 받았지만 interface로 상속은 받을 수 있음
class Dragon : Enemy,IFlyable
{
    int Defense { get; set; }
    
    public Dragon()
    {
        Name = "Dragon";
        Hp = 1000;
        Defense = 100;
    }

    public Dragon(string name, int hp) : base(name, hp) {}

    public override void Attack()
    {
        // 추가 광역 데미지
        Console.WriteLine($"[{Name}] 화염 지속 데미지 추가");
    }

    public override void TakeDamage(int damage)
    {
        int realDamage = damage - Defense > 0 ? damage - Defense : 1;
        Hp -= realDamage;
        if(Hp < 0) Hp = 0;
        Console.WriteLine($"[{Name}] 방어력에 의해 데미지 감소 ({damage} -> {realDamage}) - 남은 체력 : {Hp}");
    }

    public void Fly()
    {
        Console.WriteLine($"[{Name}] 비행 중...");
    }

}

class Goblin : Enemy
{
    public Goblin()
    {
        Name = "Goblin";
        Hp = 100;
    }
    public Goblin(string name, int hp) : base(name, hp) {}

    public override void Attack()
    {
        Console.WriteLine($"[{Name}] 공격!");
    }

    public void Steal(Enemy enemy)
    {
        Console.WriteLine($"[{Name}]이 [{enemy.Name}]에게 도둑질 시도!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Enemy e = new Dragon();
        Enemy g = new Goblin();
        e.Attack();
        
        e.TakeDamage(200);
        
        // is 키워드 : ~인가? ~타입인가? : bool
        if (e is Dragon)
        {
            Console.WriteLine("드래곤 입니다");
            // 컴파일 에러 발생
            // e.Fly();
        }

        // 패턴 매칭 문법(확인과 변환을 한번에 처리하는 문법)
        if (e is Dragon d)
        {
            d.Fly();
        }
        
        // as 키워드 : a as b - a를 b로 변환 시도, 타입이 다르면 null 반환
        // 포인터로 넘겨주는 느낌?
        Goblin goblin1 = e as Goblin;
        Goblin goblin2 = g as Goblin;
        if (goblin1 == null)
        {
            Console.WriteLine("goblin1은 고블린이 아님");
        }
        else
        {
            goblin1.Steal(e);
        }
        
        if (goblin2 == null)
        {
            Console.WriteLine("goblin2은 고블린이 아님");
        }
        else
        {
            goblin2.Steal(e);
        }
        
        // 인터페이스 예시
        Player warrior = new Player();
        warrior.TakeDamage(10);
        warrior.Attack();
    }
}