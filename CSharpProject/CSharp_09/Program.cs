namespace CSharp_09;

// C# 제네릭 - 타입을 매개변수로 다루는 법 (C++의 template)
/* 제네릭(Generic)이란?
 * 클래스나 메서드를 정의할 때 타입을 나중에 지정할 수 있게해주는 기능
 * 1. 코드 재사용
 * 2. 타입 안전성
 * 3. 성능 향상 : object Boxing / Unboxing
 */
        
/* 제네릭 vs object
 * - object를 쓰면 박싱/언박싱 비용이 발생, 캐스팅 실수가 런타임 에러 발생, 제네릭은 컴파일 타임에 타입을 판단함.
 * - 그래서 object는 거의 금기시하고 사용하지 않음
 */
        
/* 제약 조건(Constraint)이란? - where
 * "where" 키워드를 이용해서 T에 들어갈 타입을 제약 조건으로 걸 수 있음
 * where T : struct     - 값 타입만 허용(ex: int, float, bool 등)
 * where T : class      - 참조 타입만 허용(ex: string, 배열, 클래스 등)
 * where T : new()      - 매개변수 없는 생성자 필수(ex: new T() 호출 가능)
 * where T : 기반클래스   - 특정 클래스의 하위 타입만(ex: where T: Enemy)
 * where T : 인터페이스   - 특정 인터페이스 구현 필수(ex: where T : IComparable)
 */
        
// List<T>, Dictionary<TKey, TValue> 도 동일하게 generic 클래스다.

class Program
{
    static void Main(string[] args)
    {

        Box<int> numBox = new();
        numBox.Set(42);
        numBox.ShowItem();

        Box<string> strBox = new();
        strBox.Set("문자열 지정");
        strBox.ShowItem();
        
        // 제너릭 타입의 인벤토리 사용
        // Inventory<string> inventory = new();
        // inventory.Add("Sword");
        // inventory.Add("Shield");
        // inventory.Add("HP Potion");
        // inventory.Add("MP Potion");
        // inventory.ShowItem();

        Inventory<Weapon> inventory2 = new();
        inventory2.Add(new Weapon { Name = "Sword", Damage = 10 });
        inventory2.Add(new Weapon { Name = "Axe", Damage = 15 });
        inventory2.ShowItem();
        
        GameManager gm = Singleton<GameManager>.Instance;
        gm.StartGame();
        Singleton<GameManager>.Instance.StartGame();
        
        AudioManager am = Singleton<AudioManager>.Instance;
        am.PlaySound("테스트 음악");
        Singleton<AudioManager>.Instance.PlaySound("또 다른 테스트");
    }

    static int AddInt(int a, int b) => a + b;
    static float AddFloat(float a, float b) => a + b;
    // 변수 타입만 다르고 로직이 동일한 경우, 비효율적임 -> 그래서 generic 사용
}


// 제네릭 클래스 선언
public class Box<T>
{
    public T Item;
    
    public void Set(T item) => Item = item;
    public T Get() => Item;

    public void ShowItem()
    {
        Console.WriteLine($"내용물: {Item}");
    }
}

// 제네릭 타입의 인벤토리
public class Inventory<T> where T : Item
{
    private List<T> _items = new();
    
    public void Add(T item) => _items.Add(item);
    public void Remove(T item) => _items.Remove(item);

    public void ShowItem()
    {
        foreach (var item in _items)
        {
            Console.WriteLine($"[{_items.IndexOf(item)}] {item.Name}");
        }
    }
}

public class Item
{
    public string Name { get; set; }
}

public class Weapon : Item
{
    public int Damage { get; set; }
}

// 제네릭 싱글턴 (Generic Singleton)
// 제네릭 + 싱글턴 패턴으로 많이 사용함
// public class Singleton<T> where T : class, new()
public class Singleton<T> where T : class, new()
{
    private static T? _instance;

    private Singleton()
    {
        if (_instance == null)
        {
            _instance = new T();
        }
    }

    // 외부 접근 가능한 프로퍼티
    public static T Instance {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}

public class GameManager
{
    public void StartGame() => Console.WriteLine("게임 시작");
}

public class AudioManager
{
    public void PlaySound(string clip) => Console.WriteLine($"{clip} 사운드 재생!");
}
