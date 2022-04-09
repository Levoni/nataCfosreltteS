namespace nataC_fo_sreltteS
{
   partial class ResourceRequest
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
         this.grpResource = new System.Windows.Forms.GroupBox();
         this.rdoWood = new System.Windows.Forms.RadioButton();
         this.rdoStone = new System.Windows.Forms.RadioButton();
         this.rdoFood = new System.Windows.Forms.RadioButton();
         this.rdoAnimal = new System.Windows.Forms.RadioButton();
         this.btnOK = new System.Windows.Forms.Button();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.erpYoP = new System.Windows.Forms.ErrorProvider(this.components);
         this.grpResource.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.erpYoP)).BeginInit();
         this.SuspendLayout();
         // 
         // grpResource
         // 
         this.grpResource.Controls.Add(this.rdoWood);
         this.grpResource.Controls.Add(this.rdoStone);
         this.grpResource.Controls.Add(this.rdoFood);
         this.grpResource.Controls.Add(this.rdoAnimal);
         this.grpResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpResource.Location = new System.Drawing.Point(7, 14);
         this.grpResource.Margin = new System.Windows.Forms.Padding(2);
         this.grpResource.Name = "grpResource";
         this.grpResource.Padding = new System.Windows.Forms.Padding(2);
         this.grpResource.Size = new System.Drawing.Size(187, 229);
         this.grpResource.TabIndex = 0;
         this.grpResource.TabStop = false;
         this.grpResource.Text = "Select a resource";
         // 
         // rdoWood
         // 
         this.rdoWood.AutoSize = true;
         this.rdoWood.Location = new System.Drawing.Point(5, 180);
         this.rdoWood.Margin = new System.Windows.Forms.Padding(2);
         this.rdoWood.Name = "rdoWood";
         this.rdoWood.Size = new System.Drawing.Size(79, 28);
         this.rdoWood.TabIndex = 3;
         this.rdoWood.TabStop = true;
         this.rdoWood.Text = "Wood";
         this.rdoWood.UseVisualStyleBackColor = true;
         this.rdoWood.Click += new System.EventHandler(this.rdoWood_Click);
         // 
         // rdoStone
         // 
         this.rdoStone.AutoSize = true;
         this.rdoStone.Location = new System.Drawing.Point(5, 133);
         this.rdoStone.Margin = new System.Windows.Forms.Padding(2);
         this.rdoStone.Name = "rdoStone";
         this.rdoStone.Size = new System.Drawing.Size(77, 28);
         this.rdoStone.TabIndex = 2;
         this.rdoStone.TabStop = true;
         this.rdoStone.Text = "Stone";
         this.rdoStone.UseVisualStyleBackColor = true;
         this.rdoStone.Click += new System.EventHandler(this.rdoStone_Click);
         // 
         // rdoFood
         // 
         this.rdoFood.AutoSize = true;
         this.rdoFood.Location = new System.Drawing.Point(5, 85);
         this.rdoFood.Margin = new System.Windows.Forms.Padding(2);
         this.rdoFood.Name = "rdoFood";
         this.rdoFood.Size = new System.Drawing.Size(73, 28);
         this.rdoFood.TabIndex = 1;
         this.rdoFood.TabStop = true;
         this.rdoFood.Text = "Food";
         this.rdoFood.UseVisualStyleBackColor = true;
         this.rdoFood.Click += new System.EventHandler(this.rdoFood_Click);
         // 
         // rdoAnimal
         // 
         this.rdoAnimal.AutoSize = true;
         this.rdoAnimal.Location = new System.Drawing.Point(5, 45);
         this.rdoAnimal.Margin = new System.Windows.Forms.Padding(2);
         this.rdoAnimal.Name = "rdoAnimal";
         this.rdoAnimal.Size = new System.Drawing.Size(86, 28);
         this.rdoAnimal.TabIndex = 0;
         this.rdoAnimal.TabStop = true;
         this.rdoAnimal.Text = "Animal";
         this.rdoAnimal.UseVisualStyleBackColor = true;
         this.rdoAnimal.Click += new System.EventHandler(this.rdoAnimal_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(142, 247);
         this.btnOK.Margin = new System.Windows.Forms.Padding(2);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(103, 27);
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::nataC_fo_sreltteS.Properties.Resources.YoPCard;
         this.pictureBox1.Location = new System.Drawing.Point(198, 26);
         this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(124, 217);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBox1.TabIndex = 2;
         this.pictureBox1.TabStop = false;
         // 
         // erpYoP
         // 
         this.erpYoP.ContainerControl = this;
         // 
         // ResourceRequest
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(333, 287);
         this.ControlBox = false;
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.grpResource);
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "ResourceRequest";
         this.Text = "Year of Plenty";
         this.grpResource.ResumeLayout(false);
         this.grpResource.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.erpYoP)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox grpResource;
      private System.Windows.Forms.RadioButton rdoWood;
      private System.Windows.Forms.RadioButton rdoStone;
      private System.Windows.Forms.RadioButton rdoFood;
      private System.Windows.Forms.RadioButton rdoAnimal;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.ErrorProvider erpYoP;
   }
}