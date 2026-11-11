using System.Net.Sockets;
using System.Text;

namespace TCPChatClient;

public class ChatClient : IDisposable
{
    // TCP 클라이언트
    private TcpClient? _tcpClient;
    private NetworkStream? _stream;
    private StreamWriter? _writer;
    private StreamReader? _reader;
    
    private bool _isConnected;  // 서버와 연결 여부
    private bool _isDisposed;   // 리소스 해제 
    
    // 서버 IP 주소 및 포트 번호
    private readonly string _serverIp;
    private readonly int _serverPort;
    
    // 프로퍼티
    public bool IsConnected => _isConnected && !_isDisposed;

    // 생성자
    public ChatClient(string ip, int port)
    {
        _serverIp = ip;
        _serverPort = port;
        _isConnected = false;
        _isDisposed = false;
    }
    
    ~ChatClient() => Dispose();

    public void Dispose()
    {
        if (_isDisposed) return;
        
        _isDisposed = true;
        _isConnected = false;
        Console.WriteLine($"[{_serverIp}:{_serverPort}] 연결 종료 중...");
        
        _reader?.Dispose();
        _writer?.Dispose();
        _stream?.Dispose();
        _tcpClient?.Dispose();
        Console.WriteLine($"[{_serverIp}:{_serverPort}] 연결 종료");
    }

    #region 서버 연결

    public async Task ConnectAsync()
    {
        if (IsConnected)
        {
            Console.WriteLine("server is already connected");
            return;
        }

        try
        {
            Console.WriteLine($"{_serverIp}:{_serverPort} 서버 연결 중...");
            
            // TcpClient 생성 및 서버 연결
            _tcpClient = new TcpClient(_serverIp, _serverPort);
            await _tcpClient!.ConnectAsync(_serverIp, _serverPort);
            
            // 스트림 생성
            _stream = _tcpClient.GetStream();
            _reader = new StreamReader(_stream, Encoding.UTF8);
            _writer = new StreamWriter(_stream, new UTF8Encoding(false)) {AutoFlush = true};
            
            _isConnected = true;
            Console.WriteLine($"{_serverIp}:{_serverPort} connected");
        }
        catch (Exception e)
        {
            Console.WriteLine($"[서버 연결 실패] {e.Message}");
        }
    }
    
    #endregion

    #region 메시지 송수신
    
    // 메시지 비동기 수신
    private async Task ReceiveMessageAsync()
    {
        if (!IsConnected || _reader == null)
        {
            Console.WriteLine("server is not connected");
            return;
        }

        try
        {
            while (IsConnected)
            {
                // 한 라인씩 읽기(\n 기준)
                string? message = await _reader.ReadLineAsync();

                if (message == null)
                {
                    if (IsConnected)
                    {
                        Console.WriteLine("서버와 연결이 종료되었습니다.");
                        Thread.Sleep(50);
                    }

                    break;
                }
                
                Console.WriteLine($"[수신] {message}");
            }
        }
        catch (Exception e)
        {
            if (IsConnected)
            {
                Console.WriteLine($"[메시지 수신 오류] {e.Message}");
            }
            else
            {
                Console.WriteLine($"[] {e.Message}");
            }
        }
        finally
        {
            Dispose();
        }
    }

    #endregion
}