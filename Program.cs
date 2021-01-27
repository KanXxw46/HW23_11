using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Hw23._11._20
{
    class Program
    {
        private const int EhcoPort = 3333;
        static void Main(string[] args)
        {
            Console.Write("Логин: ");
            
            string username = Console.ReadLine();
            
            Console.WriteLine("<-----Loged in----->");
            
            try
            {
               
                TcpClient eClient = new TcpClient("127.0.0.1", EhcoPort);


               
                StreamReader readerStream = new StreamReader(eClient.GetStream());
                NetworkStream writerStreem = eClient.GetStream();
                string datatoSend;
                datatoSend = username;
                datatoSend += "\r\n";
               
                byte[] data = Encoding.ASCII.GetBytes(datatoSend);


                writerStreem.Write(data, 0, data.Length);

                while (true)
                {
                    Console.Write(username + " : ");
                   
                    datatoSend = Console.ReadLine();
                    datatoSend += "\r\n";
                    data = Encoding.ASCII.GetBytes(datatoSend);
                    writerStreem.Write(data, 0, data.Length);
                    
                    if (datatoSend.IndexOf("Quit") > -1)
                        break;
                    string returndata;
                  
                    returndata = readerStream.ReadLine();
                    Console.WriteLine("Server" + returndata);
                }
                eClient.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("server: " + exc);
                Console.ReadLine();


            }
         }
    

    }
}
    

