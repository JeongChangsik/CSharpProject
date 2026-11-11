using System.Net.Sockets;

namespace TCPChatServer;

public class ConnectedClient : IDisposable
{
    private readonly TcpClient _client;     // TCP 클라이언트
    private readonly NetworkStream _stream; // 네트워크 스트림(Network Stream)
    private readonly StreamReader _reader; // 스트림 - 읽기전용 (수신)
    private readonly StreamWriter _writer; // 스트림 - 쓰기전용 (송신)
    private readonly string _clientId;      // 클라이언트 ID
    private bool _isDisposed;               // 메모리 해제 여부
    
    public string ClientId => _clientId;    // 클라이언트 ID 프로퍼티
    public bool IsConnected => !_isDisposed && _client.Connected; // 클라이언트 연결 여부 프로퍼티
    
    // 메시지 수신 이벤트
    public event Action<ConnectedClient, string> OnMessageReceived;

    public ConnectedClient(TcpClient client)
    {
        _client = client;
        _stream = client.GetStream();   // 스트림 버퍼 메모리 해제
        
        // 스트림 초기화 (UTF-8 인코딩)
        _reader = new StreamReader(_stream, System.Text.Encoding.UTF8);
        // StreamWriter 성능 향상을 위해 내부 버퍼에 데이터를 모아서 한 번에 전송함.
        // AutoFlush = true 로 설정하면 내부 버퍼를 사용하지않고 바로 전송함
        // _writer = new StreamWriter(_stream, System.Text.Encoding.UTF8) { AutoFlush = true};
        _writer = new StreamWriter(_stream, new System.Text.UTF8Encoding(false)) { AutoFlush = true};
        
        // 연결된 클라이언트 정보 출력(EndPoint = IPAddress + Port)
        _clientId = client.Client.RemoteEndPoint?.ToString() ?? Guid.NewGuid().ToString();
        _isDisposed = !client.Connected;
        
        Console.WriteLine($"클라이언트가 연결되었습니다 - {_clientId}");
    }

    ~ConnectedClient() => Dispose();

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        
        _reader.Dispose();
        _writer.Dispose();
        
        _stream.Dispose();
        _client.Dispose();
    }
    
    // 비동기 메시지 수신 처리
    public async Task ReceiveMessageAsync()
    {
        try
        {
            while (IsConnected)
            {
                // 비동기로 한 줄씩 읽기 - StreamReader.ReadLineAsync()
                string? message = await _reader.ReadLineAsync();
                
                // TCP는 연결이 끊어지면 null값이 return됨
                if (message == null)
                {
                    Console.WriteLine($"연결 종료 - {_clientId}");
                    break;
                }
                
                Console.WriteLine($"[수신] {_clientId}: {message}");
                
                OnMessageReceived?.Invoke(this, message);
                
                foreach (char c in message)
                    Console.Write($"{(int)c:X4} ");
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            if (!_isDisposed)
            {
                Console.WriteLine(e);
            }
        }
        finally
        {
            Dispose();
        }
    }

    public async Task SendMessageAsync(string message)
    {
        if (!IsConnected)
        {
            Console.WriteLine("[전송 실패] 클라이언트 연결 실패");
            return;
        }

        try
        {
            await _writer.WriteLineAsync(message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[전송 오류] {e.Message}");
        }
    }
}