using System.Net.Sockets;
using System.Text;

namespace TcpTest {
    internal class Program {
        static void Main(string[] args) {
            TcpClient client = new("127.0.0.1", 4948);
            NetworkStream stream = client.GetStream();

            Random random = new Random();
            int winningNumber = random.Next(0, 37);

            string jsonMessage = $"{{\"Qualifier\":\"showWinningNumber\",\"Data\":{{\"WinningNumber\":{winningNumber}}}}}";
            Console.WriteLine(jsonMessage);

            byte[] buffer = Encoding.ASCII.GetBytes(jsonMessage);
            stream.Write(buffer, 0, buffer.Length);

            client.Close();
        }
    }
}
