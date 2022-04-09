using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using nataC_fo_sreltteS;
using System.Threading;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ServerTestProject
{
   [TestClass]
   public class ServerTest
   {
      private Process server;

      private void StartServer()
      {
         try
         {
            server = Process.Start(@"../../../nataC Server\\bin\\Debug\\nataC Server.exe");
         }
         catch (FileNotFoundException ex)
         {

         }
      }

      private void CloseServer()
      {
         server.CloseMainWindow();
         //server.Kill();
         //server.Close();
      }

      [TestMethod]
      private void serverTests()
      {
         StartServer();
         Assert.IsTrue(Server_workerConnection_DoWork_ConnectionRequestSuccessful());
         CloseServer();

         StartServer();
         Assert.IsTrue(Server_workerChat_DoWork_ChatMessageSentAndReceived());
         CloseServer();

         StartServer();
         Assert.IsTrue(Server_TurnSequence_CorrectMessagesSent());
         CloseServer();
      }

      public bool Server_workerConnection_DoWork_ConnectionRequestSuccessful()
      {
         byte[] buffer = new byte[1024];
         int size = 0;
         bool failed = false;

         Socket soc1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc4 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

         ConnectToServer(soc1, soc2, soc3, soc4);

         size = soc1.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:1:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc2.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:2:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc3.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:3:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc4.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:4:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         return failed;
      }

      public bool Server_workerChat_DoWork_ChatMessageSentAndReceived()
      {
         byte[] buffer = new byte[1024];
         int size = 0;
         bool failed = false;

         const int PORT_NUM = 5764;
         Socket soc1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc4 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

         string IP = Login.GetLocalIPAddress();

         soc1.Connect(IP, PORT_NUM);
         soc1.Send(Encode("UNKNOWN:NAME:" + "test1"));
         //Thread.Sleep(1000);
         soc2.Connect(IP, PORT_NUM);
         soc2.Send(Encode("UNKNOWN:NAME:" + "test2"));
         //Thread.Sleep(1000);
         soc3.Connect(IP, PORT_NUM);
         soc3.Send(Encode("UNKNOWN:NAME:" + "test3"));
         //Thread.Sleep(1000);
         soc4.Connect(IP, PORT_NUM);
         soc4.Send(Encode("UNKNOWN:NAME:" + "test4"));

         size = soc1.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:1:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc2.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:2:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc3.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:3:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         size = soc4.Receive(buffer);
         failed = !("GET:NAME:##SERVER##:SETCOLOR:4:##SERVER##:CHAT:Please wait for players to connect!:" == Decode(buffer, size));

         return failed;
      }

      /*
      [TestMethod]

      public void Server_TurnSequence_Correct()
      {
         byte[] buffer = new byte[1024];
         int size = 0;
         //bool failed = false;

         StartServer();

         Socket soc1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Socket soc4 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

         ConnectToServer(soc1, soc2, soc3, soc4);

         soc1.Receive(buffer);
         soc2.Receive(buffer);
         soc3.Receive(buffer);
         soc4.Receive(buffer);

         Thread.Sleep(5000);

         InitializeGame(soc1, soc2, soc3, soc4);

         CloseServer();
      }
      */

      public bool Server_TurnSequence_CorrectMessagesSent()
      {
         bool failed = false;

         return failed;
      }



      public byte[] Encode(string command)
      {
         byte[] bytes = new byte[2048];
         bytes = ASCIIEncoding.ASCII.GetBytes(command);
         return bytes;
      }

      public string Decode(byte[] b, int numBytes)
      {
         return ASCIIEncoding.ASCII.GetString(b, 0, numBytes);
      }

      private void ConnectToServer(Socket soc1, Socket soc2, Socket soc3, Socket soc4)
      {
         const int PORT_NUM = 5764;

         string IP = Login.GetLocalIPAddress();

         soc1.Connect(IP, PORT_NUM);
         soc1.Send(Encode("UNKNOWN:NAME:" + "test1"));
         //Thread.Sleep(1000);
         soc2.Connect(IP, PORT_NUM);
         soc2.Send(Encode("UNKNOWN:NAME:" + "test2"));
         //Thread.Sleep(1000);
         soc3.Connect(IP, PORT_NUM);
         soc3.Send(Encode("UNKNOWN:NAME:" + "test3"));
         //Thread.Sleep(1000);
         soc4.Connect(IP, PORT_NUM);
         soc4.Send(Encode("UNKNOWN:NAME:" + "test4"));
      }

      /*
      private void InitializeGame(Socket soc1, Socket soc2, Socket soc3, Socket soc4)
      {
         int size = 0;
         byte[] buffer = new byte[2048];

         size = soc1.Receive(buffer);
         Assert.AreEqual("##SERVER##:TURN:", Decode(buffer, size));
      }
      */
   }
}
