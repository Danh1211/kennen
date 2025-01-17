using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace ServerApp
{
    internal class Program
    {
        static void ProcessMessage(object parm)
        {
            string data;
            int count;
            try
            {
                TcpClient client = parm as TcpClient;
                //buffer for reding data
                Byte[] bytes = new Byte[256];
                //get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                //loop to receive all the data sent by the client
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    //translate data bytes to a ASCII string
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
                    //process the data sent by the client
                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    //send back a response
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
                //shutdown and end connextion
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("Waiting message...");
            }
        }

        static void ExecuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                //start listening for client requests
                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("Waiting for a connection...");
                //Enter the listening loop
                while (true)
                {
                    //Perform a blocking call to accept requests
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected:{++Count}");
                    Console.WriteLine(new string('*', 40));
                    //create a thread to receive and send message
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server stopped. Press any key to exit !");
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            //set the TCPListener on port 13000
            int port = 13000;
            ExecuteServer(host, port);
        }
    }
}
