using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   class Stone : Resource
   {
      public static Bitmap bm = new Bitmap(nataC_Server.Properties.Resources.Stone1x1);
      public static new string mapImage = "Visuals(MAP)\\Stone1x1.png";

      public Stone()
      {

      }
      public override Bitmap getFile()
      {
         return bm;
      }

      public override int getTypeNum()
      {
         return 2;
      }
   }
}

//3 methods