using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBlackJack
{
    public class CardDeck
    {
        enum Suits
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }
        public CardDeck()
        {
            {
                int i = 0;
                foreach (string s in numbers)
                {
                    cards[i] = new Card(Suits.Clubs, s);
                    i++;

                }
                foreach (string s in numbers)
                {
                    cards[i] = new Card(Suits.Spades, s);
                    i++;

                }
                foreach (string s in numbers)
                {
                    cards[i] = new Card(Suits.Hearts, s);
                    i++;

                }
                foreach (string s in numbers)
                {
                    cards[i] = new Card(Suits.Diamonds, s);
                    i++;

                }
            }
        }

        class Card
        {
            protected Suits suit;
            protected string cardvalue;
            public Card()
            {
            }
            public Card(Suits suit2, string cardvalue2)
            {
                suit = suit2;
                cardvalue = cardvalue2;
            }
            public override string ToString()
            {
                return string.Format("{0} of {1}", cardvalue, suit);
            }
        }

        Card[] cards = new Card[52];
        string[] numbers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "J", "Q", "K" };
    }
}
