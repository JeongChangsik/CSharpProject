namespace CSharp_04;

class Program
{
    static void Main(string[] args)
    {
        // 복습
        #region 복습
        // List 복습
        List<string> inventory = new List<string>();
        inventory.Add("목검");
        inventory.Add("녹슨 검");
        inventory.Add("체력 물약");
        
        /* foreach 사용 시 var 변수타입을 권장하는데,
         * var 키워드 : 컴파일 과정에서 저장된 값에 따라 변수 타입을 변경해줌
         * var hp = 100;  <== var will be int type
         */

        // foreach 사용 시 index 값 확인을 위해 IndexOf(~) 사용
        foreach (string item in inventory)
        {
            Console.WriteLine($"아이템[{inventory.IndexOf(item)}] : {item}");
        }
        Console.WriteLine();
        
        // for 사용 시 보통 index 값으로 반복문을 구성하기 때문에
        // for (int i = 0; i < inventory.Count; i++)
        // {
        //     Console.WriteLine($"아이템[{i}] : {inventory[i]}");
        // }
        // Console.WriteLine();
        
        // List 삭제
        inventory.Remove("녹슨 검");
        
        // "녹슨 검" 버린 후
        foreach (string item in inventory)
        {
            Console.WriteLine($"아이템[{inventory.IndexOf(item)}] : {item}");
        }
        
        // List 검색, IndexOf or Find 사용
        if (inventory.IndexOf("체력 물약") >= 0)
        {
            Console.WriteLine("물약 보유");
        }
        else
        {
            Console.WriteLine("물약 미보유");
        }
        Console.WriteLine();
        Console.WriteLine();

        // Dictionary 복습
        Dictionary<string, int> shop = new Dictionary<string, int>
        {
            {"체력 물약", 100},
            {"마나 물약", 50},
            {"강철 검", 500}
        };

        // or
        // Dictionary<string, int> shop = new Dictionary<string, int>(); 이후
        shop["나무"] = 20;
        
        Console.WriteLine($"강철 검 가격 : {shop["강철 검"]}");
        Console.WriteLine();

        shop["녹슨 검"] = 300;

        // TryGetValue(key, out 변수타입 변수명) : key값이 있으면, 변수명에 가져옴
        // lifecycle 상 if문 안에서만 price를 사용할 수 있음. -> if문 끝나면 메모리에서 사라짐
        if (shop.TryGetValue("녹슨 검", out int price))
        {
            Console.WriteLine($"녹슨 검 가격 : {price}");
        }
        else
        {
            Console.WriteLine("녹슨 검이 없습니다.");
        }
        Console.WriteLine();
        
        #endregion  // 복습
        
        // 반복문 출력
        foreach (KeyValuePair<string, int> item in shop)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
        Console.WriteLine();
        Console.WriteLine();
        
        // 함수(method)
        DisplayTitle();
        TakeDamage(30f);
        Console.WriteLine($"실제 데미지 : {GetDamage(30f)}");

        float damage = 30f;
        float defense = 10f;
        Console.WriteLine($"데미지 : {damage}, 방어력 : {defense}, 실제 입은 데미지 : {GetDamage(damage, defense)}");
        Console.WriteLine();
        
        // 콘솔창 입력 받기 
        Console.Clear();
        Console.Write("이름을 입력하세요: ");
        string? name = Console.ReadLine();     // 한 줄로 입력받기
        Console.WriteLine($"{name} 님, 마을에 오신 것을 환영합니다.");
        Console.WriteLine();
        
        Console.Write("물약을 몇 개 구매하시겠습니까? - ");
        string? input = Console.ReadLine();
        // int buyCount = int.Parse(input != null ? input : "0");
        // Console.WriteLine($"구매 물약의 가격은 {buyCount * 10} G 입니다.");
        
        // 만약 물약 개수에 "aaaaa"라고 텍스트를 입력할 시 예외 발생
        // 그러므로 하기와 같이 사용이 정확함
        if (int.TryParse(input, out int buyCount2))
        {
            Console.WriteLine($"구매 물약의 가격은 {buyCount2 * 10} G 입니다.");
        }
        else
        {
            Console.WriteLine($"숫자만 입력해 주세요.");
        }
    }
    
    // #region 리전명
    // 코드 블럭 나누기
    // #endregion
    #region Method 문법 연습

    // 함수(Function) => 절차지향 언어 (c)
    // 메서드(Method) => 객체지향 언어 (java, c++, c#)
    //
    // 메서드 형식
    // [static] [접근제한자] 반환타입 메서드이름([매개변수...]) {};    <== []: 생략 가능, 메서드 기존 구조
    // 반환타입 : 반환할 변수 타입(아래에서는 void)
    // 접근제한자 : private / protected / public
    // c# 메서드 이름 규약 : Pascal Case (파스칼 케이스) - 첫글자 대문자, 키워드가 바뀌면 대문자로 시작(아래와 같이)
    // 매개변수
    static void DisplayTitle()
    {
        string title = "Text RPG";
        Console.WriteLine(title);
    }

    // 2) 매개변수(파라미터)가 있는 경우
    static void TakeDamage(float damage)
    {
        float defense = 10f;
        float realDamage = damage - defense;
        Console.WriteLine($"{realDamage}의 데미지를 입었다.");
    }
    
    // 3) 매개변수, 반환값이 있는 메서드 문법
    static float GetDamage(float damage)
    {
        float defense = 10f;
        return damage - defense;
    }
    
    // 4) 메서드 오버로딩 (Method Overloading)
    // 메서드 이름은 동일, 파라미터 갯수나 타입을 다르게 설정하는 기능
    static float GetDamage(float damage, float defense)
    {
        return damage - defense;
    }
    #endregion  // !Method
}