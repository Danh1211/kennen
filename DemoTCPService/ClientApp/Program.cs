using System.Net.Sockets;

namespace ClientApp
{
    internal class Program
    {
        static void ConnectServer(String server, int port)
        {
            string message, responseData;
            int bytes;
            try
            {
                //creat a TcpClient
                TcpClient client = new TcpClient(server, port);
                Console.Title = "Client Application";
                NetworkStream stream = null;
                while (true)
                {
                    Console.WriteLine("Input message <press Enter to exit>:");
                    message = Console.ReadLine();
                    if (message == string.Empty)
                    {
                        break;
                    }
                    // Translate the passed message into ASCII and store it as a byte array
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
                    //get a client stream for reading and writing
                    stream = client.GetStream();
                    //send the message to the connected TcpServer
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);
                    // receive the TcpServer response
                    // use buffer to store the response bytes
                    data = new byte[256];
                    // read the first batch of the TcpServer response bytes
                    bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                //shutdown and end connection
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

            static void Main(string[] args)
            {
                string server = "127.0.0.1";
                int port = 13000;
                ConnectServer(server, port);
            }
        }
}
