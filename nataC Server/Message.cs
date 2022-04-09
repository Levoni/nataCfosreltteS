using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace nataC_Server
{
   class Message
   {
      private Socket messageSoc;
      private List<Socket> chatList;
      public Message(Socket s,List<Socket> chat)
      {
         messageSoc = s;
         chatList = chat;

      }
      public void Listener()
      {
         byte[] bytes = new byte[1024];
         bytes = Encode("##SERVER##:CHAT:Welcome to nataC fo sreltteS");
         messageSoc.Send(bytes);
         while (true)
         {
            bytes = new byte[1024];
            int NumBytes;
            try
            {
               NumBytes = messageSoc.Receive(bytes);
               for (int i = 0; i < chatList.Count; i++)
               {
                  chatList[i].Send(bytes);
               }
            }
            catch (SocketException e)
            {
               
            }
         }
      }
      public byte[] Encode(string command)
      {
         byte[] bytes = new byte[1024];
         bytes = ASCIIEncoding.ASCII.GetBytes(command);
         return bytes;
      }
      public string Decode(byte[] b, int numBytes)
      {
         return ASCIIEncoding.ASCII.GetString(b, 0, numBytes);
      }
   }
}

//4 methods