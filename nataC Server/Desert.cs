using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   class Desert : Resource
   {
      public static Bitmap bm = new Bitmap(nataC_Server.Properties.Resources.Desert1x1);
      public static new string mapImage = "Visuals(MAP)\\Desert1x1.png";
      public Desert()
      {

      }
      public override Bitmap getFile()
      {
         return bm;
      }

      public override int getTypeNum()
      {
         return 0;
      }
   }
}

//3 methods