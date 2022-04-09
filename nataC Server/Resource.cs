using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nataC_Server
{
   abstract public class Resource
   {
      protected static string mapImage;
      abstract public Bitmap getFile();

      abstract public int getTypeNum();
   }
}