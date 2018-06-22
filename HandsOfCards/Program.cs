using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            var PlayersHands = GetPlayersHands(data);
            var SumOfCards = GetSumOfCards(PlayersHands);
            PrintAnswer(SumOfCards);                 
        }

        private static void PrintAnswer(Dictionary<string, int> sumOfCards)
        {
            foreach (var item in sumOfCards)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        private static Dictionary<string, int> GetSumOfCards(Dictionary<string, List<string>> playersHands)
        {
            var SumOfCards = new List<int>();
            var TotalSum = new List<int>();
            var tempDictionary = new Dictionary<string, int>();

            foreach (var player in playersHands)
            {            
                foreach (var hand in player.Value)
                {                  
                    int power = hand[0];
                    int type = hand[hand.Length - 1];                   
                    var sum = 0;

                    switch (power)
                    {
                        case '2': power = 2; break;
                        case '3': power = 3; break;
                        case '4': power = 4; break;
                        case '5': power = 5; break;
                        case '6': power = 6; break;
                        case '7': power = 7; break;
                        case '8': power = 8; break;
                        case '9': power = 9; break;
                        case 'J': power = 11; break;
                        case 'Q': power = 12; break;
                        case 'K': power = 13; break;
                        case 'A': power = 14; break;
                        default: power = 10; break;

                    }

                    switch (type)
                    {
                        case 'S': type = 4; break;
                        case 'H': type = 3; break;
                        case 'D': type = 2; break;
                        case 'C': type = 1; break;
                    }

                    sum = power * type;
                    SumOfCards.Add(sum);                  
                }

                List<int> summedList = SumOfCards.Distinct().ToList();
                var sumOfAllCards = summedList.Sum();
                TotalSum.Add(sumOfAllCards);
                SumOfCards.Clear();
                summedList.Clear();
                tempDictionary.Add(player.Key, sumOfAllCards);
            }

            return tempDictionary;
        }

        private static Dictionary<string, List<string>> GetPlayersHands(string data)
        {
            var PlayersCards = new Dictionary<string, List<string>>();

            while (data != "JOKER")
            {
                var input = data.Split(',', ':').Select(x => x.Trim()).ToArray();
                var player = input[0];

                if (!PlayersCards.ContainsKey(player))
                {
                    PlayersCards.Add(player, new List<string>());
                }

                for (int i = 1; i < input.Length; i++)
                {                   
                    PlayersCards[player].Add(input[i]);
                }
            
                data = Console.ReadLine();
            }

            return PlayersCards;
        }
    }
}
