namespace CSharp_06;

/*
 * 객체지향 프로그래밍(Object-Oriented Programming)
 * 
 * [장점]
 * - 코드의 재사용성이 높다
 * - 코드의 확장성 및 유지 보수성이 편리함
 * - 협업에 유리함 - 개발자간의 역할 분담 명확
 * - 대규모 프로젝트에 적합
 * 
 * [단점]
 * - 초기 클래스 설계 비용이 크다
 * - 잘못된 클래스 설계는 유지 보수를 어렵게한다
 * - God Object(클래스가 너무 비대해는 것을 경계)
 * - 과도한 추상화의 위험(상속 남발 -> 구조가 복잡)
 * - 객체의 생성 비용 발생
 *
 * # 객체지향 프로그래밍의 4가지 핵심원칙
 * - 캡슐화(Encapsulation) : 데이터를 안전하게 보호
 * - 상속(Inheritance) : 코드의 재사용성
 * - 다형성(Polymorphism) : 오버로딩(overloading)
 * - 추상화(Abstraction) : 복잡성 줄이기
 */

class Character
{
    // Field
    protected string name;  // protected : 자신과 상속받은 자식 클래스에서 접근을 허용
    protected int hp;
    protected int attackPower;

    // Constructor
    public Character(string name, int hp, int attackPower)
    {
        this.name = name;
        this.hp = hp;
        this.attackPower = attackPower;
    }
    
    // Property
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Hp
    {
        get => hp;
        set => hp = value;
    }

    public int AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }
    
    // Method
    public void Attack(Character target)
    {
        Console.WriteLine($"({Name})이 ({target.Name})을(를) 공격 - damage: {AttackPower}");
        
        target.TakeDamage(attackPower);
        Console.WriteLine($"({target.Name})의 남은 체력: {target.Hp} HP");
        Console.WriteLine();
    }

    // 상속 후 재정의 virtual 키워드(가상 메서드)
    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
    }
}

// 자식 클래스
class Warrior : Character
{
    private int defense = 10;

    public int Defense => defense;

    public Warrior(string name, int hp, int attackPower) : base(name, hp, attackPower)
    {
        defense = 10;
    }
    
    public override void TakeDamage(int damage)
    {
        int realDamage = damage - defense > 0 ? damage - defense : 1;
        base.TakeDamage(realDamage);
        Console.WriteLine($"전사의 방어력({defense}def)에 의해 데미지 감소: {damage} -> {realDamage}");
    }
}

class Wizard : Character
{
    private int mana;
    private int maxMana;
    
    public int Mana => mana;

    public Wizard(string name, int hp, int attackPower) : base(name, hp, attackPower)
    {
        maxMana = 100;
        mana = maxMana;
    }

    public void Fireball(Character target)
    {
        int manaCost = 10;
        if (mana < manaCost)
        {
            Console.WriteLine($"마나가 부족합니다. (필요: {manaCost} MP, 현재: {mana}/{maxMana})");
            return;
        }

        mana -= manaCost;
        target.TakeDamage(attackPower*2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior = new Warrior("전사", 100, 10);
        Character Enermy = new Character("적", 50, 2);
        Wizard wizard = new Wizard(name:"마법사", hp:50, attackPower:5);
        
        warrior.Attack(Enermy);
        Enermy.Attack(warrior);
        
        Enermy.Attack(wizard);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        wizard.Fireball(Enermy);
        
        
    }
}