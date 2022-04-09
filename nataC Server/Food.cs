using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   class Food : Resource
   {
      public static Bitmap bm = new Bitmap(nataC_Server.Properties.Resources.Food1x1);
      public static new string mapImage = "Visuals(MAP)\\Food1x1.png";


      public Food()
      {

      }

      public override Bitmap getFile()
      {
         return bm;
      }
       public override int getTypeNum()
      {
         return 1;
      }
   }
}

//3 methods