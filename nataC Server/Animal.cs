using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   class Animal : Resource
   {
      public static Bitmap bm = new Bitmap(nataC_Server.Properties.Resources.Animal1x1);
      public static new string mapImage = "Visuals(MAP)\\Animal1x1.png";
      public Animal()
      {

      }
      public override Bitmap getFile()
      {
         return bm;
      }

      public override int getTypeNum()
      {
         return 4;
      }
   }
}

//3 methods