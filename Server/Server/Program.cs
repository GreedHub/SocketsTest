using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server {
    class Program {
        static void Main(string[] args) {

            IPAddress ip = IPAddress.Parse("0.0.0.0");
            int port = 61000;
            TcpListener server = new TcpListener(ip, port);
            TcpClient client = default(TcpClient);

            try {
                server.Start();
                Console.WriteLine("Server started on port " + port);
            }
            catch (Exception ex) {
                Console.WriteLine("Failed to start the server on port " + port + " reason: " + ex.ToString());
                Console.WriteLine("Pess a key to exit");
                Console.Read();
            }

            while (true) {
                client = server.AcceptTcpClient();

                byte[] recivedBuffer = new byte[100];

                NetworkStream stream = client.GetStream();

                stream.Read(recivedBuffer, 0, recivedBuffer.Length);

                string msg = Encoding.ASCII.GetString(recivedBuffer, 0, recivedBuffer.Length);

                Console.WriteLine(msg);



            }
        }
    }
}
