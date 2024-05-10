using System;
using System.Linq;
using System.Collections.Generic;


namespace _1A2B
{
class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            while (true)
            {
                int[] computerDigits = Enumerable.Range(0, 10).OrderBy(x => random.Next()).Take(4).ToArray();

                Console.WriteLine("歡迎來到1A2B猜數字的遊戲～");
                Console.WriteLine("猜一組4位數字，每個數字之間用空格分開：");

                while (true)
                {
                    int[] guessDigits = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    if (guessDigits.Length != 4 || guessDigits.Any(digit => digit < 0 || digit > 9))
                    {
                        Console.WriteLine("請輸入正確的4位數字！");
                        continue;
                    }

                    var matches = computerDigits.Select((cd, index) =>
                    {
                        if (cd == guessDigits[index]) return 'A';
                        if (computerDigits.Contains(guessDigits[index])) return 'B';
                        return ' ';
                    }).ToArray();

                    int A = matches.Count(match => match == 'A');
                    int B = matches.Count(match => match == 'B');

                    Console.WriteLine($"判定結果是:{A}A{B}B\n");
                    Console.WriteLine("-------------------\n");

                    if (A == 4)
                    {
                        Console.WriteLine("恭喜你!!猜對了!!!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("錯了!再猜四個數字：");
                    }
                }

                Console.WriteLine("你要繼續玩嗎？(y/n): ");
                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() != "y")
                {
                    Console.WriteLine("遊戲結束，下次再來玩喔");
                    break;
                }
            }
        }
    }

}