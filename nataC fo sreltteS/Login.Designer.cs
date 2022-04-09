namespace nataC_fo_sreltteS
{
   partial class Login
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
         this.components = new System.ComponentModel.Container();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.btnEnterGame = new System.Windows.Forms.Button();
         this.txtName = new System.Windows.Forms.TextBox();
         this.txtIP = new System.Windows.Forms.TextBox();
         this.btnExit = new System.Windows.Forms.Button();
         this.errName = new System.Windows.Forms.ErrorProvider(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.errName)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(152, 127);
         this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(49, 17);
         this.label1.TabIndex = 0;
         this.label1.Text = "Name:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(125, 154);
         this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(76, 17);
         this.label2.TabIndex = 1;
         this.label2.Text = "IP Address";
         // 
         // btnEnterGame
         // 
         this.btnEnterGame.Location = new System.Drawing.Point(211, 242);
         this.btnEnterGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.btnEnterGame.Name = "btnEnterGame";
         this.btnEnterGame.Size = new System.Drawing.Size(141, 28);
         this.btnEnterGame.TabIndex = 2;
         this.btnEnterGame.Text = "Enter Game";
         this.btnEnterGame.UseVisualStyleBackColor = true;
         this.btnEnterGame.Click += new System.EventHandler(this.btnEnterGame_Click);
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(211, 118);
         this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(132, 22);
         this.txtName.TabIndex = 3;
         this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
         // 
         // txtIP
         // 
         this.txtIP.Location = new System.Drawing.Point(211, 150);
         this.txtIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.txtIP.Name = "txtIP";
         this.txtIP.Size = new System.Drawing.Size(132, 22);
         this.txtIP.TabIndex = 4;
         this.txtIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
         // 
         // btnExit
         // 
         this.btnExit.Location = new System.Drawing.Point(211, 278);
         this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(141, 28);
         this.btnExit.TabIndex = 5;
         this.btnExit.Text = "Exit";
         this.btnExit.UseVisualStyleBackColor = true;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // errName
         // 
         this.errName.ContainerControl = this;
         // 
         // Login
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(452, 321);
         this.Controls.Add(this.btnExit);
         this.Controls.Add(this.txtIP);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.btnEnterGame);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.MaximizeBox = false;
         this.Name = "Login";
         this.Text = "Login";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
         this.Load += new System.EventHandler(this.Login_Load);
         ((System.ComponentModel.ISupportInitialize)(this.errName)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.TextBox txtIP;
      private System.Windows.Forms.Button btnExit;
      private System.Windows.Forms.Button btnEnterGame;
      private System.Windows.Forms.ErrorProvider errName;
   }
}