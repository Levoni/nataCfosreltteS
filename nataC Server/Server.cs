using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace nataC_Server
{
   public partial class frmServer : Form
   {
      int mapWidth = 16;
      int mapHeight = 16;
      private ServTer[,] TerList;
      private List<Players> playerList = new List<Players>();
      const int PORT = 5764;
      private Socket server;
      private string terType;
      private string rollNumString;
      bool gameOver = false;
      List<Thread> threads;
      private int[] randNums = { 3, 8, 10, 9, 12, 11, 4, 8, 5, 2, 6, 9, 4, 5, 6, 3, 10, 11 };
      Deck devCards;

      public frmServer()
      {
         InitializeComponent();
         workerConnection.WorkerSupportsCancellation = true;
         workerConnection.RunWorkerAsync();
         panel1.Padding = new System.Windows.Forms.Padding(0);
         TerList = new ServTer[mapWidth, mapHeight];
         for (int y = 0; y < mapHeight; y++)
            for (int x = 0; x < mapWidth; x++)
               TerList[x, y] = new ServTer();
         GenerateMap();
         devCards = new Deck();
         workerChat.WorkerSupportsCancellation = true;
         workerTurn.WorkerSupportsCancellation = true;
         threads = new List<Thread>();
      }

      private void frmServer_Load(object sender, EventArgs e)
      {
         btnGenerate.Location = new Point(0, panel1.Size.Height);
         btnStart.Location = new Point(panel1.Size.Width / 2, panel1.Size.Height);
         btnStart.Size = new Size(panel1.Size.Width / 2, (this.Size.Height - panel1.Size.Height - 50));
         btnGenerate.Size = new Size(panel1.Size.Width / 2, (this.Size.Height - panel1.Size.Height - 50));

      }
      private void frmServer_ResizeEnd(object sender, EventArgs e)
      {
         panel1.Controls.Clear();
         if (this.Size.Height > this.Size.Width)
            panel1.Size = new Size((this.Size.Width * 3) / 4, (this.Size.Width * 3) / 4);
         else
            panel1.Size = new Size((this.Size.Height * 3) / 4, (this.Size.Height * 3) / 4);
         for (int y = 0; y < 16; y++)
         {
            for (int x = 0; x < 16; x++)
            {
               ServTer ter = TerList[x, y];
               ter.Size = new Size((panel1.Width / 2 / 2 / 2 / 2), panel1.Height / 2 / 2 / 2 / 2);
               ter.reSizeTer(panel1.Height, panel1.Width);
               ter.Location = new Point(panel1.Location.X +
                  (panel1.Width / 2 / 2 / 2 / 2) * x, panel1.Location.Y +
                  (panel1.Height / 2 / 2 / 2 / 2) * y);
               panel1.Controls.Add(ter);
            }
         }
         btnGenerate.Location = new Point(0, panel1.Size.Height);
         btnStart.Location = new Point(panel1.Size.Width / 2, panel1.Size.Height);
         btnStart.Size = new Size(panel1.Size.Width / 2, (this.Size.Height - panel1.Size.Height - 50));
         btnGenerate.Size = new Size(panel1.Size.Width / 2, (this.Size.Height - panel1.Size.Height - 50));
      }

      private void btnGenerate_Click(object sender, EventArgs e)
      {
         GenerateMap();
         //btnGenerate.MouseClick += btnGenerate_Click;
      }


      private void UpdateMap()
      {
         panel1.Controls.Clear();
         if (this.Size.Height > this.Size.Width)
            panel1.Size = new Size((this.Size.Width * 3) / 4, (this.Size.Width * 3) / 4);
         else
            panel1.Size = new Size((this.Size.Height * 3) / 4, (this.Size.Height * 3) / 4);
         for (int y = 0; y < mapHeight; y++)
         {
            for (int x = 0; x < mapWidth; x++)
            {
               ServTer ter = TerList[x, y];
               ter.Size = new Size((panel1.Width / 2 / 2 / 2 / 2), panel1.Height / 2 / 2 / 2 / 2);
               ter.reSizeTer(panel1.Height, panel1.Width);
               ter.Location = new Point(panel1.Location.X +
                  (panel1.Width / 2 / 2 / 2 / 2) * x, panel1.Location.Y +
                  (panel1.Height / 2 / 2 / 2 / 2) * y);
               panel1.Controls.Add(ter);
            }
         }

         //Byte[] tileInfo = new Byte[1024];  ???

      }

      public string GenerateMapTest()
      {
         GenerateMap();
         return terType + ";" + rollNumString;
      }

      private void GenerateMap()
      {
         terType = "";
         Random randNumber = new Random();

         int numArrayIndex = 0;
         List<int> type = GenerateTerTypeList(mapHeight * mapWidth);
         for (int y = 0; y < mapWidth; y++)
            for (int x = 0; x < mapHeight; x++)
            {
               int terTypeNum = randNumber.Next(0, type.Count - 1);
               if (type[terTypeNum] == 0)
               {
                  TerList[y, x].CreateResource(type[terTypeNum], 0, ref terType);
                  type.RemoveAt(terTypeNum);
               }
               else
               {
                  TerList[y, x].CreateResource(type[terTypeNum], randNums[numArrayIndex], ref terType);
                  numArrayIndex = ++numArrayIndex % randNums.Count();
                  type.RemoveAt(terTypeNum);
               }
            }
         //Debug message box with all territories as int displayed
         createRollString();
         //MessageBox.Show(rollNumString);
         UpdateMap();
      }

      /// <summary>
      /// Generates a list of instances for all types of territories.
      /// </summary>
      private List<int> GenerateTerTypeList(int totalTiles)
      {
         List<int> types = new List<int>();
         float loopTimes = totalTiles / 25f;
         for (int i = 0; i < loopTimes; i++)
         {
            for (int j = 0; j < 5; j++)
            {
               types.Add(1);
               types.Add(2);
            }
            for (int j = 0; j < 4; j++)
            {
               types.Add(3);
               types.Add(4);
            }
            for (int j = 0; j < 7; j++)
            {
               types.Add(0);
            }
         }

         return types;
      }

      //Server connections OUR Protocol is usign colons : ZACH:MSG:HELLO World (Player):(Command):(Data)
      private void workerConnection_DoWork(object sender, DoWorkEventArgs e)
      {
         server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         server.Bind(new IPEndPoint(IPAddress.Any, PORT));
         server.Listen(0);
         while (!workerConnection.CancellationPending && playerList.Count < 4)
         {
            byte[] bytes = new byte[1024];
            try
            {
               Socket soc = server.Accept();
               soc.Send(Encode("GET:NAME:"));
               int numBytes = soc.Receive(bytes);
               string command = Decode(bytes, numBytes);
               commandList(ref command);
               // MessageBox.Show(command);//Debug
               Players p = new Players(command, soc);
               playerList.Add(p);
               //MessageBox.Show(playerList.Count.ToString());//Debug
               int temp = playerList.Count;
               soc.Send(Encode("##SERVER##:SETCOLOR:" + temp + ":"));
               //Thread.Sleep(5000);
               soc.Send(Encode("##SERVER##:CHAT:Please wait for players to connect!:"));
            }
            catch (SocketException ex)
            {
               //this.Close();
            }

         }
      }

      private void btnStart_Click(object sender, EventArgs e)
      {

         //change to 3
         if (playerList.Count >= 1)
         {
            try
            {
               workerConnection.CancelAsync();
               server.Close();
            }
            catch (Exception ex)
            {
               Console.Out.Write(ex);
            }
            workerChat.RunWorkerAsync();
            try
            {
               string s = "";
               for (int i = 0; i < playerList.Count; i++)
               {
                  s += (playerList[i].Name);

                  if (i < playerList.Count - 1)
                  {
                     s += ',';
                  }
               }
               for (int i = 0; i < playerList.Count; i++)
               {
                  playerList[i].soc.Send(Encode("##SERVER##:START:"));
               }
               for (int i = 0; i < playerList.Count; i++)
               {
                  playerList[i].soc.Send(Encode("##SERVER##:MAPUPDATE:" + terType + ":"));
               }
               for (int i = 0; i < playerList.Count; i++)
               {
                  playerList[i].soc.Send(Encode("##SERVER##:MAPROLL:" + rollNumString + ":"));
               }
               NumOfPlayersUpdate();
               for (int i = 0; i < playerList.Count; i++)
               {
                  playerList[i].soc.Send(Encode("##SERVER##:PLAYERNAMES:" + s + ":"));
               }


               workerTurn.RunWorkerAsync();

               btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
               this.Close();
            }
            // Runs the Chat Service
            //Update all clients about each other...
         }
      }

      private void InitialCities()
      {
         if (playerList.Count >= 1)
         {
            MakeCity(0, 0, 1);
            for (int i = 0; i < playerList.Count; i++)
               singleTileUpdate(0, 0);
         }
         if (playerList.Count >= 2)
         {
            MakeCity(0, 15, 2);
            for (int i = 0; i < playerList.Count; i++)
               singleTileUpdate(0, 15);
         }
         if (playerList.Count >= 3)
         {
            MakeCity(15, 0, 3);
            for (int i = 0; i < playerList.Count; i++)
               singleTileUpdate(15, 0);
         }
         if (playerList.Count >= 4)
         {
            MakeCity(15, 15, 4);
            for (int i = 0; i < playerList.Count; i++)
               singleTileUpdate(15, 15);
         }
      }

      private void MakeCity(int x, int y, int playerNum)
      {
         TerList[x, y].owner = playerNum;
         TerList[x, y].hasCity = true;
      }
      private void createRollString()
      {
         rollNumString = "";
         for (int j = 0; j < mapWidth; j++)
         {
            for (int k = 0; k < mapHeight; k++)
            {
               TerList[j, k].addrolltotext(ref rollNumString);
               rollNumString += ",";
            }
         }
      }

      private void singleTileUpdate(int x, int y)
      {
         try
         {
            int temp;
            if (TerList[x, y].hasCity)
               temp = 1;
            else
               temp = 0;
            for (int i = 0; i < playerList.Count; i++)
               playerList[i].soc.Send(Encode("##SERVER##:SINGLETILEUPDATE:" + x + "," + y + "," + TerList[x, y].owner + "," + temp + ":"));
         }
         catch (Exception e)
         {
            this.Close();
         }
      }

      private void NumOfPlayersUpdate()
      {
         try
         {
            for (int i = 0; i < playerList.Count; i++)
            {
               playerList[i].soc.Send(Encode("##SERVER##:NUMOFPLAYERS:" + playerList.Count + ":"));
            }
         }
         catch (Exception e)
         {
            this.Close();
         }
      }



      private void ResourceUpdate(string tempRoll)
      {
         int curRoll = int.Parse(tempRoll);
         for (int i = 0; i < 16; i++)
         {
            for (int j = 0; j < 16; j++)
               if (TerList[i, j].owner > 0)
                  if (playerList[TerList[i, j].owner - 1].AddResources(TerList[i, j].getResourceType(), TerList[i, j].rollNum == curRoll, TerList[i, j].hasCity))
                  {
                     if (i != 15)
                        playerList[TerList[i, j].owner - 1].AddResource(TerList[i + 1, j].getResourceType(), TerList[i + 1, j].rollNum == curRoll);
                     if (i != 0)
                        playerList[TerList[i, j].owner - 1].AddResource(TerList[i - 1, j].getResourceType(), TerList[i - 1, j].rollNum == curRoll);
                     if (j != 15)
                        playerList[TerList[i, j].owner - 1].AddResource(TerList[i, j + 1].getResourceType(), TerList[i, j + 1].rollNum == curRoll);
                     if (j != 0)
                        playerList[TerList[i, j].owner - 1].AddResource(TerList[i, j - 1].getResourceType(), TerList[i, j - 1].rollNum == curRoll);
                  }
         }
         ResourcePlayerUpdate();
      }

      private void ResourcePlayerUpdate()
      {
         try
         {
            for (int p = 0; p < playerList.Count; p++)
            {
               string temp = "";
               for (int i = 0; i < playerList.Count; i++)
               {
                  temp += playerList[i].food.ToString() + "," + playerList[i].stone.ToString() + "," + playerList[i].wood.ToString() + "," + playerList[i].animal.ToString() + "," + playerList[i].VP.ToString() + "," + playerList[i].GetTotalDevCards() + ",";
               }
               //MessageBox.Show(temp);
               playerList[p].soc.Send(Encode("##SERVER##:RESOURCEUPDATE:" + temp + ":"));
            }
         }
         catch (Exception e)
         {
            this.Close();
         }
      }

      //used for packaging and unpackaging bytes
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

      private void commandList(ref string command)
      {
         string[] commands = command.Split(':');
         int commandCount = 0;
         while (commandCount + 1 < commands.Length - 1)
         {
            if (commands[commandCount] == "UNKNOWN")//Used for initial player setup
            {
               commandCount++;
               if (commands[commandCount] == "NAME")
               {
                  commandCount++;
                  command = commands[commandCount];
                  commandCount++;
               }
               else if (commands[commandCount] == "ROLL")
               {
                  commandCount++;
                  ResourceUpdate(commands[commandCount]); //myRoll
                  commandCount++;
               }
               else if (commands[commandCount] == "TILECHANGE")
               {
                  commandCount++;
                  changeTileOnServer(commands[commandCount]); //myRoll
                  commandCount++;
               }
               else if (commands[commandCount] == "PROPOSAL")
               {
                  commandCount++;
                  ProcessTradeRequest(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "ACCEPTANCE")
               {
                  commandCount++;
                  ResultOfTradeRequest(commands[commandCount]); //yes, or no then info
                  commandCount++;
               }
               else if (commands[commandCount] == "MINUSRESOURCES")
               {
                  commandCount++;
                  MinusResources(commands[commandCount]); //yes, or no then info
                  commandCount++;
               }
               else if (commands[commandCount] == "STARTCITYRESOURCE")
               {
                  commandCount++;
                  singleTileResourceAdd(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "VPCARDUPDATE")
               {
                  commandCount++;
                  VPSet(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "USEDEVCARD")
               {
                  commandCount++;
                  UseDevCard(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "BUYDEVCARD")
               {
                  commandCount++;
                  BuyDevCard(commands[commandCount]);
                  commandCount++;
               }
               else
                  break;
            }
            else if (commands[commandCount++] == "SETUPRESOURCES")
            {
               commandCount++;
               SetupResources(commands[commandCount]);
            }
         }
      }

      private void BuyDevCard(string command)
      {
         Players currPlayer = playerList[Int32.Parse(command) - 1];
         if (currPlayer.CanBuyDevCard() && devCards.GetCurrentDeckSize() > 0)
         {
            string type = "THIS IS NOT WORKING";
            Card currCard = devCards.GetTopCard();
            currPlayer.MinusResources("devCard");
            Card.Type cardType = currCard.CardType;
            switch (cardType)
            {
               case Card.Type.KNIGHT:
                  type = "KNIGHT";
                  break;
               case Card.Type.MONOPOLY:
                  type = "MONOPOLY";
                  break;
               case Card.Type.TERRITORY:
                  type = "TERRITORY";
                  break;
               case Card.Type.VICTORY:
                  type = "VP";
                  break;
               case Card.Type.YEAR_OF_PLENTY:
                  type = "YOP";
                  break;
            }
            currPlayer.BuyDevCard(type);
            currPlayer.soc.Send(Encode("##SERVER##:DEVCARD:" + type));
            ResourcePlayerUpdate();
         }
         else
            currPlayer.soc.Send(Encode("##SERVER##:DEVCARD:NONE"));
      }

      private void UseDevCard(string command)
      {
         string[] info = command.Split(',');
         int playerNum = Int32.Parse(info[1]);

         if (info[0].Equals("TERRITORY"))
         {
            playerList[playerNum - 1].UseDevCard(info[0]);
            ResourcePlayerUpdate();
         }
         else if (info[0].Equals("YOP"))
         {
            Players p = playerList[playerNum - 1];
            p.AddResource(info[2], 2);
            playerList[playerNum - 1].UseDevCard(info[0]);
            ResourcePlayerUpdate();
         }
         else if (info[0].Equals("MONOPOLY"))
         {
            playerList[playerNum - 1].UseDevCard(info[0]);
            HandleMonopoly(playerNum, info[2]);
         }
         else if (info[0].Equals("KNIGHT"))
         {
            int opponentPlayer = Int32.Parse(info[2]);
            playerList[playerNum - 1].UseDevCard(info[0]);
            HandleKnight(playerNum, opponentPlayer);
         }
         else if (info[0].Equals("VP"))
         {
            Players p = playerList[playerNum - 1];
            p.VP++;
            playerList[playerNum - 1].UseDevCard(info[0]);
            ResourcePlayerUpdate();
         }
      }

      private void HandleMonopoly(int currPlayer, string resource)
      {
         Players p = playerList[currPlayer - 1];
         int stolen = 0;

         for (int i = 0; i < playerList.Count; i++)
         {
            if (i != currPlayer - 1)
               stolen += playerList[i].StealResource(resource);
         }

         p.AddResource(resource, stolen);
         ResourcePlayerUpdate();
      }

      private void HandleKnight(int currPlayer, int oppPlayer)
      {
         Players p1 = playerList[currPlayer - 1];
         Players p2 = playerList[oppPlayer - 1];
         string resource = p2.StealRandomResource();
         string[] resourceList = resource.Split(',');
         int numResources = resourceList.Count() - 1;

         for (int i = 0; i < numResources; i++)
         {
            p1.AddResource(resourceList[1], 1);
         }

         ResourcePlayerUpdate();
      }

      private void VPSet(string command)
      {
         string[] info = command.Split(',');
         for (int i = 0; i < playerList.Count; i++)
            playerList[i].VP = int.Parse(info[i]);
         VPSend(command);
      }

      private void VPSend(string sendString)
      {
         for (int i = 0; i < playerList.Count; i++)
            playerList[i].soc.Send(Encode("##SERVER##:VPUPDATE:" + sendString + ":"));
      }

      private void SetupResources(string command)
      {
         string[] s = command.Split();
      }

      private void singleTileResourceAdd(string command)
      {
         string[] info = command.Split(',');
         int temp = TerList[int.Parse(info[0]), int.Parse(info[1])].getResourceType();
         playerList[int.Parse(info[2]) - 1].AddResource(temp, true, true);
         if (int.Parse(info[0]) != 15)
            playerList[int.Parse(info[2]) - 1].AddResource(TerList[int.Parse(info[0]) + 1, int.Parse(info[1])].getResourceType(), true);
         if (int.Parse(info[0]) != 0)
            playerList[int.Parse(info[2]) - 1].AddResource(TerList[int.Parse(info[0]) - 1, int.Parse(info[1])].getResourceType(), true);
         if (int.Parse(info[1]) != 15)
            playerList[int.Parse(info[2]) - 1].AddResource(TerList[int.Parse(info[0]), int.Parse(info[1]) + 1].getResourceType(), true);
         if (int.Parse(info[1]) != 0)
            playerList[int.Parse(info[2]) - 1].AddResource(TerList[int.Parse(info[0]), int.Parse(info[1]) - 1].getResourceType(), true);

         ResourcePlayerUpdate();
      }

      private void MinusResources(string command)
      {
         string[] info = command.Split(',');
         playerList[int.Parse(info[0]) - 1].MinusResources(info[1]);
         ResourcePlayerUpdate();
      }

      private void changeTileOnServer(string command)
      {
         string[] tileInfo = command.Split(',');
         int x = int.Parse(tileInfo[0]);
         int y = int.Parse(tileInfo[1]);
         TerList[x, y].owner = int.Parse(tileInfo[2]);
         if (tileInfo[3] == "True")
         {
            TerList[x, y].hasCity = true;
            playerList[int.Parse(tileInfo[2]) - 1].VP++;
         }
         else
            TerList[x, y].hasCity = false;
         singleTileUpdate(x, y);
      }

      private void ResultOfTradeRequest(string command)
      {
         string[] acceptanceInfo = command.Split(',');
         string result = acceptanceInfo[0];
         int a = int.Parse(acceptanceInfo[1]);
         int f = int.Parse(acceptanceInfo[2]);
         int s = int.Parse(acceptanceInfo[3]);
         int w = int.Parse(acceptanceInfo[4]);
         int recip = int.Parse(acceptanceInfo[5]) - 1;
         int OG = int.Parse(acceptanceInfo[6]) - 1;

         playerList[OG].soc.Send(Encode("##SERVER##:ACCEPTANCE:" + result + "," + recip + ":"));
         if (result == "accepted")
         {
            playerList[OG].animal = playerList[OG].animal - a;
            playerList[OG].food = playerList[OG].food - f;
            playerList[OG].stone = playerList[OG].stone - s;
            playerList[OG].wood = playerList[OG].wood - w;

            playerList[recip].animal = playerList[recip].animal + a;
            playerList[recip].food = playerList[recip].food + f;
            playerList[recip].stone = playerList[recip].stone + s;
            playerList[recip].wood = playerList[recip].wood + w;
            ResourcePlayerUpdate();
         }
      }
      private void ProcessTradeRequest(string command) //not sure what I pass/where I call it...
      {
         string[] tradeInfo = command.Split(',');
         int recip = int.Parse(tradeInfo[4]) - 1;
         if (recip >= 0)
         {
            playerList[recip].soc.Send(Encode("##SERVER##:PROPOSAL:" + command + ":"));
            byte[] b = new byte[1024];
            int numBytes = playerList[recip].soc.Receive(b);
            string reply = Decode(b, numBytes);
            commandList(ref reply);
         }
         else //bank trade request
         {
            int a = int.Parse(tradeInfo[0]);
            int f = int.Parse(tradeInfo[1]);
            int s = int.Parse(tradeInfo[2]);
            int w = int.Parse(tradeInfo[3]);
            int OG = int.Parse(tradeInfo[5]) - 1;

            playerList[OG].animal = playerList[OG].animal - a;
            playerList[OG].food = playerList[OG].food - f;
            playerList[OG].stone = playerList[OG].stone - s;
            playerList[OG].wood = playerList[OG].wood - w;
            ResourcePlayerUpdate();
         }
      }

      private void workerChat_DoWork(object sender, DoWorkEventArgs e)
      {
         try
         {
            Socket chatServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            chatServer.Bind(new IPEndPoint(IPAddress.Any, PORT));
            chatServer.Listen(0);
            List<Socket> chatList = new List<Socket>();

            for (int i = 0; i < playerList.Count; i++)
            {
               Socket playerChat = chatServer.Accept();
               chatList.Add(playerChat);
               Message chat = new Message(playerChat, chatList);
               Thread thread = new Thread(new ThreadStart(chat.Listener));
               thread.Start();
               threads.Add(thread);
            }
         }
         catch (Exception ex)
         {
            this.Close();
         }
      }

      private void GameOver(string winner)
      {
         try
         {
            for (int i = 0; i < playerList.Count; i++)
               playerList[i].soc.Send(Encode("##SERVER##:GAMEOVER:" + winner + ":"));
            Application.Exit();
         }
         catch (Exception e)
         {
            this.Close();
         }
      }


      private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
      {
         //DialogResult dr = MessageBox.Show("Do you really want to exit?", "End Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         //if (dr == DialogResult.Yes)
         workerChat.CancelAsync();
         workerConnection.CancelAsync();
         workerTurn.CancelAsync();
         foreach (Thread t in threads)
         {
            t.Abort();
         }
         for (int i = 0; i < playerList.Count; i++)
         {
            try
            {
               playerList[i].soc.Send(Encode("##SERVER##:CLOSING:"));
            }
            catch (Exception ex) { }
         }
         Application.Exit();
      }

      private void workerTurn_DoWork(object sender, DoWorkEventArgs e)
      {
         try
         {
            byte[] b;
            for (int i = 0; i < playerList.Count; i++)
            {
               b = new byte[2048];
               playerList[i].soc.Send(Encode("##SERVER##:TURN:"));
               //try
               //{
               string temp = Decode(b, playerList[i].soc.Receive(b));
               commandList(ref temp);
               //}
               //catch (SocketException ex)
               //{
               //   playerList[i].soc.Close();
               //}
            }
            for (int i = playerList.Count - 1; i >= 0; i--)
            {
               //playerList[i].soc.Send(Encode("##SERVER##:TURN:"));
               b = new byte[2048];
               playerList[i].soc.Send(Encode("##SERVER##:TURN:"));
               string temp = Decode(b, playerList[i].soc.Receive(b));
               commandList(ref temp);
            }
            while (!gameOver)
            {
               for (int i = 0; i < playerList.Count; i++)
               {
                  playerList[i].soc.Send(Encode("##SERVER##:CHAT:It is now your turn:"));
                  playerList[i].soc.Send(Encode("##SERVER##:TURN:"));

                  string command = "";
                  while (command != "ENDTURN")
                  {
                     command = "";
                     bool moreData = true;
                     //
                     while (moreData)
                     {
                        b = new byte[1024];
                        int numBytes = playerList[i].soc.Receive(b);
                        if (numBytes < 1024)
                           moreData = false;
                        command += Decode(b, numBytes); //where message is recieved
                     }
                     //
                     if (command == "ENDGAME")
                     {

                        GameOver(playerList[i].Name);
                        return;
                     }
                     commandList(ref command);
                  }
                  //MessageBox.Show(command);
               }
            }
         }
         catch (Exception ex)
         {
            Invoke((MethodInvoker)delegate () { Close(); });
            //this.Close();
         }
      }
   }

}//30 methods