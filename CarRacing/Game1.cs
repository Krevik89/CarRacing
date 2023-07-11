using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRacing.Deck;

namespace CarRacing
{
    internal class Game1
    {
        private List<Player> players;
        private Deck deck;
        private int currentPlayerIndex;

        public Game1(List<Player> players)
        {
            if (players == null || players.Count < 2)
            {
                throw new ArgumentException("Должно быть не менее двух игроков");
            }

            this.players = players;
            this.deck = new Deck();
            this.deck.Shuffle();
            this.currentPlayerIndex = 0;

            int cardsPerPlayer = deck.Count / players.Count;
            for (int i = 0; i < players.Count; i++)
            {
                List<Card> playerCards = deck.GetCards(cardsPerPlayer);
                players[i].AddCards(playerCards);
            }
        }

        public void Play()
        {
            while (!IsGameOver())
            {
                Card highestCard = null;
                int highestCardPlayerIndex = -1;
                bool isTie = false;

                for (int i = 0; i < players.Count; i++)
                {
                    Card currentCard = players[i].PlayCard();
                    Console.WriteLine($"{players[i].Name} играет {currentCard}");

                    if (highestCard == null || currentCard.Value > highestCard.Value)
                    {
                        highestCard = currentCard;
                        highestCardPlayerIndex = i;
                        isTie = false;
                    }
                    else if (currentCard.Value == highestCard.Value)
                    {
                        isTie = true;
                    }
                }

                if (!isTie)
                {
                    Console.WriteLine($"{players[highestCardPlayerIndex].Name} забирает карты");
                    players[highestCardPlayerIndex].AddCards(GetCards());
                }
                else
                {
                    Console.WriteLine("Ничья, карты остаются на столе");
                }

                NextPlayer();
            }

            Console.WriteLine($"{players[currentPlayerIndex].Name} победил!");
        }

        private List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            foreach (Player player in players)
            {
                cards.AddRange(player.GetCards());
            }
            return cards;
        }

        private bool IsGameOver()
        {
            foreach (Player player in players)
            {
                if (player.GetCardCount() == deck.Count)
                {
                    return true;
                }
            }
            return false;
        }

        private void NextPlayer()
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }
        }
    }

    public class Player
    {
        private List<Card> cards;

        public string Name { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.cards = new List<Card>();
        }

        public void AddCards(List<Card> newCards)
        {
            cards.AddRange(newCards);
        }

        public List<Card> GetCards()
        {
            List<Card> playerCards = new List<Card>(cards);
            cards.Clear();
            return playerCards;
        }

        public int GetCardCount()
        {
            return cards.Count;
        }

        public Card PlayCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("У игрока нет карт");
            }

            Card cardToPlay = cards[0];
            cards.RemoveAt(0);
            return cardToPlay;
        }
    }

    public class Deck
    {
        private List<Card> cards;
        private static readonly Random random = new Random();

        public int Count => cards.Count;

        public Deck()
        {
            cards = new List<Card>();
            for (int value = 6; value <= 14; value++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i + 1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public List<Card> GetCards(int count)
        {
            if (count > cards.Count)
            {
                throw new ArgumentException("Недостаточно карт в колоде");
            }

            List<Card> drawnCards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                drawnCards.Add(cards[0]);
                cards.RemoveAt(0);
            }

            return drawnCards;
        }
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public class Card
        {
            public Suit Suit { get; private set; }
            public int Value { get; private set; }

            public Card(Suit suit, int value)
            {
                this.Suit = suit;
                this.Value = value;
            }

            public override string ToString()
            {
                string valueString;
                switch (Value)
                {
                    case 6: valueString = "6"; break;
                    case 7: valueString = "7"; break;
                    case 8: valueString = "8"; break;
                    case 9: valueString = "9"; break;
                    case 10: valueString = "10"; break;
                    case 11: valueString = "валет"; break;
                    case 12: valueString = "дама"; break;
                    case 13: valueString = "король"; break;
                    case 14: valueString = "туз"; break;
                    default: valueString = ""; break;
                }
                return $"{valueString} {Suit}";
            }
        }
    }
}
