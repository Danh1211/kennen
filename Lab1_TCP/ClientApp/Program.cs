using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    internal class Program
    {
        static void Main()
        {
            const string serverAddress = "127.0.0.1";
            const int port = 8080;

            try
            {
                using (TcpClient client = new TcpClient(serverAddress, port))
                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine($"Connected to server at {serverAddress}:{port}");

                    Console.Write("Enter a message to send: ");
                    string message = Console.ReadLine();

                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    stream.Write(messageBytes, 0, messageBytes.Length);
                    Console.WriteLine("Message sent to server.");

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Response from server: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
