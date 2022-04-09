using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace nataC_Server
{
   // Handles a stack of cards that represent a deck of development cards
   public class Deck
   {
      const int NUM_KNIGHTS = 14;
      const int NUM_VICT = 5;
      const int NUM_TERR = 2;
      const int NUM_MONOPOLY = 2;
      const int NUM_YEAR = 2;
      Stack<Card> deck;

      // Constructor: Create a stack of cards, fill it, and then shuffle it
      public Deck()
      {
         deck = new Stack<Card>();
         GenerateDeck(ref deck);
         Shuffle(ref deck);
      }

      // Shuffle the deck
      private void Shuffle(ref Stack<Card> deck)
      {
         Random rnd = new Random();
         var deckArray = deck.ToArray();
         deck.Clear();
         foreach (var element in deckArray.OrderBy(x => rnd.Next()))
            deck.Push(element);
      }

      // Fill up the deck the starting cards
      private void GenerateDeck(ref Stack<Card> deck)
      {
         FillDeckWithType(ref deck, NUM_KNIGHTS, Card.Type.KNIGHT);
         FillDeckWithType(ref deck, NUM_VICT, Card.Type.VICTORY);
         FillDeckWithType(ref deck, NUM_TERR, Card.Type.TERRITORY);
         FillDeckWithType(ref deck, NUM_MONOPOLY, Card.Type.MONOPOLY);
         FillDeckWithType(ref deck, NUM_YEAR, Card.Type.YEAR_OF_PLENTY);
      }

      // Add cards of given type cardAmount times into provided deck
      private void FillDeckWithType(ref Stack<Card> deck, int cardAmount, Card.Type cardType)
      {
         Card tempCard;
         for (int i = 0; i < cardAmount; i++)
         {
            tempCard = new Card(cardType);
            deck.Push(tempCard);
         }
      }

      // Takes the top card off the deck and returns it
      public Card GetTopCard()
      {
         return deck.Pop();
      }

      // Returns the number of cards in the deck
      public int GetCurrentDeckSize()
      {
         return deck.Count;
      }

      // Check if two decks are equal
      // Used for testing
      public static Boolean Equals(Deck deck1, Deck deck2)
      {
         Card compare1, compare2;
         for(int i = 0; i < deck1.deck.Count; i++)
         {
            compare1 = deck1.deck.Pop();
            compare2 = deck2.deck.Pop();
            if (compare1.CardType != compare2.CardType)
               return false;
         }

         return true;
      }
   }


}
