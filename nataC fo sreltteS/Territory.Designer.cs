namespace nataC_fo_sreltteS
{
   partial class Territory
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Territory));
         this.MapImage = new System.Windows.Forms.PictureBox();
         this.lblRollId = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.MapImage)).BeginInit();
         this.SuspendLayout();
         // 
         // MapImage
         // 
         this.MapImage.Image = ((System.Drawing.Image)(resources.GetObject("MapImage.Image")));
         this.MapImage.Location = new System.Drawing.Point(0, 0);
         this.MapImage.Margin = new System.Windows.Forms.Padding(0);
         this.MapImage.Name = "MapImage";
         this.MapImage.Size = new System.Drawing.Size(63, 72);
         this.MapImage.TabIndex = 0;
         this.MapImage.TabStop = false;
         this.MapImage.Click += new System.EventHandler(this.pictureBox1_Click);
         this.MapImage.MouseEnter += new System.EventHandler(this.MapImage_MouseEnter);
         this.MapImage.MouseLeave += new System.EventHandler(this.MapImage_MouseLeave);
         this.MapImage.MouseHover += new System.EventHandler(this.MapImage_MouseHover);
         // 
         // lblRollId
         // 
         this.lblRollId.AutoSize = true;
         this.lblRollId.BackColor = System.Drawing.Color.Transparent;
         this.lblRollId.Font = new System.Drawing.Font("Palatino Linotype", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRollId.ForeColor = System.Drawing.Color.Transparent;
         this.lblRollId.Location = new System.Drawing.Point(0, 0);
         this.lblRollId.Name = "lblRollId";
         this.lblRollId.Size = new System.Drawing.Size(31, 37);
         this.lblRollId.TabIndex = 1;
         this.lblRollId.Text = "1";
         this.lblRollId.Click += new System.EventHandler(this.lblRollId_Click);
         this.lblRollId.MouseEnter += new System.EventHandler(this.lblRollId_MouseEnter);
         this.lblRollId.MouseLeave += new System.EventHandler(this.lblRollId_MouseLeave);
         this.lblRollId.MouseHover += new System.EventHandler(this.lblRollId_MouseHover);
         // 
         // Territory
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Black;
         this.Controls.Add(this.lblRollId);
         this.Controls.Add(this.MapImage);
         this.Margin = new System.Windows.Forms.Padding(0);
         this.Name = "Territory";
         this.Size = new System.Drawing.Size(72, 72);
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Territory_MouseClick);
         this.MouseLeave += new System.EventHandler(this.Territory_MouseLeave);
         ((System.ComponentModel.ISupportInitialize)(this.MapImage)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox MapImage;
      private System.Windows.Forms.Label lblRollId;
   }
}
