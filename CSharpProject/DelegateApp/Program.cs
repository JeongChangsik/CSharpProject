namespace DelegateApp;

// Delegate(=대리자) ==> Event/Action 문법 ==> 디자인 패턴 (옵저버 패턴, 이벤트 버스)
// 메서드(함수)를 저장하는 타입
// int a = 10;
// delegate sum = 함수;
// 문법 형식 : {델리게이트명} {변수명} = {함수명};


class Program
{
    // 1. 델리게이트 선언
    // {접근제어자} {delegate} {저장할 수 있는 함수의 형태}
    private delegate void LoggerDelegate(string message);
    
    static void Main(string[] args)
    {
        // 2. 델리게이트 변수에 (메소드) 할당
        // {델리게이트명} {변수명} = {함수명}
        //LoggerDelegate? log = Logger;
        LoggerDelegate? log = null;
        
        // 3. 델리게이트 호출 (만약 델리게이트가 null이면 Nullreference Exception 발생)
        // log("델리게이트 호출 1");
        // log.Invoke("델리게이트 호출 2");
        
        // 해결하려면 log? <- ? 사용으로 회피 가능
        log?.Invoke("델리게이트 호출 3");
        
        
        // 4. Delegate Chain
        log += Logger;
        log += LoggerTime;
        
        log?.Invoke("델리게이트 호출 4");
        
        Console.WriteLine("체이닝 완료");
        
        // 5. 델리게이트 체인 해제
        log -= LoggerTime;
        
        log?.Invoke("체인 해제된 델리게이트");
    }
    
    static void Logger(string message)
    {
        Console.WriteLine(message);
    }

    static void LoggerTime(string msg)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {msg}");
    }
}