using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   class Wood : Resource
   {
      public static Bitmap bm = new Bitmap(nataC_Server.Properties.Resources.Wood1x1);
      public static new string mapImage = "Visuals(MAP)\\Wood1x1.png";
      public Wood()
      {

      }

      public override Bitmap getFile()
      {
         return bm;
      }

      public override int getTypeNum()
      {
         return 3;
      }
   }
}

//3 methods