using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace TCPChatServer;

public class ChatServer
{
    private TcpListener? _listener; // TCP 연결을 기다리는 리스너(Listener)
    private bool _isRunning;        // 서버 실행 여부 판단 변수
    private readonly int _port;     // 서버 포트
    private readonly ConcurrentDictionary<string, ConnectedClient> _clients;    // Thread-safe 한 컬렉션(ConcurrentDictionary)
    
    // 생성자
    public ChatServer(int port)
    {
        _port = port;
        _isRunning = false;
        _clients = new ConcurrentDictionary<string, ConnectedClient>();
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
            
            // 백그라운드에서 클라이언트 연결 수락 구동(비동기)
            _ = Task.Run(AcceptClientAsync);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Start] {e.Message}");
            throw;
        }
    }

    private async Task AcceptClientAsync()
    {
        Console.WriteLine("클라이언트 연결을 기다리는 중...");
        while (_isRunning)
        {
            try
            {
                // 클라이언트 연결 수락
                var client = await _listener!.AcceptTcpClientAsync();
                var connectedClient = new ConnectedClient(client);
                var clientId = connectedClient.ClientId;
                
                // 접속한 클라이언트 저장
                // ConcurrentDictionary
                // 방법 1) TryAdd
                // 방법 2) 인덱서 방식
                // _clients.TryAdd(connectedClient.ClientId, connectedClient);
                _clients[clientId] = connectedClient;
                
                // 이벤트 구독
                connectedClient.OnMessageReceived += OnMessageReceived;
                
                // 연결된 클라이언트 정보 출력(EndPoint = IPAddress + Port)
                Console.WriteLine($"[AcceptClientAsync] 현재 연결된 클라이언트 수 : {_clients.Count}");
                
                // 클라이언트로부터 메시지 수신 시작(비동기)
                _ = Task.Run(() => connectedClient.ReceiveMessageAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine($"[AcceptClientAsync] {e.Message}");
            }
        }
    }

    private void OnMessageReceived(ConnectedClient sender, string message)
    {
        string msg = $"[{sender.ClientId}] {message}";
        Console.WriteLine($"[브로드캐스팅] {msg}");
        
        _ = Task.Run(() => BroadcastMessageAsync(sender.ClientId, msg));
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
            Console.WriteLine($"[Stop] {e.Message}");
            throw;
        }
    }

    private async Task BroadcastMessageAsync(string clientId, string message)
    {
        foreach (var client in _clients)
        {
            if (client.Key == clientId) continue;

            if (client.Value.IsConnected)
            {
                await client.Value.SendMessageAsync(message);
            }
        }
    }
}

/* UTF-8 BOM(Byte Order Mark)
 * 
 */