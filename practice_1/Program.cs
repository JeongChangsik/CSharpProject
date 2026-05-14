using System;

namespace ParkingSystem
{
    /*
     * practice_1 — C# 기초 정리
     *
     * - 문자열은 큰따옴표(" "), 문자는 작은따옴표(' '). 닷넷은 유니코드라 한글 문자열도 그대로 사용.
     * - Console.WriteLine은 줄바꿈 후 출력, Write는 줄바꿈 없이 출력.
     * - 플레이스홀더 {0}, {1}, …는 뒤에 나열한 인자 중 몇 번째 값을 넣을지 지정(0부터).
     * - 입력: ReadKey는 키 한 번(ConsoleKeyInfo), ReadLine은 한 줄을 문자열로 읽음.
     * - 변환: Convert.ToXXX, int.Parse / double.Parse, 값.ToString().
     * - 문자열 대소문자: ToUpper / ToLower. 단어 단위 첫 글자 대문자는
     *   CultureInfo.CurrentCulture.TextInfo.ToTitleCase(문자열) 등으로 처리.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            string timeIn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int RegularParking = CheckRegularParking();

            if (RegularParking == 1)
            {
                GateOpen();
            }
            else
            {
                PrintTicket(timeIn);
                GateOpen();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // 2번: 문자열/문자 리터럴, WriteLine vs Write (위 파일 헤더 참고)
            string name = "홍길동";
            char exmark = '!';
            sbyte age;
            age = 20;

            Console.WriteLine("안녕, " + name + exmark);
            Console.Write("나이: " + age);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // 3번: 플레이스홀더 {0}, {1}, {2}와 인자 순서
            int x = 100;
            double y = 3.14;
            char z = 'A';

            // x, y, z값을 출력한다.
            Console.WriteLine("x: {0}, y: {1}, z: {2}", x, y, z);
            Console.WriteLine("x: {0}, y: {0}, z: {0}", x, y, z);
            Console.WriteLine("x: {1}, y: {1}, z: {1}", x, y, z);
            Console.WriteLine("x: {2}, y: {2}, z: {2}", x, y, z);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // 4번: ReadKey(키 한 번·ConsoleKeyInfo), ReadLine(한 줄·string)
            int a = 10;
            double A = 10.5;

            // placeholder 방식이 아닌 interpolation 방식을 사용하고 있음.
            Console.WriteLine($"a: {a}, A: {A}");
            // ConsoleKeyInfo input = Console.ReadKey();
            // string input2 = Console.ReadLine();
            // Console.WriteLine("입력한 값: " + input);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // 5번: Convert.ToXXX, Parse, ToString으로 문자열 ↔ 숫자 변환
            string ageString;
            int sum;
            Console.Write("나이를 입력하세요: ");
            ageString = Console.ReadLine();

            // 이렇게 하면 CS0029 암시적 변환 오류가 발생한다.
            // sum = ageString + 1;
            sum = Convert.ToInt32(ageString) + 1;

            // 라인을 줄이기 위해 하기와 같이 작성도 가능
            // sum = Convert.ToInt32(Console.ReadLine()) + 1;
            Console.WriteLine($"당신의 나이에 한 살을 더하면 {sum}살입니다.");

            Console.Write("숫자를 입력하세요: ");
            int i = int.Parse(Console.ReadLine());

            Console.Write("숫자를 입력하세요: ");
            double d = double.Parse(Console.ReadLine());

            Console.WriteLine("i: {0}, d: {1}", i, d);
            Console.WriteLine("(문자열)i: {0}, d: {1}", i.ToString(), d.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // 6번(참고): ToUpper / ToLower. TitleCase는 string 메서드가 아니라 TextInfo.ToTitleCase 사용.
            // (상수·사칙연산·증감연산자는 이번 범위에서 제외)
        }

        static int CheckRegularParking()
        {
            int result;
            bool IsRegistered = false;

            if (IsRegistered == true)
            {
                result = 1;
                return result;
            }
            else
            {
                result = 2;
                return result;
            }
        }

        static void PrintTicket(string timeIn)
        {
            Console.WriteLine("Ticket Printed at: " + timeIn);
        }

        static void GateOpen()
        {
            Console.WriteLine("Gate Open!");
        }
    }
}
