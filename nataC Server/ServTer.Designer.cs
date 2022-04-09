namespace nataC_Server
{
   partial class ServTer
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServTer));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.lblRollID = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
         this.pictureBox1.InitialImage = null;
         this.pictureBox1.Location = new System.Drawing.Point(0, 0);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(150, 147);
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
         // 
         // lblRollID
         // 
         this.lblRollID.AutoSize = true;
         this.lblRollID.BackColor = System.Drawing.Color.Transparent;
         this.lblRollID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRollID.Location = new System.Drawing.Point(61, 60);
         this.lblRollID.Name = "lblRollID";
         this.lblRollID.Size = new System.Drawing.Size(29, 31);
         this.lblRollID.TabIndex = 1;
         this.lblRollID.Text = "1";
         // 
         // ServTer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Black;
         this.Controls.Add(this.lblRollID);
         this.Controls.Add(this.pictureBox1);
         this.Name = "ServTer";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label lblRollID;
   }
}
