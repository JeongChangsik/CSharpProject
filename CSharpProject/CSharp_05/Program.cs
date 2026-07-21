namespace CSharp_05;

/*
 * 접근제한자
 * public - 어디서든지 모두 접근을 허용(클래스 외부에 공개)
 * private - 자신의 클래스에서만 접근을 허용(데이터 은닉화, 캡슐화)
 * protected - 자신의 클래스 + 자식 클래스에 접근을 허용
 * internal - 같은 어셈블리 안에서 접근을 허용(같은 프로그램 내에서 접근을 허용)
 */

// 클래스 정의
// 코딩 컨벤션(코드 작성할 때 표준) private 변수의 변수명 앞에 _(언더스코어)를 붙임
// C#에서는 class 앞에 아무것도 입력하지 않으면 internal로 설정됨
class Player
{
    // 필드(field) : 데이터
    private string _name;
    private float _hp;   // 캡슐화
    private float _attackPower;
    
    // 생성자
    public Player()
    {
        _name = "이름";
        _hp = 50f;
        _attackPower = 10f;
        Console.WriteLine($"Player 초기화: name: {_name} / _hp: {_hp} / attackPower: {_attackPower}");
    }
    
    public Player(string name, float hp, float attackPower)
    {
        _name = name;
        _hp = hp;
        _attackPower = attackPower;
        Console.WriteLine($"Player 초기화: name: {_name} / _hp: {_hp} / attackPower: {_attackPower}");
    }
    
    // 메서드(method) : 로직, 함수, 동작
    public void Attack()
    {
        Console.WriteLine($"{_name}가 {_attackPower}로 공격!");
    }
    
    // 프로퍼티 방식(Property: 속성) - 외부에 공개되어 있는 속성
    public float Hp
    {
        // 일반적인 Property 방식
        // get { return _hp; } // 사용할 때, float Hp = {instance}.Hp;
        set
        {
            if (value > 100f) { _hp = 100f; }
            else if (value < 0f) { _hp = 0f; }
            else { _hp = value; } 
        }    // 사용할 때, {instance}.Hp = 100f;

        // property + goes to
        get => _hp;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    // goes to 문법으로도 표현 가능
    // public float GetHp() => _hp;
    // public void SetHp(float hp) => _hp = hp;
    
    
    // getter, setter 기본 방식
    # region get_set
    // public float GetHp()
    // {
    //     return _hp;
    // }
    //
    // public void SetHp(float hp)
    // {
    //     _hp = hp;
    // }
    #endregion
}

public enum ItemType
{
    Consumable,
    Weapon,
    Armor,
}

class Item
{
    private ItemType _type;
    private string _name;
    private string _description;
    private int _cost;
    private int count = 1;
    
    public ItemType Type{ get => _type; set => _type = value; }
    public string Name{ get => _name; set => _name = value; }
    public string Description{ get => _description; set => _description = value; }
    public int Cost{ get => _cost; set => _cost = value; }
    
    // 생성자
    public Item(ItemType type, string name, string description, int cost)
    {
        _type = type;
        _name = name;
        _description = description;
        _cost = cost;
    }
    
    // 메서드
    // 판매
    // 사용
}

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>();
        
        // 물약 생성
        Item potion = new Item(ItemType.Consumable, "물약","Hp 10% 회복", 100);
        items.Add(potion);
        items.Add(new Item(ItemType.Weapon, "검", "공격력을 10 올려준다", 200));
        items.Add(new Item(ItemType.Armor, "갑옷", "방어력을 10 올려준다", 300));

        foreach (var item in items)
        {
            Console.WriteLine($"아이템 타입: {item.Type} / 아이템명: {item.Name} / 설명: {item.Description} / 비용: {item.Cost}");
        }

        return;
        
        // 힙 메모리에 객체(Instance)가 생성됨
        Player hero = new Player("전사", 100f, 30f);
        // 객체의 필드값 정의(변수 설정)
        hero.Hp = 90f;
        Console.WriteLine(hero.Hp);
        // 메소드 호출
        hero.Attack();
        
        Player wizard = new Player("마법사", 80f, 50f);
        wizard.Hp = 70f;
        Console.WriteLine($"{wizard.Name}의 체력은 {wizard.Hp}입니다");
        // 메소드 호출
        wizard.Attack();
    }
}