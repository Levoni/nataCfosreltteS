using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nataC_Server
{
   // Represents a development card
   public class Card
   {
      public enum Type { KNIGHT, VICTORY, TERRITORY, MONOPOLY, YEAR_OF_PLENTY }

      private Type currType;

      // Readonly property to get the current card type
      public Type CardType
      {
         get { return currType; }
      }

      // Constructor to create a card of certain card type
      public Card(Type cardType)
      {
         currType = cardType;
      }

   }
}
