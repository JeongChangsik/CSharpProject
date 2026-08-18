namespace DelegateApp_02;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        
        player.OnPlayerDie?.Invoke(); // 하지만 직접 onPlayerDie를 호출하면서 객체 지향 규칙 위반(캡슐화 위반) => event 키워드 사용
        
        // event 키워드 사용 예시
        // player.OnPlayerDie2?.Invoke();  // 호출 불가!
        player.OnPlayerDie2 += GameOver;
        player.OnHpChanged += PlayerChanged;
        
        player.TakeDamage(20);
        player.TakeDamage(30);
        player.TakeDamage(20);
        player.TakeDamage(50);
    }

    static void GameOver()
    {
        Console.WriteLine("주인공 사망! Game Over!");
    }

    static void PlayerChanged(int hp)
    {
        Console.WriteLine($"HP: {hp}");
    }
}

public interface IDamagable
{
    void TakeDamage(int damage);
}
