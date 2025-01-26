using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _13_Generics
{
    //internal class Game
    //{
    //    private List<Player> players;
    //    private List<Karta> deck;
    //    private static string[] Masti = { "Hearts", "Diamonds", "Clubs", "Spades" };
    //    private static string[] Typy = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
    //    private static int[] Values = { 6, 7, 8, 9, 10, 11, 12, 13, 14 };

    //    public Game(List<string> playerNames)
    //    {
    //        if (playerNames.Count < 2)
    //        {
    //            throw new ArgumentException("There must be at least 2 players.");
    //        }

    //        players = playerNames.Select(name => new Player(name)).ToList();
    //        deck = new List<Karta>();

    //        foreach (var mast in Masti)
    //        {
    //            for (int i = 0; i < Typy.Length; i++)
    //            {
    //                deck.Add(new Karta(mast, Typy[i], Values[i]));
    //            }
    //        }

    //        ShuffleDeck();
    //        DealCards();
    //    }

    //    private void ShuffleDeck()
    //    {
    //        Random rng = new Random();
    //        deck = deck.OrderBy(card => rng.Next()).ToList();
    //    }

    //    private void DealCards()
    //    {
    //        int playerIndex = 0;
    //        foreach (var card in deck)
    //        {
    //            players[playerIndex].Cards.Enqueue(card);
    //            playerIndex = (playerIndex + 1) % players.Count;
    //        }
    //    }

    //    public void Play()
    //    {
    //        foreach (var player in players)
    //        {
    //            player.PrintCards();
    //            Console.WriteLine();
    //        }
    //        while (players.All(player => player.Cards.Count > 0))
    //        {
    //            List<Karta> playedCards = new List<Karta>();
    //            foreach (var player in players)
    //            {
    //                playedCards.Add(player.Cards.Dequeue());
    //                Console.WriteLine(player.Name + " have a " + player.Cards.Count + " cards");
    //            }

    //            var winnerCard = playedCards.OrderByDescending(card => card.Value).First();
    //            var winningPlayer = players.First(player => playedCards.Contains(winnerCard));
    //            foreach (var card in playedCards)
    //            {
    //                winningPlayer.Cards.Enqueue(card);
    //            }

    //            Console.WriteLine($"{winningPlayer.Name} wins this round and takes the cards: {string.Join(", ", playedCards)}");


    //            if (players.Any(player => player.Cards.Count == deck.Count))
    //            {
    //                break;
    //            }
    //        }

    //        var finalWinner = players.OrderByDescending(player => player.Cards.Count).First();
    //        Console.WriteLine($"{finalWinner.Name} wins the game!");
    //    }
    //}
    internal class Game
    {
        private List<Player> players;
        private List<Karta> deck;
        private static string[] Masti = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static string[] Typy = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        private static int[] Values = { 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public Game(List<string> playerNames)
        {
            if (playerNames.Count < 2)
            {
                throw new ArgumentException("There must be at least 2 players.");
            }

            players = playerNames.Select(name => new Player(name)).ToList();
            deck = new List<Karta>();

            foreach (var mast in Masti)
            {
                for (int i = 0; i < Typy.Length; i++)
                {
                    deck.Add(new Karta(mast, Typy[i], Values[i]));
                }
            }

            ShuffleDeck();
            DealCards();
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            deck = deck.OrderBy(card => rng.Next()).ToList();
        }

        private void DealCards()
        {
            int playerIndex = 0;
            foreach (var card in deck)
            {
                players[playerIndex].Cards.Add(card);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        public void Play()
        {
            foreach (var player in players)
            {
                player.PrintCards();
                Console.WriteLine();
            }
            while (players.All(player => player.Cards.Count > 0))
            {
                List<Karta> playedCards = new List<Karta>();
                foreach (var player in players)
                {
                    playedCards.Add(player.Cards[0]);
                    player.Cards.RemoveAt(0);
                    Console.WriteLine(player.Name + " have a " + player.Cards.Count + " cards");
                }

                var winnerCard = playedCards.OrderByDescending(card => card.Value).First();
                var winningPlayer = players.First(player => playedCards.Contains(winnerCard));
                foreach (var card in playedCards)
                {
                    winningPlayer.Cards.Add(card);
                }

                Console.WriteLine($"{winningPlayer.Name} wins this round and takes the cards: {string.Join(", ", playedCards)}");

                if (players.Any(player => player.Cards.Count == deck.Count))
                {
                    break;
                }
            }

            var finalWinner = players.OrderByDescending(player => player.Cards.Count).First();
            Console.WriteLine($"{finalWinner.Name} wins the game!");
        }
    }
}

