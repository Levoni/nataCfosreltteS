namespace nataC_fo_sreltteS
{
   partial class Client
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRollDice = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            this.panPlayer1 = new System.Windows.Forms.Panel();
            this.panPlayer2 = new System.Windows.Forms.Panel();
            this.panPlayer4 = new System.Windows.Forms.Panel();
            this.panPlayer3 = new System.Windows.Forms.Panel();
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.Map = new System.Windows.Forms.FlowLayoutPanel();
            this.WorkerChat = new System.ComponentModel.BackgroundWorker();
            this.workerMainThread = new System.ComponentModel.BackgroundWorker();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.RunServer = new System.ComponentModel.BackgroundWorker();
            this.lblKnightNum = new System.Windows.Forms.Label();
            this.lblVicotryNum = new System.Windows.Forms.Label();
            this.lblTerritoryNum = new System.Windows.Forms.Label();
            this.lblMonopolyNum = new System.Windows.Forms.Label();
            this.lblPlentyNum = new System.Windows.Forms.Label();
            this.picDeck = new System.Windows.Forms.PictureBox();
            this.picPlentyCard = new System.Windows.Forms.PictureBox();
            this.picMonopolyCard = new System.Windows.Forms.PictureBox();
            this.picTerritoryCard = new System.Windows.Forms.PictureBox();
            this.picVictoryCard = new System.Windows.Forms.PictureBox();
            this.picKnightCard = new System.Windows.Forms.PictureBox();
            this.picD1 = new System.Windows.Forms.PictureBox();
            this.picD2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlentyCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonopolyCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTerritoryCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVictoryCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnightCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(916, 32);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.clExit_Click);
            // 
            // btnRollDice
            // 
            this.btnRollDice.Location = new System.Drawing.Point(1019, 32);
            this.btnRollDice.Name = "btnRollDice";
            this.btnRollDice.Size = new System.Drawing.Size(75, 23);
            this.btnRollDice.TabIndex = 2;
            this.btnRollDice.Text = "&Roll Dice";
            this.btnRollDice.UseVisualStyleBackColor = true;
            this.btnRollDice.Click += new System.EventHandler(this.clRollDice_Click);
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(1122, 32);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(75, 23);
            this.btnTrade.TabIndex = 3;
            this.btnTrade.Text = "&Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // panPlayer1
            // 
            this.panPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.panPlayer1.Location = new System.Drawing.Point(887, 160);
            this.panPlayer1.Name = "panPlayer1";
            this.panPlayer1.Size = new System.Drawing.Size(110, 200);
            this.panPlayer1.TabIndex = 5;
            // 
            // panPlayer2
            // 
            this.panPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.panPlayer2.Location = new System.Drawing.Point(1102, 160);
            this.panPlayer2.Name = "panPlayer2";
            this.panPlayer2.Size = new System.Drawing.Size(110, 200);
            this.panPlayer2.TabIndex = 6;
            // 
            // panPlayer4
            // 
            this.panPlayer4.BackColor = System.Drawing.SystemColors.Control;
            this.panPlayer4.Location = new System.Drawing.Point(1102, 405);
            this.panPlayer4.Name = "panPlayer4";
            this.panPlayer4.Size = new System.Drawing.Size(110, 200);
            this.panPlayer4.TabIndex = 7;
            // 
            // panPlayer3
            // 
            this.panPlayer3.BackColor = System.Drawing.SystemColors.Control;
            this.panPlayer3.Location = new System.Drawing.Point(887, 405);
            this.panPlayer3.Name = "panPlayer3";
            this.panPlayer3.Size = new System.Drawing.Size(110, 200);
            this.panPlayer3.TabIndex = 8;
            // 
            // txtOutPut
            // 
            this.txtOutPut.Location = new System.Drawing.Point(890, 634);
            this.txtOutPut.Multiline = true;
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.ReadOnly = true;
            this.txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutPut.Size = new System.Drawing.Size(415, 97);
            this.txtOutPut.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(887, 745);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(48, 23);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(934, 748);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(368, 20);
            this.txtMessage.TabIndex = 16;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Margin = new System.Windows.Forms.Padding(0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(884, 768);
            this.Map.TabIndex = 0;
            this.Map.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Paint);
            // 
            // WorkerChat
            // 
            this.WorkerChat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerChat_DoWork);
            // 
            // workerMainThread
            // 
            this.workerMainThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerMainThread_DoWork);
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(1227, 32);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 19;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // RunServer
            // 
            this.RunServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunServer_DoWork);
            // 
            // lblKnightNum
            // 
            this.lblKnightNum.AutoSize = true;
            this.lblKnightNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblKnightNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblKnightNum.Location = new System.Drawing.Point(1028, 137);
            this.lblKnightNum.Name = "lblKnightNum";
            this.lblKnightNum.Size = new System.Drawing.Size(13, 13);
            this.lblKnightNum.TabIndex = 26;
            this.lblKnightNum.Text = "0";
            // 
            // lblVicotryNum
            // 
            this.lblVicotryNum.AutoSize = true;
            this.lblVicotryNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVicotryNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVicotryNum.Location = new System.Drawing.Point(1056, 137);
            this.lblVicotryNum.Name = "lblVicotryNum";
            this.lblVicotryNum.Size = new System.Drawing.Size(13, 13);
            this.lblVicotryNum.TabIndex = 27;
            this.lblVicotryNum.Text = "0";
            // 
            // lblTerritoryNum
            // 
            this.lblTerritoryNum.AutoSize = true;
            this.lblTerritoryNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTerritoryNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTerritoryNum.Location = new System.Drawing.Point(1092, 136);
            this.lblTerritoryNum.Name = "lblTerritoryNum";
            this.lblTerritoryNum.Size = new System.Drawing.Size(13, 13);
            this.lblTerritoryNum.TabIndex = 28;
            this.lblTerritoryNum.Text = "0";
            // 
            // lblMonopolyNum
            // 
            this.lblMonopolyNum.AutoSize = true;
            this.lblMonopolyNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMonopolyNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMonopolyNum.Location = new System.Drawing.Point(1127, 135);
            this.lblMonopolyNum.Name = "lblMonopolyNum";
            this.lblMonopolyNum.Size = new System.Drawing.Size(13, 13);
            this.lblMonopolyNum.TabIndex = 29;
            this.lblMonopolyNum.Text = "0";
            // 
            // lblPlentyNum
            // 
            this.lblPlentyNum.AutoSize = true;
            this.lblPlentyNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlentyNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPlentyNum.Location = new System.Drawing.Point(1160, 137);
            this.lblPlentyNum.Name = "lblPlentyNum";
            this.lblPlentyNum.Size = new System.Drawing.Size(13, 13);
            this.lblPlentyNum.TabIndex = 30;
            this.lblPlentyNum.Text = "0";
            // 
            // picDeck
            // 
            this.picDeck.Image = global::nataC_fo_sreltteS.Properties.Resources.cardback_1231;
            this.picDeck.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.VPCard;
            this.picDeck.Location = new System.Drawing.Point(896, 128);
            this.picDeck.Name = "picDeck";
            this.picDeck.Size = new System.Drawing.Size(83, 123);
            this.picDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDeck.TabIndex = 31;
            this.picDeck.TabStop = false;
            this.picDeck.Click += new System.EventHandler(this.picDeck_Click);
            // 
            // picPlentyCard
            // 
            this.picPlentyCard.Image = global::nataC_fo_sreltteS.Properties.Resources.YoPCard;
            this.picPlentyCard.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.YoPCard;
            this.picPlentyCard.Location = new System.Drawing.Point(1147, 128);
            this.picPlentyCard.Name = "picPlentyCard";
            this.picPlentyCard.Size = new System.Drawing.Size(70, 110);
            this.picPlentyCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlentyCard.TabIndex = 25;
            this.picPlentyCard.TabStop = false;
            this.picPlentyCard.Click += new System.EventHandler(this.picPlentyCard_Click);
            // 
            // picMonopolyCard
            // 
            this.picMonopolyCard.Image = global::nataC_fo_sreltteS.Properties.Resources.MonopolyCard;
            this.picMonopolyCard.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.MonopolyCard;
            this.picMonopolyCard.Location = new System.Drawing.Point(1112, 127);
            this.picMonopolyCard.Name = "picMonopolyCard";
            this.picMonopolyCard.Size = new System.Drawing.Size(70, 110);
            this.picMonopolyCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMonopolyCard.TabIndex = 24;
            this.picMonopolyCard.TabStop = false;
            this.picMonopolyCard.Click += new System.EventHandler(this.picMonopolyCard_Click);
            // 
            // picTerritoryCard
            // 
            this.picTerritoryCard.Image = global::nataC_fo_sreltteS.Properties.Resources.BuildTerritoryCard;
            this.picTerritoryCard.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.BuildTerritoryCard;
            this.picTerritoryCard.Location = new System.Drawing.Point(1075, 127);
            this.picTerritoryCard.Name = "picTerritoryCard";
            this.picTerritoryCard.Size = new System.Drawing.Size(70, 110);
            this.picTerritoryCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTerritoryCard.TabIndex = 23;
            this.picTerritoryCard.TabStop = false;
            this.picTerritoryCard.Click += new System.EventHandler(this.picTerritoryCard_Click);
            // 
            // picVictoryCard
            // 
            this.picVictoryCard.Image = global::nataC_fo_sreltteS.Properties.Resources.VPCard;
            this.picVictoryCard.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.VPCard;
            this.picVictoryCard.Location = new System.Drawing.Point(1047, 128);
            this.picVictoryCard.Name = "picVictoryCard";
            this.picVictoryCard.Size = new System.Drawing.Size(70, 110);
            this.picVictoryCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVictoryCard.TabIndex = 22;
            this.picVictoryCard.TabStop = false;
            this.picVictoryCard.Click += new System.EventHandler(this.picVictoryCard_Click);
            // 
            // picKnightCard
            // 
            this.picKnightCard.Image = global::nataC_fo_sreltteS.Properties.Resources.KnightCard;
            this.picKnightCard.InitialImage = global::nataC_fo_sreltteS.Properties.Resources.KnightCard;
            this.picKnightCard.Location = new System.Drawing.Point(1019, 128);
            this.picKnightCard.Name = "picKnightCard";
            this.picKnightCard.Size = new System.Drawing.Size(70, 110);
            this.picKnightCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKnightCard.TabIndex = 21;
            this.picKnightCard.TabStop = false;
            this.picKnightCard.Click += new System.EventHandler(this.picKnightCard_Click);
            // 
            // picD1
            // 
            this.picD1.Location = new System.Drawing.Point(1102, 70);
            this.picD1.Name = "picD1";
            this.picD1.Size = new System.Drawing.Size(38, 35);
            this.picD1.TabIndex = 17;
            this.picD1.TabStop = false;
            // 
            // picD2
            // 
            this.picD2.Location = new System.Drawing.Point(1147, 70);
            this.picD2.Name = "picD2";
            this.picD2.Size = new System.Drawing.Size(38, 35);
            this.picD2.TabIndex = 18;
            this.picD2.TabStop = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 857);
            this.Controls.Add(this.picDeck);
            this.Controls.Add(this.lblPlentyNum);
            this.Controls.Add(this.lblMonopolyNum);
            this.Controls.Add(this.lblTerritoryNum);
            this.Controls.Add(this.lblVicotryNum);
            this.Controls.Add(this.lblKnightNum);
            this.Controls.Add(this.picPlentyCard);
            this.Controls.Add(this.picMonopolyCard);
            this.Controls.Add(this.picTerritoryCard);
            this.Controls.Add(this.picVictoryCard);
            this.Controls.Add(this.picKnightCard);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.picD1);
            this.Controls.Add(this.picD2);
            this.Controls.Add(this.txtOutPut);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.panPlayer3);
            this.Controls.Add(this.panPlayer2);
            this.Controls.Add(this.panPlayer4);
            this.Controls.Add(this.panPlayer1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTrade);
            this.Controls.Add(this.btnRollDice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Client";
            this.Text = "Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlentyCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonopolyCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTerritoryCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVictoryCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnightCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnExit;
      private System.Windows.Forms.Button btnRollDice;
      private System.Windows.Forms.Button btnTrade;
      private System.Windows.Forms.Panel panPlayer1;
      private System.Windows.Forms.Panel panPlayer2;
      private System.Windows.Forms.Panel panPlayer4;
      private System.Windows.Forms.Panel panPlayer3;
      private System.Windows.Forms.TextBox txtOutPut;
      private System.Windows.Forms.Button btnSend;
      private System.Windows.Forms.TextBox txtMessage;
      private System.Windows.Forms.FlowLayoutPanel Map;
      private System.ComponentModel.BackgroundWorker WorkerChat;
      private System.ComponentModel.BackgroundWorker workerMainThread;
      private System.Windows.Forms.PictureBox picD1;
      private System.Windows.Forms.PictureBox picD2;
      private System.Windows.Forms.Button btnEndTurn;
      private System.Windows.Forms.HelpProvider helpProvider1;
      private System.ComponentModel.BackgroundWorker RunServer;
      private System.Windows.Forms.PictureBox picKnightCard;
      private System.Windows.Forms.PictureBox picVictoryCard;
      private System.Windows.Forms.PictureBox picTerritoryCard;
      private System.Windows.Forms.PictureBox picMonopolyCard;
      private System.Windows.Forms.PictureBox picPlentyCard;
      private System.Windows.Forms.Label lblKnightNum;
      private System.Windows.Forms.Label lblVicotryNum;
      private System.Windows.Forms.Label lblTerritoryNum;
      private System.Windows.Forms.Label lblMonopolyNum;
      private System.Windows.Forms.Label lblPlentyNum;
      private System.Windows.Forms.PictureBox picDeck;
   }
}

