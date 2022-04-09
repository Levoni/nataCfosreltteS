namespace nataC_fo_sreltteS
{
   partial class PlayerRequest
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
         this.btnOK = new System.Windows.Forms.Button();
         this.grpResource = new System.Windows.Forms.GroupBox();
         this.rdoP4 = new System.Windows.Forms.RadioButton();
         this.rdoP3 = new System.Windows.Forms.RadioButton();
         this.rdoP2 = new System.Windows.Forms.RadioButton();
         this.rdoP1 = new System.Windows.Forms.RadioButton();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.erpPlayer = new System.Windows.Forms.ErrorProvider(this.components);
         this.grpResource.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.erpPlayer)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(146, 244);
         this.btnOK.Margin = new System.Windows.Forms.Padding(2);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(103, 27);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // grpResource
         // 
         this.grpResource.Controls.Add(this.rdoP4);
         this.grpResource.Controls.Add(this.rdoP3);
         this.grpResource.Controls.Add(this.rdoP2);
         this.grpResource.Controls.Add(this.rdoP1);
         this.grpResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpResource.Location = new System.Drawing.Point(11, 11);
         this.grpResource.Margin = new System.Windows.Forms.Padding(2);
         this.grpResource.Name = "grpResource";
         this.grpResource.Padding = new System.Windows.Forms.Padding(2);
         this.grpResource.Size = new System.Drawing.Size(187, 229);
         this.grpResource.TabIndex = 3;
         this.grpResource.TabStop = false;
         this.grpResource.Text = "Select a player";
         // 
         // rdoP4
         // 
         this.rdoP4.AutoSize = true;
         this.rdoP4.Location = new System.Drawing.Point(5, 180);
         this.rdoP4.Margin = new System.Windows.Forms.Padding(2);
         this.rdoP4.Name = "rdoP4";
         this.rdoP4.Size = new System.Drawing.Size(95, 28);
         this.rdoP4.TabIndex = 3;
         this.rdoP4.TabStop = true;
         this.rdoP4.Text = "Player 4";
         this.rdoP4.UseVisualStyleBackColor = true;
         this.rdoP4.Click += new System.EventHandler(this.rdoP4_Click);
         // 
         // rdoP3
         // 
         this.rdoP3.AutoSize = true;
         this.rdoP3.Location = new System.Drawing.Point(5, 133);
         this.rdoP3.Margin = new System.Windows.Forms.Padding(2);
         this.rdoP3.Name = "rdoP3";
         this.rdoP3.Size = new System.Drawing.Size(95, 28);
         this.rdoP3.TabIndex = 2;
         this.rdoP3.TabStop = true;
         this.rdoP3.Text = "Player 3";
         this.rdoP3.UseVisualStyleBackColor = true;
         this.rdoP3.Click += new System.EventHandler(this.rdoP3_Click);
         // 
         // rdoP2
         // 
         this.rdoP2.AutoSize = true;
         this.rdoP2.Location = new System.Drawing.Point(5, 85);
         this.rdoP2.Margin = new System.Windows.Forms.Padding(2);
         this.rdoP2.Name = "rdoP2";
         this.rdoP2.Size = new System.Drawing.Size(95, 28);
         this.rdoP2.TabIndex = 1;
         this.rdoP2.TabStop = true;
         this.rdoP2.Text = "Player 2";
         this.rdoP2.UseVisualStyleBackColor = true;
         this.rdoP2.Click += new System.EventHandler(this.rdoP2_Click);
         // 
         // rdoP1
         // 
         this.rdoP1.AutoSize = true;
         this.rdoP1.Location = new System.Drawing.Point(5, 45);
         this.rdoP1.Margin = new System.Windows.Forms.Padding(2);
         this.rdoP1.Name = "rdoP1";
         this.rdoP1.Size = new System.Drawing.Size(95, 28);
         this.rdoP1.TabIndex = 0;
         this.rdoP1.TabStop = true;
         this.rdoP1.Text = "Player 1";
         this.rdoP1.UseVisualStyleBackColor = true;
         this.rdoP1.Click += new System.EventHandler(this.rdoP1_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::nataC_fo_sreltteS.Properties.Resources.KnightCard;
         this.pictureBox1.Location = new System.Drawing.Point(202, 23);
         this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(124, 217);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBox1.TabIndex = 5;
         this.pictureBox1.TabStop = false;
         // 
         // erpPlayer
         // 
         this.erpPlayer.ContainerControl = this;
         // 
         // PlayerRequest
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(340, 284);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.grpResource);
         this.Name = "PlayerRequest";
         this.Text = "PlayerRequest";
         this.grpResource.ResumeLayout(false);
         this.grpResource.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.erpPlayer)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.GroupBox grpResource;
      private System.Windows.Forms.RadioButton rdoP4;
      private System.Windows.Forms.RadioButton rdoP3;
      private System.Windows.Forms.RadioButton rdoP2;
      private System.Windows.Forms.RadioButton rdoP1;
      private System.Windows.Forms.ErrorProvider erpPlayer;
   }
}