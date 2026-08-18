namespace DelegateApp_02;

public class Player : IDamagable
{
    // 필드
    public int Hp { get; private set; }

    // 1. 델리게이트 선언
    public delegate void PlayerDidHandler();
    
    // 2. 델리게이트 이벤트
    public PlayerDidHandler OnPlayerDie;    // 객체 지향 위반
    public event PlayerDidHandler OnPlayerDie2; // event 키워드 사용
    
    // Action
    // 델리게이트 문법을 간격하게 선언할 수 있는 .NET 내장 델리게이트
    // 반환타입이 없는 델리게이트는 Action, 있는 델리게이트는 Action<T, ~> (파라미터 16개까지 지원)
    // 문법
    public event Action<int> OnHpChanged;
    
    // Func

    private void Die()
    {
        Console.WriteLine("Player 사망");
    }

    public Player()
    {
        Hp = 100;
        OnPlayerDie += Die;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        OnHpChanged?.Invoke(Hp);
        
        if (Hp <= 0)
        {
            Hp = 0;
            OnPlayerDie2?.Invoke();
        }
        
        Console.WriteLine($"Player가 {damage} 피해를 입음 (잔여 Hp : {Hp})");
    }
}