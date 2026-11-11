namespace TCPChatClient;

class Program
{
    static async Task Main(string[] args)
    {
        const string SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 7000;
        
        Console.WriteLine("============ TCP 채팅 클라이언트 ============");
        
        using var client = new ChatClient(SERVER_IP, SERVER_PORT);

        try
        {
            await client.ConnectAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"[클라이언트 실행 오류] {e.Message}");
        }
        
        
    }
}