using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nataC_fo_sreltteS
{
    // Stores data of a single player
    public class Player
    {
        private const int NUM_CARD_TYPES = 5;
        private const int KNIGHT_CARD_INDEX = 0;
        private const int TERRITORY_CARD_INDEX = 1;
        private const int YOP_CARD_INDEX = 2;
        private const int MONOPOLY_CARD_INDEX = 3;
        private const int VP_CARD_INDEX = 4;

        public int vp { get; set; }
        public int animal { get; set; }
        public int food { get; set; }
        public int stone { get; set; }
        public int wood { get; set; }

        private int numOfTerritory;
        private int numOfCity;

        private int[] cardCount;
        public int totalCards;

        public string name { get; set; }

        public Player()
        {
            animal = food = stone = wood = 0;
            numOfTerritory = numOfCity = 0;
            vp = 0;

            cardCount = new int[NUM_CARD_TYPES];
            totalCards = 0;
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
         totalCards++;
        }

      public void setDevCards(int cardAmount)
      {
         totalCards = cardAmount;
      }

      public void UseDevCard(string cardType)
      {
         //-----------------------------//
         // Insert resource subtraction //
         //-----------------------------//
         //food--;
         //animal--;
         //animal--;

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
         totalCards--;
      }

      public int GetTotalDevCards()
      {
         return totalCards;
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

        // Subtract the resources needed to buy a territory and increment territory count
        public void BuyTerritory()
        {
            stone--;
            wood--;
            numOfTerritory++;
        }

        // Subtract the resources needed to buy a territory and increment city count
        public void BuyCity()
        {
            food--;
            stone--;
            wood--;
            animal--;
            numOfCity++;
        }

        // Returns totals amount of resources
        public int GetTotalResources()
        {
            return food + animal + stone + wood;
        }

        public void SetResources(int inFood, int inStone, int inWood, int inAnimal)
        {
            food = inFood;
            stone = inStone;
            wood = inWood;
            animal = inAnimal;
        }

        // Handle Territory card
        public void AddFreeTerritory()
        {
            numOfTerritory++;
        }

    }
}
