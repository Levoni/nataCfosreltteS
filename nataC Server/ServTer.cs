using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nataC_Server
{
   public partial class ServTer : UserControl
   {
      Resource resource;
      public int rollNum;
      public int owner;
      public bool hasCity;
      public ServTer()
      {
         InitializeComponent();
         pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y + 1);
         owner = 0;
         hasCity = false;
      }

      public void CreateResource(int typeNum, int randNum,ref string type)
      {
         if (typeNum == 1)
         {
            resource = new Food();
            type += "1";
         }
         else if (typeNum == 2)
         {
            resource = new Stone();
            type += "2";
         }
         else if (typeNum == 3)
         {
            resource = new Wood();
            type += "3";
         }
         else if (typeNum == 4)
         {
            resource = new Animal();
            type += "4";
         }
         else
         {
            resource = new Desert();
            type += "5";
         }
         rollNum = randNum;


      }

      public void addrolltotext(ref string test)
      {
         test += rollNum;
      }


      private void pictureBox1_Click(object sender, EventArgs e)
      {
         Bitmap test = null;
         pictureBox1.Image = null;
      }

      public void reSizeTer(int width, int height)
      {
         double x = this.Width*.95;
         double y = this.Height * .95;
         pictureBox1.Size = new Size((int)x, (int)y);
         Bitmap map = resource.getFile();
         Bitmap newMap = new Bitmap(map, pictureBox1.Size.Width, pictureBox1.Size.Height);
         pictureBox1.Image = newMap;
         x = y = 0;
      }
      
      public int getResourceType()
      {
         return resource.getTypeNum();
      }
   }
}

//7 methods