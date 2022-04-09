using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace nataC_fo_sreltteS
{
   public partial class Trade : Form
   {
      Client clientForm; //used for refrencing the client 
      private int modifiedA = 0, modifiedF = 0, modifiedW = 0, modifiedS = 0;
      private int modifiedA2 = 0, modifiedF2 = 0, modifiedW2 = 0, modifiedS2 = 0;
      private string a, f, s, w;
      private int tradingWith;
      private bool traded = false;
      private int playerNum = Client.playerNum;
      public Players P1 = new Players();
      public Players P2 = new Players();
      public Players P3 = new Players();
      public Players P4 = new Players();
      public Players bank = new Players();
      Socket sock;
      private void SetTradeText()
      {
         txtYSA.Text = modifiedA.ToString();
         txtYSF.Text = modifiedF.ToString();
         txtYSS.Text = modifiedS.ToString();
         txtYSW.Text = modifiedW.ToString();

         txtYGA.Text = modifiedA2.ToString();
         txtYGF.Text = modifiedF2.ToString();
         txtYGS.Text = modifiedS2.ToString();
         txtYGW.Text = modifiedW2.ToString();
      }
      private void Trade_Load(object sender, EventArgs e)
      {
         if (playerNum == 1)
         {
            btnP1.Enabled = false;
            panel1.Controls.Add(P1);
            panel1.BackColor = System.Drawing.Color.Gold;
            pnlBtns1.BackColor = System.Drawing.Color.Gold;
         }
         else if (playerNum == 2)
         {
            btnP2.Enabled = false;
            panel1.Controls.Add(P2);
            panel1.BackColor = System.Drawing.Color.Red;
            pnlBtns1.BackColor = System.Drawing.Color.Red;
         }
         else if (playerNum == 3)
         {
            btnP3.Enabled = false;
            panel1.Controls.Add(P3);
            panel1.BackColor = System.Drawing.Color.Lime;
            pnlBtns1.BackColor = System.Drawing.Color.Lime;
         }
         else
         {
            btnP4.Enabled = false;
            panel1.Controls.Add(P4);
            panel1.BackColor = System.Drawing.Color.Aqua;
            pnlBtns1.BackColor = System.Drawing.Color.Aqua;
         }
         ReOpen();
      }
      private void UpdateTextBoxes()
      {
         P1.UpdateResource();
         P2.UpdateResource();
         P3.UpdateResource();
         P4.UpdateResource();
      }
      private void TWBank()
      {
         panel2.Controls.Add(bank);
         panel2.BackColor = System.Drawing.Color.White;
         pnlBtns2.BackColor = System.Drawing.Color.White;
         tradingWith = 0;

      }
      private void TWP1()
      {
         panel2.Controls.Add(P1);
         panel2.BackColor = System.Drawing.Color.Gold;
         pnlBtns2.BackColor = System.Drawing.Color.Gold;
         tradingWith = 1;
         P1.UpdateResource();
      }
      private void TWP2()
      {
         panel2.Controls.Add(P2);
         panel2.BackColor = System.Drawing.Color.Red;
         pnlBtns2.BackColor = System.Drawing.Color.Red;
         tradingWith = 2;
         P2.UpdateResource();
      }
      private void TWP3()
      {
         panel2.Controls.Add(P3);
         panel2.BackColor = System.Drawing.Color.Lime;
         pnlBtns2.BackColor = System.Drawing.Color.Lime;
         tradingWith = 3;
         P3.UpdateResource();
      }
      private void TWP4()
      {
         panel2.Controls.Add(P4);
         panel2.BackColor = System.Drawing.Color.Aqua;
         pnlBtns2.BackColor = System.Drawing.Color.Aqua;
         tradingWith = 4;
         P4.UpdateResource();
      }
      public Trade(Client cli, Socket soc)
      {
         sock = soc;
         InitializeComponent();
         clientForm = cli;

         SetTradeText();
      }
      //called when any radiobutton is clicked
      private void btnBank_CheckedChanged_1(object sender, EventArgs e)
      {
         modifiedA = modifiedF = modifiedW = modifiedS = 0;
         modifiedA2 = modifiedF2 = modifiedW2 = modifiedS2 = 0;
         SetTradeText();
         panel2.Controls.Clear();
         EnableAll();
         if (btnBank.Checked)
            TWBank();
         else if (btnP1.Checked)
            TWP1();
         else if (btnP2.Checked)
            TWP2();
         else if (btnP3.Checked)
            TWP3();
         else
            TWP4();
         CheckTButtons();
         CheckTWButtons();
      }
      private void BringToFront()
      {
         this.TopMost = true;
      }
      private void btnTrade_Click(object sender, EventArgs e)
      {
         btnTrade.Enabled = false;
         a = ((-1 * modifiedA) + modifiedA2).ToString();
         f = ((-1 * modifiedF) + modifiedF2).ToString();
         s = ((-1 * modifiedS) + modifiedS2).ToString();
         w = ((-1 * modifiedW) + modifiedW2).ToString();
         //sends what recipient of offer will get will get
         sock.Send(Encode("UNKNOWN:PROPOSAL:" + a + "," + f + "," + s + "," + w + "," + tradingWith + "," + playerNum));
         modifiedA = modifiedF = modifiedW = modifiedS = 0;
         modifiedA2 = modifiedF2 = modifiedW2 = modifiedS2 = 0;
         SetTradeText();
      }
      private void btnReturn_Click(object sender, EventArgs e)
      {
         KeepFront.Enabled = false;
         modifiedA = modifiedF = modifiedW = modifiedS = 0;
         modifiedA2 = modifiedF2 = modifiedW2 = modifiedS2 = 0;
         SetTradeText();
         EnableAll();
         this.Hide();
         clientForm.Show();
      }
      private void btnMinusA_Click(object sender, EventArgs e)
      {
         modifiedA++;
         txtYSA.Text = (modifiedA * (-1)).ToString();
         btnPlusA.Enabled = true;
         CheckTButtons();
         EnsureNoCheating();
      }
      private void btnPlusA_Click(object sender, EventArgs e)
      {
         modifiedA--;
         txtYSA.Text = (modifiedA * (-1)).ToString();
         CheckTButtons();
         CheckTWButtons();
      }

      private void btnMinusF_Click(object sender, EventArgs e)
      {
         modifiedF++;
         txtYSF.Text = (modifiedF * (-1)).ToString();
         btnPlusF.Enabled = true;
         CheckTButtons();
         EnsureNoCheating();
      }

      private void btnPlusF_Click(object sender, EventArgs e)
      {
         modifiedF--;
         txtYSF.Text = (modifiedF * (-1)).ToString();
         CheckTButtons();
         CheckTWButtons();
      }

      private void btnMinusS_Click(object sender, EventArgs e)
      {
         modifiedS++;
         txtYSS.Text = (modifiedS * (-1)).ToString();
         btnPlusS.Enabled = true;
         CheckTButtons();
         EnsureNoCheating();
      }

      private void btnPlusS_Click(object sender, EventArgs e)
      {
         modifiedS--;
         txtYSS.Text = (modifiedS * (-1)).ToString();
         CheckTButtons();
         CheckTWButtons();
      }

      private void btnMinusW_Click(object sender, EventArgs e)
      {
         modifiedW++;
         txtYSW.Text = (modifiedW * (-1)).ToString();
         btnPlusW.Enabled = true;
         CheckTButtons();
         EnsureNoCheating();
      }

      private void btnPlusW_Click(object sender, EventArgs e)
      {
         modifiedW--;
         txtYSW.Text = (modifiedW * (-1)).ToString();
         CheckTButtons();
         CheckTWButtons();
      }

      private void btnMinusA2_Click(object sender, EventArgs e)
      {
         modifiedA2++;
         txtYGA.Text = (modifiedA2 * (-1)).ToString();
         btnPlusA2.Enabled = true;
         CheckTWButtons();
      }

      private void btnPlusA2_Click(object sender, EventArgs e)
      {
         modifiedA2--;
         txtYGA.Text = (modifiedA2 * (-1)).ToString();
         CheckTWButtons();
         CheckTWButtons();
      }

      private void btnMinusF2_Click(object sender, EventArgs e)
      {
         modifiedF2++;
         txtYGF.Text = (modifiedF2 * (-1)).ToString();
         btnPlusF2.Enabled = true;
         CheckTWButtons();
      }

      private void btnPlusF2_Click(object sender, EventArgs e)
      {
         modifiedF2--;
         txtYGF.Text = (modifiedF2 * (-1)).ToString();
         CheckTWButtons();
      }

      private void btnMinusS2_Click(object sender, EventArgs e)
      {
         modifiedS2++;
         txtYGS.Text = (modifiedS2 * (-1)).ToString();
         btnPlusS2.Enabled = true;
         CheckTWButtons();
      }

      private void btnPlusS2_Click(object sender, EventArgs e)
      {
         modifiedS2--;
         txtYGS.Text = (modifiedS2 * (-1)).ToString();
         CheckTWButtons();
      }

      private void btnMinusW2_Click(object sender, EventArgs e)
      {
         modifiedW2++;
         txtYGW.Text = (modifiedW2 * (-1)).ToString();
         btnPlusW2.Enabled = true;
         CheckTWButtons();
      }

      private void btnPlusW2_Click(object sender, EventArgs e)
      {
         modifiedW2--;
         txtYGW.Text = (modifiedW2 * (-1)).ToString();
         CheckTWButtons();
      }

      private void KeepFront_Tick(object sender, EventArgs e)
      {
         BringToFront();
      }
      public void GetPlayerInfo(Players[] myPlayers)
      {
         int i = 0;
         P1.animal = myPlayers[i].animal;
         P1.food = myPlayers[i].food;
         P1.stone = myPlayers[i].stone;
         P1.wood = myPlayers[i].wood;
         P2.animal = myPlayers[++i].animal;
         P2.food = myPlayers[i].food;
         P2.stone = myPlayers[i].stone;
         P2.wood = myPlayers[i].wood;
         P3.animal = myPlayers[++i].animal;
         P3.food = myPlayers[i].food;
         P3.stone = myPlayers[i].stone;
         P3.wood = myPlayers[i].wood;
         P4.animal = myPlayers[++i].animal;
         P4.food = myPlayers[i].food;
         P4.stone = myPlayers[i].stone;
         P4.wood = myPlayers[i].wood;
      }

      private void Trade_FormClosing(object sender, FormClosingEventArgs e)
      {
         e.Cancel = true;
         this.Hide();

      }

      private void CheckTButtons()
      {
         modifiedA *= -1;
         modifiedF *= -1;
         modifiedS *= -1;
         modifiedW *= -1;

         if (modifiedA <= 0)
            btnMinusA.Enabled = false;
         else
            btnMinusA.Enabled = true;
         if (modifiedS <= 0)
            btnMinusS.Enabled = false;
         else
            btnMinusS.Enabled = true;
         if (modifiedW <= 0)
            btnMinusW.Enabled = false;
         else
            btnMinusW.Enabled = true;
         if (modifiedF <= 0)
            btnMinusF.Enabled = false;
         else
            btnMinusF.Enabled = true;

         if (playerNum == 1)
         {
            if (P1.animal == modifiedA)
               btnPlusA.Enabled = false;
            if (P1.stone == modifiedS)
               btnPlusS.Enabled = false;
            if (P1.wood == modifiedW)
               btnPlusW.Enabled = false;
            if (P1.food == modifiedF)
               btnPlusF.Enabled = false;
         }
         else if (playerNum == 2)
         {
            if (P2.animal == modifiedA)
               btnPlusA.Enabled = false;
            if (P2.stone == modifiedS)
               btnPlusS.Enabled = false;
            if (P2.wood == modifiedW)
               btnPlusW.Enabled = false;
            if (P2.food == modifiedF)
               btnPlusF.Enabled = false;
         }
         else if (playerNum == 3)
         {
            if (P3.animal == modifiedA)
               btnPlusA.Enabled = false;
            if (P3.stone == modifiedS)
               btnPlusS.Enabled = false;
            if (P3.wood == modifiedW)
               btnPlusW.Enabled = false;
            if (P3.food == modifiedF)
               btnPlusF.Enabled = false;
         }
         else if (playerNum == 4)
         {
            if (P4.animal == modifiedA)
               btnPlusA.Enabled = false;
            if (P4.stone == modifiedS)
               btnPlusS.Enabled = false;
            if (P4.wood == modifiedW)
               btnPlusW.Enabled = false;
            if (P4.food == modifiedF)
               btnPlusF.Enabled = false;
         }
         modifiedA *= -1;
         modifiedF *= -1;
         modifiedS *= -1;
         modifiedW *= -1;
      }

      private void EnsureNoCheating()
      {
         if (tradingWith == 0)
         {
            int tempLose = modifiedA + modifiedF + modifiedS + modifiedW;
            int tempGain = modifiedA2 + modifiedF2 + modifiedS2 + modifiedW2;
            if (tempLose - tempGain <= 4)
            {
               modifiedA = modifiedF = modifiedW = modifiedS = 0;
               modifiedA2 = modifiedF2 = modifiedW2 = modifiedS2 = 0;
               SetTradeText();
               CheckTButtons();
               CheckTWButtons();
            }
         }
      }
      private void CheckTWButtons()
      {
         modifiedA2 *= -1;
         modifiedF2 *= -1;
         modifiedS2 *= -1;
         modifiedW2 *= -1;

         if (modifiedA2 <= 0)
            btnMinusA2.Enabled = false;
         else
            btnMinusA2.Enabled = true;
         if (modifiedS2 <= 0)
            btnMinusS2.Enabled = false;
         else
            btnMinusS2.Enabled = true;
         if (modifiedW2 <= 0)
            btnMinusW2.Enabled = false;
         else
            btnMinusW2.Enabled = true;
         if (modifiedF2 <= 0)
            btnMinusF2.Enabled = false;
         else
            btnMinusF2.Enabled = true;

         if (tradingWith == 0)
         {
            int tempLose = modifiedA + modifiedF + modifiedS + modifiedW;
            int tempGain = modifiedA2 + modifiedF2 + modifiedS2 + modifiedW2;
            if (tempLose + tempGain <= -4)
            {
               btnPlusA2.Enabled = true;
               btnPlusF2.Enabled = true;
               btnPlusS2.Enabled = true;
               btnPlusW2.Enabled = true;
            }
            else
            {
               btnPlusA2.Enabled = false;
               btnPlusF2.Enabled = false;
               btnPlusS2.Enabled = false;
               btnPlusW2.Enabled = false;//ToDo
            }
         }
         else if (tradingWith == 1)
            {
               if (P1.animal == modifiedA2)
                  btnPlusA2.Enabled = false;
               if (P1.stone == modifiedS2)
                  btnPlusS2.Enabled = false;
               if (P1.wood == modifiedW2)
                  btnPlusW2.Enabled = false;
               if (P1.food == modifiedF2)
                  btnPlusF2.Enabled = false;
            }
            else if (tradingWith == 2)
            {
               if (P2.animal == modifiedA2)
                  btnPlusA2.Enabled = false;
               if (P2.stone == modifiedS2)
                  btnPlusS2.Enabled = false;
               if (P2.wood == modifiedW2)
                  btnPlusW2.Enabled = false;
               if (P2.food == modifiedF2)
                  btnPlusF2.Enabled = false;
            }
            else if (tradingWith == 3)
            {
               if (P3.animal == modifiedA2)
                  btnPlusA2.Enabled = false;
               if (P3.stone == modifiedS2)
                  btnPlusS2.Enabled = false;
               if (P3.wood == modifiedW2)
                  btnPlusW2.Enabled = false;
               if (P3.food == modifiedF2)
                  btnPlusF2.Enabled = false;
            }
            else if (tradingWith == 4)
            {
               if (P4.animal == modifiedA2)
                  btnPlusA2.Enabled = false;
               if (P4.stone == modifiedS2)
                  btnPlusS2.Enabled = false;
               if (P4.wood == modifiedW2)
                  btnPlusW2.Enabled = false;
               if (P4.food == modifiedF2)
                  btnPlusF2.Enabled = false;
            }
         modifiedA2 *= -1;
         modifiedF2 *= -1;
         modifiedS2 *= -1;
         modifiedW2 *= -1;
      }

      //Server Stuff
      private byte[] Encode(string command)
      {
         byte[] bytes = new byte[1024];
         bytes = ASCIIEncoding.ASCII.GetBytes(command);
         return bytes;
      }
      private string Decode(byte[] b, int numBytes)
      {
         return ASCIIEncoding.ASCII.GetString(b, 0, numBytes);
      }

      public void ReOpen()
      {
         KeepFront.Enabled = true;
         UpdateTextBoxes();
         TWBank();
         EnableAll();
         CheckTButtons();
         CheckTWButtons();
         SetTradeText();
      }

      public void ReEnableTrade()
      {
         btnTrade.Enabled = true;
      }
      private void EnableAll()
      {
         btnPlusA.Enabled = true;
         btnPlusF.Enabled = true;
         btnPlusS.Enabled = true;
         btnPlusW.Enabled = true;

         btnPlusA2.Enabled = true;
         btnPlusF2.Enabled = true;
         btnPlusS2.Enabled = true;
         btnPlusW2.Enabled = true;

         btnMinusA.Enabled = true;
         btnMinusF.Enabled = true;
         btnMinusS.Enabled = true;
         btnMinusW.Enabled = true;

         btnMinusA2.Enabled = true;
         btnMinusF2.Enabled = true;
         btnMinusS2.Enabled = true;
         btnMinusW2.Enabled = true;
      }
   }
}

//40 methods