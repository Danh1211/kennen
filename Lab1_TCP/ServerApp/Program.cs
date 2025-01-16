using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ServerApp
{
    internal class Program
    {
        static void Main()
        {
            const int port = 8080;
            TcpListener listener = new TcpListener(IPAddress.Any, port);

            try
            {
                listener.Start();
                Console.WriteLine($"Server started on port {port}. Waiting for a connection...");

                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                        Console.WriteLine($"Connected to client at {clientEndPoint}");

                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received: {receivedText}");

                        string responseText = receivedText.ToUpper();
                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);
                        stream.Write(responseBytes, 0, responseBytes.Length);

                        Console.WriteLine($"Sent: {responseText}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
