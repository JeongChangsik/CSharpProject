namespace TCPChatServer;

class Program
{
    static void Main(string[] args)
    {
        // Windows 콘솔에서 UTF-8 인코딩
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        // 포트 번호
        // http(tcp) : 80, https(tcp): 443
        const int port = 7000;
        ChatServer server = new(port);
        server.Start();
        Console.WriteLine("서버를 중지하려면 아무 키나 누르세요...");
        Console.ReadKey(true);
        server.Stop();

    }
}