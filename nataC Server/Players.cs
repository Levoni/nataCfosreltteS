using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace nataC_Server
{
   public class Players
   {
      public Socket soc;
      public int food;
      public int stone;
      public int wood;
      public int animal;
      public int VP;

      private const int NUM_CARD_TYPES = 5;
      private const int KNIGHT_CARD_INDEX = 0;
      private const int TERRITORY_CARD_INDEX = 1;
      private const int YOP_CARD_INDEX = 2;
      private const int MONOPOLY_CARD_INDEX = 3;
      private const int VP_CARD_INDEX = 4;
      private int[] cardCount;


      public string Name { get; set; }
      public Players(string pName, Socket s)
      {
         soc = s;
         Name = pName;
         food = 0;
         stone = 0;
         wood = 0;
         animal = 0;
         cardCount = new int[NUM_CARD_TYPES];
         VP = 0;
      }

      /// <summary>
      /// Constructor for testing only
      /// </summary>
      /// <param name="pName"></param>
      /// <param name="resourceCount"></param>
      public Players(string pName, int resourceCount)
      {
         Name = pName;
         food = resourceCount;
         stone = resourceCount;
         wood = resourceCount;
         animal = resourceCount;
         VP = resourceCount;
      }

      // Subtract resources and increase given deck card count
      public void BuyDevCard(string cardType)
      {
         //-----------------------------//
         // Insert resource subtraction //
         //-----------------------------//
         //food--;
         //animal--;
         //animal--;

         if (string.Equals(cardType, "KNIGHT"))
            cardCount[KNIGHT_CARD_INDEX]++;
         else if (string.Equals(cardType, "TERRITORY"))
            cardCount[TERRITORY_CARD_INDEX]++;
         else if (string.Equals(cardType, "YOP"))
            cardCount[YOP_CARD_INDEX]++;
         else if (string.Equals(cardType, "VP"))
            cardCount[VP_CARD_INDEX]++;
         else if (string.Equals(cardType, "MONOPOLY"))
            cardCount[MONOPOLY_CARD_INDEX]++;

      }

      public void UseDevCard(string cardType)
      {
         if (string.Equals(cardType, "KNIGHT"))
            cardCount[KNIGHT_CARD_INDEX]--;
         else if (string.Equals(cardType, "TERRITORY"))
            cardCount[TERRITORY_CARD_INDEX]--;
         else if (string.Equals(cardType, "YOP"))
            cardCount[YOP_CARD_INDEX]--;
         else if (string.Equals(cardType, "VP"))
            cardCount[VP_CARD_INDEX]--;
         else if (string.Equals(cardType, "MONOPOLY"))
            cardCount[MONOPOLY_CARD_INDEX]--;
      }


      // Get how many cards of given type the player has
      // If card type not found, return -1
      public int GetDevCardCount(string cardType)
      {
         if (string.Equals(cardType, "KNIGHT"))
            return cardCount[KNIGHT_CARD_INDEX];
         else if (string.Equals(cardType, "TERRITORY"))
            return cardCount[TERRITORY_CARD_INDEX];
         else if (string.Equals(cardType, "YOP"))
            return cardCount[YOP_CARD_INDEX];
         else if (string.Equals(cardType, "VP"))
            return cardCount[VP_CARD_INDEX];
         else if (string.Equals(cardType, "MONOPOLY"))
            return cardCount[MONOPOLY_CARD_INDEX];
         else
            return -1;
      }

      // Returns the total number of development cards the player has 
      public int GetTotalDevCards()
      {
         int cardCounter = 0;
         for (int i = 0; i < cardCount.Length; i++)
            cardCounter += cardCount[i];
         return cardCounter;
      }

      public bool AddResources(int type, bool rollNumIsCorrect, bool hasCity)
      {
         if (hasCity)
         {
            AddResource(type, rollNumIsCorrect,hasCity);
            return true;
         }
         return false;
      }

      public void AddResource(int type, bool rollNumIsCorrect,bool city = false)
      {
         if (rollNumIsCorrect)
         {
            if (city)
            {
               if (type == 1)
                  food += 2;
               else if (type == 2)
                  stone += 2;
               else if (type == 3)
                  wood += 2;
               else if (type == 4)
                  animal += 2;
            }
            else
            {
               if (type == 1)
                  food += 1;
               else if (type == 2)
                  stone += 1;
               else if (type == 3)
                  wood += 1;
               else if (type == 4)
                  animal += 1;
            }
         }
      }

      public void MinusResources(string type)
      {
         if(type == "ter")
         {
            stone--;
            wood--;
         }
         if(type == "city")
         {
            food--;
            stone--;
            wood--;
            animal--;
         }
         if(type == "devCard")
         {
            food--;
            animal -= 2;
         }
      }

        /// <summary>
        /// Check if player can buy a development card
        /// </summary>
        /// <returns>True only if player has enough resources to buy a dev card</returns>
      public bool CanBuyDevCard()
      {
         return food >= 1 && animal >= 2;
      }

      public void AddResource(string resource, int count)
      {
         switch(resource)
         {
            case "ANIMAL":
               animal += count;
               break;
            case "FOOD":
               food += count;
               break;
            case "STONE":
               stone += count;
               break;
            case "WOOD":
               wood += count;
               break;
         }
      }

      public string StealRandomResource()
      {
         Random rndGen = new Random();
         int randNum;
         int selected = 0;
         string resource = "";

         while (selected < 2)
         {
            if(food + stone + wood + animal == 0)
            {
               selected = 2;
            }
            else
            {
               randNum = rndGen.Next(1, 4);
               switch (randNum)
               {
                  case 1:
                     if (food > 0)
                     {
                        selected++;
                        food--;
                        resource = resource + "FOOD,";
                     }
                     break;
                  case 2:
                     if (stone > 0)
                     {
                        selected++;
                        stone--;
                        resource = resource + "STONE,";
                     }
                     break;
                  case 3:
                     if (wood > 0)
                     {
                        selected++;
                        wood--;
                        resource = resource + "WOOD,";
                     }
                     break;
                  case 4:
                     if (animal > 0)
                     {
                        selected++;
                        animal--;
                        resource = resource + "ANIMAL,";
                     }
                     break;
               }
            }
         }

         return resource;
      }

      public int StealResource(string resource)
      {
         int totalResource = 0;
         switch (resource)
         {
            case "ANIMAL":
               totalResource = animal;
               animal = 0;
               break;
            case "FOOD":
               totalResource = food;
               food = 0;
               break;
            case "STONE":
               totalResource = stone;
               stone = 0;
               break;
            case "WOOD":
               totalResource = wood;
               wood = 0;
               break;
         }

         return totalResource;
      }

   }
}

//4 methods