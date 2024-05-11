using System.Net.Sockets;
using System.Text;

namespace TcpTest {
    internal class Program {
        static void Main(string[] args) {
            TcpClient client = new("127.0.0.1", 4948);
            NetworkStream stream = client.GetStream();

            string jsonMessage = "{\"Qualifier\":\"showWinningNumber\",\"Data\":{\"WinningNumber\":24}}";
            byte[] buffer = Encoding.ASCII.GetBytes(jsonMessage);
            stream.Write(buffer, 0, buffer.Length);

            client.Close();
        }
    }
}
