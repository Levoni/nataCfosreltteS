namespace nataC_Server
{
   partial class frmServer
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnGenerate = new System.Windows.Forms.Button();
         this.btnStart = new System.Windows.Forms.Button();
         this.workerConnection = new System.ComponentModel.BackgroundWorker();
         this.workerChat = new System.ComponentModel.BackgroundWorker();
         this.workerTurn = new System.ComponentModel.BackgroundWorker();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Location = new System.Drawing.Point(1, 1);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(401, 283);
         this.panel1.TabIndex = 0;
         // 
         // btnGenerate
         // 
         this.btnGenerate.Location = new System.Drawing.Point(1, 303);
         this.btnGenerate.Name = "btnGenerate";
         this.btnGenerate.Size = new System.Drawing.Size(197, 66);
         this.btnGenerate.TabIndex = 1;
         this.btnGenerate.Text = "Generate Map";
         this.btnGenerate.UseVisualStyleBackColor = true;
         this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
         // 
         // btnStart
         // 
         this.btnStart.Location = new System.Drawing.Point(204, 303);
         this.btnStart.Name = "btnStart";
         this.btnStart.Size = new System.Drawing.Size(198, 66);
         this.btnStart.TabIndex = 2;
         this.btnStart.Text = "Start Game";
         this.btnStart.UseVisualStyleBackColor = true;
         this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
         // 
         // workerConnection
         // 
         this.workerConnection.WorkerSupportsCancellation = true;
         this.workerConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerConnection_DoWork);
         // 
         // workerChat
         // 
         this.workerChat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerChat_DoWork);
         // 
         // workerTurn
         // 
         this.workerTurn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerTurn_DoWork);
         // 
         // frmServer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(403, 381);
         this.Controls.Add(this.btnStart);
         this.Controls.Add(this.btnGenerate);
         this.Controls.Add(this.panel1);
         this.Name = "frmServer";
         this.Text = "Server";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
         this.Load += new System.EventHandler(this.frmServer_Load);
         this.ResizeEnd += new System.EventHandler(this.frmServer_ResizeEnd);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnGenerate;
      private System.Windows.Forms.Button btnStart;
      private System.ComponentModel.BackgroundWorker workerConnection;
      private System.ComponentModel.BackgroundWorker workerChat;
      private System.ComponentModel.BackgroundWorker workerTurn;
   }
}

