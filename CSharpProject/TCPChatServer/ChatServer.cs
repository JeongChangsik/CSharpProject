using System.Net;
using System.Net.Sockets;

namespace TCPChatServer;

public class ChatServer
{
    private TcpListener? _listener; // TCP 연결을 기다리는 리스너(Listener)
    private bool _isRunning;        // 서버 실행 여부 판단 변수
    private readonly int _port;     // 서버 포트
    
    // 생성자
    public ChatServer(int port)
    {
        _port = port;
        _isRunning = false;
    }

    // 서버 시작 메서드
    public void Start()
    {
        if (_isRunning)
        {
            Console.WriteLine("Server is already running.");
            return;
        }

        // TCP 리스너 초기화 및 생성
        try
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            _isRunning = true;
            Console.WriteLine($"Server started on port({_port})");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            Console.WriteLine("Server is not running.");
            return;
        }
        
        try
        {
            _isRunning = false;
            _listener?.Stop();
            Console.WriteLine("서버가 중지되었습니다.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}