//--------------------------------------------------------------------
// client.cs is a c# form that the user sees after the game is started
// with te appropriate number of players. the form gets its data from
// the server about the setup of the map, and the player resourcer
// the form is not able to be closed by Alt+F4 or clicking the x 
// if the user wants to exit they must press the exit button.
// a player can only do certain avtions if it is their turn and they
// have the required resources to perform that action
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace nataC_fo_sreltteS
{

   public partial class Client : Form
   {
      public static bool purchaseTerr, purchaseCity;
      private int playerCount;
      public Players[] pList = new Players[4];
      public static int playerNum;
      private int initialCityCount = 0;
      private string initialCityInfoOne;
      private string initialCityInfoTwo;
      Trade TradeForm;
      private int mostTer = 0;
      private int mostCity = 0;
      private int mostVP = 0;
      private int mostResource = 0;
      private bool usingTerrCard = false;
      public string playerName { get; set; }
      Socket soc;
      byte[] bytes;
      IPAddress IP;
      Socket socChat;
      bool isTurn = false;
      bool setUp = true;
      int startTers = 0;
      System.Media.SoundPlayer turnSound = new System.Media.SoundPlayer(nataC_fo_sreltteS.Properties.Resources.Tone);

      Territory[,] mapInfo = new Territory[16, 16];
      //--------------------------------------------
      private delegate void appendChat(string m);
      private appendChat myDelegate;
      //-------------------------------------------
      private delegate void cmList(string m);
      private cmList mySecondDel;
      //--------------------------------------------
      public Client()
      {
         InitializeComponent();
         //Server connection Type
         soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         /////////////////////////

         //Hide the Main form untll user logins successfully
         Login login = new Login(this);
         login.Show();
         WorkerChat.WorkerSupportsCancellation = true;

         ///////////////////////////////////////////////////
         myDelegate = new appendChat(addToOutput);
         mySecondDel = new cmList(commandList);
         ///////////////////////////////////////////////////

         btnRollDice.Enabled = false;
         btnEndTurn.Enabled = false;
         btnTrade.Enabled = false;
      }
      //--------------------------------------------------------------------
      //
      //--------------------------------------------------------------------
      public void Client_Load(object sender, EventArgs e)
      {
         this.Hide();
      }
      #region createClient() used to start the client creation
      public void createClient()
      {
         Size mapSize = new Size(Map.Size.Width, this.Size.Height);
         Map.Size = mapSize;
         for (int y = 0; y < 16; y++)
         {
            for (int x = 0; x < 16; x++)
            {
               Territory ter = new Territory(0, x, y, MapImageClick, CheckNabor); //0 for now
               float width = Map.Size.Width / 16;
               float height = Map.Size.Height / 16;
               ter.Size = new Size((int)width, (int)height);
               ter.ResizeTer();
               mapInfo[x, y] = ter;
               Map.Controls.Add(ter);
            }
         }
         for (int i = 0; i < 4; i++)
         {
            pList[i] = new Players();
            pList[i].UpdateResource();
         }

         panPlayer1.Controls.Add(pList[0]);
         panPlayer1.BackColor = System.Drawing.Color.Gold;
         panPlayer2.Controls.Add(pList[1]);
         panPlayer2.BackColor = System.Drawing.Color.Red;
         panPlayer4.Controls.Add(pList[2]);
         panPlayer4.BackColor = System.Drawing.Color.Lime;
         panPlayer3.Controls.Add(pList[3]);
         panPlayer3.BackColor = System.Drawing.Color.Aqua;

         btnSend.Enabled = false;

         Rectangle resolution = Screen.PrimaryScreen.Bounds;

         if (resolution.Width - resolution.Height <= resolution.Width / 3) // Optimal for projectors 4:3 ration
         {
            //resolution.Width = 1200; //for testing on 1600 by 900 display 

            // SIZES
            Map.Size = new Size(resolution.Height * 8 / 10, resolution.Height * 8 / 10);
            btnSend.Size = new Size(btnSend.Width, btnSend.Height);
            btnExit.Size = new Size((resolution.Width - Map.Width), btnSend.Height);
            btnRollDice.Size = new Size((resolution.Width - Map.Width) / 3, btnSend.Height);
            btnEndTurn.Size = new Size((resolution.Width - Map.Width) / 3, btnSend.Height);
            btnTrade.Size = new Size((resolution.Width - Map.Width) / 3, btnSend.Height);
            txtMessage.Size = new Size(Map.Width - btnSend.Width, btnSend.Height);
            txtOutPut.Size = new Size(Map.Width, resolution.Height - Map.Height - btnSend.Height);
            panPlayer1.Size = new Size(resolution.Width - Map.Width, (resolution.Height - btnTrade.Height - picD1.Height - btnExit.Height - picDeck.Height) / 4);
            panPlayer2.Size = new Size(resolution.Width - Map.Width, (resolution.Height - btnTrade.Height - picD1.Height - btnExit.Height - picDeck.Height) / 4);
            panPlayer3.Size = new Size(resolution.Width - Map.Width, (resolution.Height - btnTrade.Height - picD1.Height - btnExit.Height - picDeck.Height) / 4);
            panPlayer4.Size = new Size(resolution.Width - Map.Width, (resolution.Height - btnTrade.Height - picD1.Height - btnExit.Height - picDeck.Height) / 4);

            // LOCATIONS
            Map.Location = new Point(0, 0);
            picD1.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 2 - picD1.Width, btnTrade.Height);
            picD2.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 2, btnTrade.Height);
            picDeck.Location = new Point(Map.Width, btnTrade.Height + picD1.Height);
            picKnightCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 6, btnTrade.Height + picD1.Height);
            picVictoryCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 3, btnTrade.Height + picD1.Height);
            picTerritoryCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 2, btnTrade.Height + picD1.Height);
            picMonopolyCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 3 * 2, btnTrade.Height + picD1.Height);
            picPlentyCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 6 * 5, btnTrade.Height + picD1.Height);
            lblKnightNum.Location = picKnightCard.Location;
            lblVicotryNum.Location = picVictoryCard.Location;
            lblTerritoryNum.Location = picTerritoryCard.Location;
            lblMonopolyNum.Location = picMonopolyCard.Location;
            lblPlentyNum.Location = picPlentyCard.Location;
            panPlayer1.Location = new Point(Map.Width, resolution.Height - btnExit.Height - panPlayer4.Height - panPlayer3.Height - panPlayer2.Height - panPlayer1.Height);
            panPlayer2.Location = new Point(Map.Width, resolution.Height - btnExit.Height - panPlayer4.Height - panPlayer3.Height - panPlayer2.Height);
            panPlayer3.Location = new Point(Map.Width, resolution.Height - btnExit.Height - panPlayer4.Height - panPlayer3.Height);
            panPlayer4.Location = new Point(Map.Width, resolution.Height - btnExit.Height - panPlayer4.Height);
            btnSend.Location = new Point(0, resolution.Height - btnSend.Height);
            btnTrade.Location = new Point(Map.Width, 0);
            btnRollDice.Location = new Point(Map.Width + btnTrade.Width, 0);
            btnExit.Location = new Point(Map.Width, resolution.Height - btnExit.Height);
            btnEndTurn.Location = new Point(Map.Width + btnTrade.Width + btnRollDice.Width, 0);
            txtMessage.Location = new Point(btnSend.Width, resolution.Height - txtMessage.Height);
            txtOutPut.Location = new Point(0, resolution.Height - txtOutPut.Height - txtMessage.Height);
         }
         else // normal screens 16:9 ratio
         {
            btnExit.Width = (resolution.Size.Width - Map.Size.Width);
            btnRollDice.Width = (resolution.Size.Width - Map.Size.Width) / 3;
            btnTrade.Width = (resolution.Size.Width - Map.Size.Width) / 3;
            btnTrade.Location = new Point(Map.Width, 0);
            btnRollDice.Location = new Point(Map.Width + btnTrade.Width, 0);
            btnExit.Location = new Point((resolution.Size.Width - Map.Size.Width) / 3 + Map.Size.Width - btnExit.Width);
            panPlayer1.Width = (resolution.Size.Width - Map.Size.Width) / 2;
            panPlayer1.Location = new Point(Map.Size.Width, btnExit.Location.Y + btnExit.Height);
            panPlayer2.Width = (resolution.Size.Width - Map.Size.Width) / 2;
            panPlayer2.Location = new Point(Map.Size.Width + panPlayer1.Width, panPlayer1.Location.Y);
            panPlayer3.Width = (resolution.Size.Width - Map.Size.Width) / 2;
            panPlayer3.Location = new Point(Map.Size.Width, panPlayer1.Location.Y + panPlayer1.Size.Height);
            picD1.Left = btnRollDice.Left;
            picD2.Left = picD1.Right + 5;
            picD1.Top = btnRollDice.Bottom + 5;
            picD2.Top = picD1.Top;
            picDeck.Location = new Point(Map.Width, btnTrade.Height + picD1.Height + 10);
            picKnightCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 6, btnTrade.Height + picD1.Height + 10);
            picVictoryCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 3, btnTrade.Height + picD1.Height + 10);
            picTerritoryCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 2, btnTrade.Height + picD1.Height + 10);
            picMonopolyCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 3 * 2, btnTrade.Height + picD1.Height + 10);
            picPlentyCard.Location = new Point(Map.Width + (resolution.Width - Map.Width) / 6 * 5, btnTrade.Height + picD1.Height + 10);
            lblKnightNum.Location = picKnightCard.Location;
            lblVicotryNum.Location = picVictoryCard.Location;
            lblTerritoryNum.Location = picTerritoryCard.Location;
            lblMonopolyNum.Location = picMonopolyCard.Location;
            lblPlentyNum.Location = picPlentyCard.Location;
            panPlayer4.Width = (resolution.Size.Width - Map.Size.Width) / 2;
            panPlayer4.Location = new Point(Map.Size.Width + panPlayer3.Width, panPlayer3.Location.Y);
            btnSend.Location = new Point(Map.Size.Width, resolution.Size.Height - btnSend.Height);
            txtMessage.Width = resolution.Width - Map.Size.Width - btnSend.Size.Width;
            txtMessage.Location = new Point(Map.Size.Width + btnSend.Size.Width, resolution.Size.Height - txtMessage.Size.Height);
            txtOutPut.Width = resolution.Width - Map.Size.Width;
            txtOutPut.Size = new Size(txtOutPut.Size.Width, (txtMessage.Location.Y - (panPlayer3.Location.Y + panPlayer3.Size.Height)) / 2);
            txtOutPut.Location = new Point(Map.Size.Width, txtMessage.Location.Y - txtOutPut.Size.Height);
            btnExit.Location = new Point(Map.Width, resolution.Height - btnSend.Height - txtOutPut.Height - btnExit.Height);
            btnEndTurn.Location = new Point(Map.Width + btnTrade.Width + btnRollDice.Width, 0);
            btnEndTurn.Size = new Size((resolution.Width - Map.Width) / 3, btnEndTurn.Height);

            panPlayer3.Location = new Point(Map.Width, btnExit.Location.Y - panPlayer3.Height);
            panPlayer4.Location = new Point(Map.Width + panPlayer3.Width, btnExit.Location.Y - panPlayer3.Height);
            panPlayer1.Location = new Point(Map.Width, panPlayer3.Location.Y - panPlayer1.Height);
            panPlayer2.Location = new Point(Map.Width + panPlayer1.Width, panPlayer3.Location.Y - panPlayer1.Height);
         }

         workerMainThread.WorkerSupportsCancellation = true;
         workerMainThread.RunWorkerAsync();
      }
      #endregion
      //--------------------------------------------------------------------
      // this method is the only way a user will be allowed to exit the 
      // application, and before closing the application 							TODO: handle what happens if a player exits. should prompt server to
      //																								take some sort of action/ inform players of game ending.
      //--------------------------------------------------------------------
      private void clExit_Click(object sender, EventArgs e)
      {
         soc.Close();
         if (socChat != null)
            socChat.Close();
         Application.Exit();
      }
      //--------------------------------------------------------------------
      // this method randomly generates two numbers to simulate a dice roll
      // and then calls the displayRoll method to display the result
      //--------------------------------------------------------------------
      private void clRollDice_Click(object sender, EventArgs e)
      {
         Random random = new Random();
         int d1 = random.Next(1, 7);
         int d2 = random.Next(1, 7);
         displayRoll(d1, d2);
         int myR = d1 + d2;
         string myRoll = myR.ToString();
         soc.Send(Encode("UNKNOWN:ROLL:" + myRoll));
         // soc.Send 
         btnRollDice.Enabled = false;
         btnEndTurn.Enabled = true;
      }
      //--------------------------------------------------------------------
      // this method displays the dice of a given roll in the picture boxes
      //--------------------------------------------------------------------
      private void displayRoll(int roll1, int roll2)
      {
         int mySize = picD1.Height;
         Bitmap temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._1rb); //gets base image
         Bitmap ONE = new Bitmap(temp, mySize, mySize); //Resizes base image
         temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._2rb);
         Bitmap TWO = new Bitmap(temp, mySize, mySize);
         temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._3rb);
         Bitmap THREE = new Bitmap(temp, mySize, mySize);
         temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._4rb);
         Bitmap FOUR = new Bitmap(temp, mySize, mySize);
         temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._5rb);
         Bitmap FIVE = new Bitmap(temp, mySize, mySize);
         temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources._6rb);
         Bitmap SIX = new Bitmap(temp, mySize, mySize);


         if (roll1 == 1)
            picD1.Image = ONE;
         if (roll1 == 2)
            picD1.Image = TWO;
         if (roll1 == 3)
            picD1.Image = THREE;
         if (roll1 == 4)
            picD1.Image = FOUR;
         if (roll1 == 5)
            picD1.Image = FIVE;
         if (roll1 == 6)
            picD1.Image = SIX;
         if (roll2 == 1)
            picD2.Image = ONE;
         if (roll2 == 2)
            picD2.Image = TWO;
         if (roll2 == 3)
            picD2.Image = THREE;
         if (roll2 == 4)
            picD2.Image = FOUR;
         if (roll2 == 5)
            picD2.Image = FIVE;
         if (roll2 == 6)
            picD2.Image = SIX;
      }
      //--------------------------------------------------------------------
      // this method brings up the trade form and sends the active player's
      // information to the trade form.
      //--------------------------------------------------------------------
      private void btnTrade_Click(object sender, EventArgs e)
      {
         if (TradeForm == null)
            TradeForm = new Trade(this, soc);
         TradeForm.GetPlayerInfo(pList);
         TradeForm.ReOpen();
         TradeForm.ReEnableTrade();
         TradeForm.Show();
         btnTrade.Enabled = false;
      }
      //--------------------------------------------------------------------
      // this section and below is all methods dealing with the server
      //--------------------------------------------------------------------

      //--------------------------------------------------------------------
      //
      //--------------------------------------------------------------------
      public bool testIP(string ip)
      {
         try
         {
            IP = IPAddress.Parse(ip);
            soc.Connect(IP, 5764);
            bytes = new byte[1024];
            //soc.ReceiveTimeout = 10000; //TimeOUT
            int numBytes = soc.Receive(bytes);
            commandList(Decode(bytes, numBytes)); //used to get the the data the server wants
            createClient();
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }
      //--------------------------------------------------------------------
      //
      //--------------------------------------------------------------------
      private byte[] Encode(string command)
      {
         byte[] bytes = new byte[1024];
         bytes = ASCIIEncoding.ASCII.GetBytes(command);
         return bytes;
      }
      //--------------------------------------------------------------------
      //
      //--------------------------------------------------------------------
      private string Decode(byte[] b, int numBytes)
      {
         return ASCIIEncoding.ASCII.GetString(b, 0, numBytes);
      }

      /// <summary>
      /// 
      /// </summary>
      private void ShowInfo()
      {
         for (int i = 0; i < pList.Length; i++)
         {
            if (i == playerNum - 1)
               pList[i].SetMainPlayer(true);
            else
               pList[i].SetMainPlayer(false);
         }
      }


      //--------------------------------------------------------------------
      //
      //--------------------------------------------------------------------
      private void commandList(string command)
      {
         int commandCount = 0;
         string[] commands = command.Split(':');
         while (commandCount + 1 < commands.Length - 1)
         {

            if (commands[commandCount] == "GET")
            {
               commandCount++;
               if (commands[commandCount] == "NAME")
               {
                  commandCount++;
                  soc.Send(Encode("UNKNOWN:NAME:" + playerName));//Must keep the format same
               }
            }
            else if (commands[commandCount] == "##SERVER##")
            {
               commandCount++;
               if (commands[commandCount] == "START")
               {
                  btnEndTurn.Enabled = false;
                  btnSend.Enabled = true;
                  commandCount++;
                  WorkerChat.RunWorkerAsync();
               }
               else if (commands[commandCount] == "SETCOLOR")//playerNum
               {
                  commandCount++;
                  mapInfo[0, 0].setClientPlayer(commands[commandCount]); //Need to have to for continous looping get next command
                  playerNum = int.Parse(commands[commandCount]);
                  ShowInfo();
                  commandCount++;
                  //             TradeForm.SetActivePlayer(commands[commandCount]);
               }
               else if (commands[commandCount] == "CLOSING")
               {
                  MessageBox.Show("Sorry, but the Host has closed the server",
                     "Goodbye", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  WorkerChat.CancelAsync();
                  workerMainThread.CancelAsync();
                  Application.Exit();
               }
               else if (commands[commandCount] == "CHAT")
               {
                  commandCount++;
                  txtOutPut.AppendText(commands[commandCount] + Environment.NewLine);//I added the commandCount after and not in the 
                  commandCount++;                                                    //Statement just incase we wanted to add more commands
               }
               else if (commands[commandCount] == "MAPUPDATE")
               {
                  commandCount++;
                  UpdateMap(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "MAPROLL")
               {
                  commandCount++;
                  UpdateRoll(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "SINGLETILEUPDATE")
               {
                  commandCount++;
                  UpdateTile(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "RESOURCEUPDATE")
               {
                  commandCount++;
                  UpdateResources(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "TURN")
               {
                  commandCount++;
                  StartTurn();
               }
               else if (commands[commandCount] == "NUMOFPLAYERS")
               {
                  commandCount++;
                  SetNumOfPlayers(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "PLAYERNAMES")
               {
                  commandCount++;
                  PlayerNames(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "PROPOSAL")
               {
                  commandCount++;
                  ReceivedTradeRequest(commands[commandCount]);
               }
               else if (commands[commandCount] == "ACCEPTANCE")
               {
                  commandCount++;
                  ReceivedTradeResults(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "VPUPDATE")
               {
                  commandCount++;
                  VPClientSet(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "GAMEOVER")
               {
                  commandCount++;
                  GameOver(commands[commandCount]);
                  commandCount++;
               }
               else if (commands[commandCount] == "DEVCARD")
               {
                  commandCount++;
                  DevCardResponse(commands[commandCount]);
                  commandCount++;
               }
            }
            else
               break;
         }
      }

      private void DevCardResponse(string command)
      {
         if (command.Equals("NONE"))
         {
            // Do nothing?
         }
         else
         {
            Players myPlayer = pList[playerNum - 1];
            myPlayer.BuyDevCard(command);
            UpdateDevCard(command);
         }
      }

      /// <summary>
      /// Update development card values
      /// </summary>
      /// <param name="type"></param>
      private void UpdateDevCard(string type)
      {
         switch (type)
         {
            case "TERRITORY":
               lblTerritoryNum.Text = (pList[playerNum - 1].GetDevCardTypeCount(type)).ToString();
               break;
            case "YOP":
               lblPlentyNum.Text = (pList[playerNum - 1].GetDevCardTypeCount(type)).ToString();
               break;
            case "MONOPOLY":
               lblMonopolyNum.Text = (pList[playerNum - 1].GetDevCardTypeCount(type)).ToString();
               break;
            case "KNIGHT":
               lblKnightNum.Text = (pList[playerNum - 1].GetDevCardTypeCount(type)).ToString();
               break;
            case "VP":
               lblVicotryNum.Text = (pList[playerNum - 1].GetDevCardTypeCount(type)).ToString();
               break;
         }
      }

      private void GameOver(string command)
      {
         btnEndTurn.Enabled = false;
         btnRollDice.Enabled = false;
         btnTrade.Enabled = false;
         txtMessage.Enabled = false;
         for (int i = 0; i < 16; i++)
         {
            for (int j = 0; j < 16; j++)
            {
               mapInfo[i, j].SendBack();
            }
         }
         string temp = "Player " + command + " has won the game!";
         MessageBox.Show(temp, "End Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
         Application.Exit();

      }
      private void PlayerNames(string command)
      {
         string[] s = command.Split(',');
         for (int i = 0; i < playerCount; i++)
         {
            pList[i].UpdateName(s[i]);
         }
      }
      private void StartTurn()
      {
         turnSound.Play();
         btnRollDice.Enabled = !setUp;
         btnEndTurn.Enabled = !setUp;
         btnTrade.Enabled = !setUp;
         Territory.isTurn = true;
         isTurn = true;
         if (Territory.setUp == 0)
            MessageBox.Show("Select your first Territory");
         else if (Territory.setUp == 1)
            MessageBox.Show("Select your second Territory");
         else
         {
            setUp = false;
            btnRollDice.Enabled = true;
            btnTrade.Enabled = true;
            if (initialCityCount < 3)
            {
               soc.Send(Encode(initialCityInfoOne));
               soc.Send(Encode(initialCityInfoTwo));
               initialCityCount++;
            }

         }
         //Territory.setUp++;
      }
      /*
      private void SetupSequence()
      {
         isTurn = true;
         setUp = true;
         //Map.Enabled = true;
         btnEndTurn.Enabled = false;
         btnRollDice.Enabled = false;
         btnTrade.Enabled = false;
         if (startTers == 0)
            MessageBox.Show("Select your first Territory");
         else
            MessageBox.Show("Select your second Territory");
         Territory.isTurn = true;
         startTers++;
      }
      */
      private void VPClientSet(string vpInfo)
      {
         string[] info = vpInfo.Split(',');
         for (int i = 0; i < playerCount; i++)
         {
            pList[i].vp = int.Parse(info[i]);
            pList[i].UpdateResource();
         }

         panPlayer1.Refresh();
         panPlayer2.Refresh();
         panPlayer3.Refresh();
         panPlayer4.Refresh();

      }

      private void SetNumOfPlayers(string playersNumber)
      {
         playerCount = int.Parse(playersNumber);
      }
      private void UpdateResources(string resourceInfo)
      {
         string[] resourceList = resourceInfo.Split(',');
         for (int i = 0; i < playerCount; i++)
         {
            pList[i].food = int.Parse(resourceList[6 * i]);
            pList[i].stone = int.Parse(resourceList[6 * i + 1]);
            pList[i].wood = int.Parse(resourceList[6 * i + 2]);
            pList[i].animal = int.Parse(resourceList[6 * i + 3]);
            pList[i].vp = int.Parse(resourceList[6 * i + 4]);
            if (i != playerNum - 1)
               pList[i].DevCardTotal = int.Parse(resourceList[6 * i + 5]);
            pList[i].UpdateResource();
         }

         victoryCardClientUpdate();
         panPlayer1.Refresh();
         panPlayer2.Refresh();
         panPlayer3.Refresh();
         panPlayer4.Refresh();

      }
      private void UpdateTile(string command)
      {
         string[] info = command.Split(',');
         int x = int.Parse(info[0]);
         int y = int.Parse(info[1]);
         mapInfo[x, y].ChangeBackgroundColor(int.Parse(info[2]));
         mapInfo[x, y].Refresh();
         if (int.Parse(info[3]) == 0)
            mapInfo[x, y].SetCity(false);
         else
            mapInfo[x, y].SetCity(true);
      }
      private void UpdateRoll(string roll)
      {
         int mapCounter = 0;
         string[] rollList = roll.Split(',');
         for (int i = 0; i < 16; i++)
         {
            for (int j = 0; j < 16; j++)
            {
               mapInfo[i, j].UpdateRollNum(rollList[(mapCounter++)]);
               mapInfo[i, j].SetRollNum();
            }
         }
      }
      private void UpdateMap(string map)
      {
         Map.Controls.Clear();
         int mapCounter = 0;
         for (int i = 0; i < 16; i++)
         {
            for (int j = 0; j < 16; j++)
            {
               float width = Map.Size.Width / 16;
               float height = Map.Size.Height / 16;
               mapInfo[i, j].Size = new Size((int)width, (int)height);
               mapInfo[i, j].ResizeTer(Int32.Parse(map.Substring(mapCounter++, 1)));
               Map.Controls.Add(mapInfo[i, j]);
               //Territory.RollID.Text = 
            }
         }
         pList[playerNum - 1].UpdateName(playerName);
      }

      private void SingleResourceSend(int x, int y, int owner)
      {
         if (initialCityCount == 0)
            initialCityInfoOne = "UNKNOWN:STARTCITYRESOURCE:" + x + "," + y + "," + owner;
         else
            initialCityInfoTwo = "UNKNOWN:STARTCITYRESOURCE:" + x + "," + y + "," + owner;
         initialCityCount++;

      }
      private bool ResourceSend(int x, int y, int owner, bool hasCity)
      {
         if (mapInfo[x, y].infoChanged)
         {
            soc.Send(Encode("UNKNOWN:TILECHANGE:" + x + "," + y + "," + owner + "," + hasCity));
            if (setUp)
               SingleResourceSend(x, y, owner);
            return true;
         }
         return false;
      }
      private void WorkerChat_DoWork(object sender, DoWorkEventArgs e)
      {
         socChat = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         socChat.Connect(IP, 5764);
         while (!WorkerChat.CancellationPending)
         {
            try
            {
               Byte[] msg = new Byte[1024];
               int numBytes;
               numBytes = socChat.Receive(msg);
               String message = Decode(msg, numBytes);
               string command = "";
               if (checkIfchat(message, ref command))
                  txtOutPut.Invoke(this.myDelegate, new object[] { command });
            }
            catch (Exception ex)
            {

            }
         }
      }
      private bool checkIfchat(string message, ref string command)
      {
         string[] commands = message.Split(':');
         try
         {
            if (commands[1] == "CHAT")
            {
               command = commands[0] + ": " + commands[2];
               return true;
            }
            return false;
         }
         catch (Exception ex)
         {
            return false;
         }
      }
      private void addToOutput(string s)
      {
         txtOutPut.AppendText(s);
         txtOutPut.AppendText(Environment.NewLine);
      }
      private void workerMainThread_DoWork(object sender, DoWorkEventArgs e)
      {
         while (!workerMainThread.CancellationPending)
         {
            try
            {
               bool moreData = true;
               string message = "";
               while (moreData)
               {
                  bytes = new byte[2048];
                  int NumBytes;
                  NumBytes = soc.Receive(bytes);
                  if (NumBytes < 2048)
                     moreData = false;
                  message += Decode(bytes, NumBytes); //where message is recieved
               }
               //MessageBox.Show(message); //Debugging
               txtOutPut.Invoke(this.mySecondDel, new object[] { message });
            }
            catch (Exception ex)
            {

            }
         }

      }
      private void btnSend_Click(object sender, EventArgs e)
      {
         if (txtMessage.Text != "")
         {
            socChat.Send(Encode(playerName + ":CHAT:" + txtMessage.Text.Trim()));
            txtMessage.Text = "";
         }
      }
      private void Client_FormClosed(object sender, FormClosedEventArgs e)
      {
         // this is where we need to close server and send message to all users & end app for all ToDo
         // playerNum need to know to skip their turn
      }
      private void Client_FormClosing(object sender, FormClosingEventArgs e)
      {
         soc.Close();
         if (socChat != null)
            socChat.Close();

         //   if (e.CloseReason == )
         //  e.Cancel = true; // needs to be edited. ToDo should stop alt f4, actually stops all closing... oops
      }
      private void btnEndTurn_Click(object sender, EventArgs e)
      {
         Territory.beginning = false;
         //ToDo send message to server to go to next playerin server if it can ID what client's turn it is 
         // we could have it pop up a message box saying it's their turn.


         btnRollDice.Enabled = false;
         btnEndTurn.Enabled = false;
         btnTrade.Enabled = false;
         for (int i = 0; i < 16; i++)
         {
            for (int j = 0; j < 16; j++)
            {
               mapInfo[i, j].SendBack();
               //Territory.RollID.Text = 
            }
         }

         Territory.isTurn = false;

         if (pList[playerNum - 1].vp > 10)
            soc.Send(Encode("ENDGAME"));
         else
            soc.Send(Encode("ENDTURN"));
      }
      private void txtMessage_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter && txtMessage.Text != "")
         {
            socChat.Send(Encode(playerName + ":CHAT:" + txtMessage.Text.Trim()));
            txtMessage.Text = "";
         }
      }
      private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == ':')
         {
            MessageBox.Show("Invalid Name. Your name cannot contain a \":\". ", "Invalid Character",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
         }
      }
      private void MapImageClick(object sender, System.EventArgs e)
      {
         if (setUp)
            isTurn = false;
         //setUp = false;
         Territory temp = (Territory)((sender as PictureBox).Parent);
         ResourceSend(temp.xPos, temp.yPos, temp.CheckBackGroundColor(), temp.hascity);
         if (!temp.freeTerritoryFlag)
         {
            if (temp.terChanged)
            {
               pList[temp.CheckBackGroundColor() - 1].minusResourceTerritory();
               soc.Send(Encode("UNKNOWN:MINUSRESOURCES:" + temp.CheckBackGroundColor() + "," + "ter"));
            }
            if (temp.cityChanged)
            {
               pList[temp.CheckBackGroundColor() - 1].minusResourceCity();
               soc.Send(Encode("UNKNOWN:MINUSRESOURCES:" + temp.CheckBackGroundColor() + "," + "city"));
            }
         }
         else
         {
            pList[playerNum - 1].DecrimentDevCard("TERRITORY");
            soc.Send(Encode("UNKNOWN:USEDEVCARD:TERRITORY" + "," + playerNum.ToString()));
         }
         UpdateDevCard("TERRITORY");

         temp.terChanged = false;
         temp.cityChanged = false;
         usingTerrCard = false;
         temp.freeTerritoryFlag = false;

         //Territory.isTurn = false;
         //soc.Send(Encode("DONE")); //To tell server to go on
      }
      private void ReceivedTradeRequest(string myTrade)
      {
         string result;
         string[] tradeInfo = myTrade.Split(',');
         int a = int.Parse(tradeInfo[0]);
         int f = int.Parse(tradeInfo[1]);
         int s = int.Parse(tradeInfo[2]);
         int w = int.Parse(tradeInfo[3]);
         int OG = int.Parse(tradeInfo[5]);
         string orig = pList[OG].Name;
         DialogResult dr = MessageBox.Show(orig + "Would like to trade. You would end up with: \r\n" + a + "Animals\r\n"
            + f + "Food \r\n" + s + "Stone \r\n" + w + "Wood \r\n", "Proposed Trade", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         if (dr == DialogResult.Yes)
            result = "accepted";
         else
            result = "rejected";
         soc.Send(Encode("UNKNOWN:ACCEPTANCE:" + result + "," + myTrade + ":"));
      }
      private void ReceivedTradeResults(string myTrade)
      {
         string[] tradeInfo = myTrade.Split(',');
         string result = tradeInfo[0];
         int traderNum = int.Parse(tradeInfo[1]);
         string trader = pList[traderNum].Name;
         MessageBox.Show(trader + " has " + result + " your trade request.");
      }
      private void CheckNabor(object sender, System.EventArgs e)
      {
         Territory temp = (Territory)((sender as PictureBox).Parent);
         temp.canBuild = false;
         temp.cityNextTo = false;

         if (usingTerrCard)
         {
            temp.freeTerritoryFlag = true;
            purchaseTerr = true;
            purchaseCity = false;
         }
         else
         {
            int myF, myA, myS, myW;
            myA = pList[playerNum - 1].animal;
            myF = pList[playerNum - 1].food;
            myS = pList[playerNum - 1].stone;
            myW = pList[playerNum - 1].wood;
            if (myS >= 1 && myW >= 1)
               purchaseTerr = true;
            else
               purchaseTerr = false;
            if (myA >= 1 && myF >= 1 && myS >= 1 && myW >= 1)
               purchaseCity = true;
            else
               purchaseCity = false;
         }

         if (temp.xPos != 15)
         {
            if (mapInfo[temp.xPos + 1, temp.yPos].CheckBackGroundColor() == Territory.clientPlayer)
            {
               temp.canBuild = true;
               if (mapInfo[temp.xPos + 1, temp.yPos].hascity)
                  temp.cityNextTo = true;
            }
         }
         if (temp.xPos != 0)
         {
            if (mapInfo[temp.xPos - 1, temp.yPos].CheckBackGroundColor() == Territory.clientPlayer)
            {
               temp.canBuild = true;
               if (mapInfo[temp.xPos - 1, temp.yPos].hascity)
                  temp.cityNextTo = true;
            }
         }
         if (temp.yPos != 15)
         {
            if (mapInfo[temp.xPos, temp.yPos + 1].CheckBackGroundColor() == Territory.clientPlayer)
            {
               temp.canBuild = true;
               if (mapInfo[temp.xPos, temp.yPos + 1].hascity)
                  temp.cityNextTo = true;
            }
         }
         if (temp.yPos != 0)
         {
            if (mapInfo[temp.xPos, temp.yPos - 1].CheckBackGroundColor() == Territory.clientPlayer)
            {
               temp.canBuild = true;
               if (mapInfo[temp.xPos, temp.yPos - 1].hascity)
                  temp.cityNextTo = true;
            }
         }

      }
      private void RunServer_DoWork(object sender, DoWorkEventArgs e)
      {
         byte[] myResBytes = nataC_fo_sreltteS.Properties.Resources.nataCServer;
         Assembly asm = Assembly.Load(myResBytes);
         // search for the Entry Point
         MethodInfo method = asm.EntryPoint;
         if (method == null) throw new NotSupportedException();
         // create an instance of the Startup form Main method
         object obj = asm.CreateInstance(method.Name);
         // invoke the application starting point
         method.Invoke(obj, null);
      }

      private void button1_Click(object sender, EventArgs e)
      {

      }

      private void Map_Paint(object sender, PaintEventArgs e)
      {

      }

      private void picTerritoryCard_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            HandleDevCard("TERRITORY");
      }

      /// <summary>
      /// Handle processing development cards
      /// </summary>
      /// <param name="cardType">Uppercase card name</param>
      private void HandleDevCard(string cardType)
      {
         if (cardType.Equals("TERRITORY"))
         {
            if (Int32.Parse(lblTerritoryNum.Text) > 0)
            {
               usingTerrCard = true;
            }
         }
         else if (cardType.Equals("YOP"))
         {
            if (Int32.Parse(lblPlentyNum.Text) > 0)
            {
               YoPRequest();
               UpdateDevCard(cardType);
            }
         }
         else if (cardType.Equals("MONOPOLY"))
         {
            if (Int32.Parse(lblMonopolyNum.Text) > 0)
            {
               MonopolyRequest();
               UpdateDevCard(cardType);
            }
         }
         else if (cardType.Equals("KNIGHT"))
         {
            if (Int32.Parse(lblKnightNum.Text) > 0)
            {
               KnightRequest();
               //soc.Send(Encode("UNKNOWN:USEDEVCARD:" + cardType + "," + playerNum.ToString()));
               UpdateDevCard(cardType);
            }
         }
         else if (cardType.Equals("VP"))
         {
            if (Int32.Parse(lblVicotryNum.Text) > 0)
            {
               VPRequest();
               //soc.Send(Encode("UNKNOWN:USEDEVCARD:" + cardType + "," + playerNum.ToString()));
               UpdateDevCard(cardType);
            }
         }
      }

      /// <summary>
      /// Sends a Victory Point Card request to server
      /// </summary>
      private void VPRequest()
      {
         soc.Send(Encode("UNKNOWN:USEDEVCARD:VP" + "," +
                  playerNum.ToString()));
         pList[playerNum - 1].DecrimentDevCard("VP");
      }

      /// <summary>
      /// Process a Year of Plenty request and send to server
      /// </summary>
      private void YoPRequest()
      {
         using (var yopForm = new ResourceRequest())
         {
            if (yopForm.ShowDialog() == DialogResult.OK)
            {
               string resource = yopForm.resource;
               soc.Send(Encode("UNKNOWN:USEDEVCARD:YOP" + "," +
                  playerNum.ToString() + "," + resource));
               pList[playerNum - 1].DecrimentDevCard("YOP");
               //yopForm.Close();
            }
         }
      }

      /// <summary>
      /// Process a Monopoly request and send to server
      /// </summary>
      private void MonopolyRequest()
      {
         using (var monForm = new ResourceRequest(true))
         {
            if (monForm.ShowDialog() == DialogResult.OK)
            {
               string resource = monForm.resource;
               soc.Send(Encode("UNKNOWN:USEDEVCARD:MONOPOLY" + "," +
                  playerNum.ToString() + "," + resource));
               pList[playerNum - 1].DecrimentDevCard("MONOPOLY");
               //yopForm.Close();
            }
         }
      }

      /// <summary>
      /// Process a Knight request and send to server
      /// </summary>
      private void KnightRequest()
      {
         using (var knight = new PlayerRequest(playerCount, playerNum))
         {
            if (knight.ShowDialog() == DialogResult.OK)
            {
               int requestNum = knight.playerNum;
               soc.Send(Encode("UNKNOWN:USEDEVCARD:KNIGHT" + "," +
                  playerNum.ToString() + "," + requestNum.ToString()));
               pList[playerNum - 1].DecrimentDevCard("KNIGHT");
               knight.Close();
            }

         }
      }

      private void picPlentyCard_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            HandleDevCard("YOP");
      }

      private void picMonopolyCard_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            HandleDevCard("MONOPOLY");
      }

      private void picKnightCard_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            HandleDevCard("KNIGHT");
      }

      private void picDeck_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            soc.Send(Encode("UNKNOWN:BUYDEVCARD:" + playerNum.ToString()));
      }

      private void picVictoryCard_Click(object sender, EventArgs e)
      {
         if (Territory.isTurn)
            HandleDevCard("VP");
      }

      private void victoryCardClientUpdate()
      {
         int[,] one = new int[4, 3];
         string tempStr = "";
         for (int i = 0; i < 16; i++)
            for (int j = 0; j < 16; j++)
            {
               Territory temp = mapInfo[i, j];
               if (temp.CheckBackGroundColor() != -1 && !temp.hascity)
                  one[temp.CheckBackGroundColor() - 1, 0]++;
               if (temp.CheckBackGroundColor() != -1 && temp.hascity)
                  one[temp.CheckBackGroundColor() - 1, 1]++;
            }
         for (int k = 0; k < playerCount; k++)
         {
            one[k, 2] = pList[k].numOfResouce();
         }
         for (int k = 0; k < playerCount; k++)
         {
            if (mostTer == 0)
            {
               if (one[k, 0] > 5)
               {
                  mostTer = k + 1;
                  pList[k].vp++;
               }
            }
            else
            {
               if (one[k, 0] > one[mostTer - 1, 0])
               {
                  pList[mostTer - 1].vp--;
                  mostTer = k + 1;
                  pList[k].vp++;
               }
            }
            if (mostCity == 0)
            {
               if (one[k, 1] > 5)
               {
                  mostCity = k + 1;
                  pList[k].vp++;
               }
            }
            else
            {
               if (one[k, 1] > one[mostTer - 1, 1])
               {
                  pList[mostCity - 1].vp--;
                  mostCity = k + 1;
                  pList[k].vp++;
               }
            }
            if (mostVP == 0)
            {
               if (pList[k].vp > 0)
               {
                  mostVP = k + 1;
               }
            }
            else
            {
               if (pList[k].vp > pList[mostVP - 1].vp)
               {
                  mostVP = k + 1;
               }
            }
            if (mostResource == 0)
            {
               if (one[k, 2] > 12 && !setUp)
               {
                  mostResource = k + 1;
                  pList[k].vp++;
               }
            }
            else
            {
               if (one[k, 2] > pList[mostVP - 1].numOfResouce() && !setUp)
               {
                  pList[mostResource - 1].vp--;
                  mostResource = k + 1;
                  pList[k].vp++;
               }
            }
         }
         for (int p = 0; p < playerCount; p++)
         {
            pList[p].setMostTerPic(mostTer == p + 1);
            pList[p].setMostCityPic(mostCity == p + 1);
            pList[p].setMostVPPic(mostVP == p + 1);
            pList[p].setMostResources(mostResource == p + 1);
         }
         if (!setUp)
         {
            for (int q = 0; q < playerCount; q++)
            {
               tempStr += pList[q].vp.ToString();
               tempStr += ",";
            }
            soc.Send(Encode("UNKNOWN:VPCARDUPDATE:" + tempStr + ":"));
         }
      }
   }
}

//37 methods