using System;

namespace _10x10SaldiriOyunu
{
    public class Contents
    {
        int num;
        public void Menu()
        {
            Console.WriteLine("/*--------------------*\\\n");
            Console.WriteLine("Saldırı Oyununa Hoşgeldiniz\n");
            Console.WriteLine("/*--------------------*\\\n");
            Console.WriteLine("Kurallar\n" +
                "İki oyuncunun da oyun başında 10x10 alan içinde yarı yarıya bölgesi bulunur.\n" +
                "Oyuncular sırayla zar atar ve gelen 1-6 sayıyı rakibinin kendine sınırı olan bir bölgesinden ele geçirir.\n" +
                "Her iki oyuncunun da işareti bulunur (0:x | 1:o) ve bu işareti tüm alana yaymaya çalışır." +
                "Tüm alanı kendi işareti ile kaplayan oyuncu oyunu kazanır.\n");
            Console.WriteLine("/*--------------------*\\\n");
        }
        public int ZarAt()
        {
            Random rnd = new Random();
            return rnd.Next(1,6);
        }
        public void TahtaDoldur(string[,] table) // Tahta eksik -- Hata var
        {
            for (int j = 0; j < 10;  j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i >= 0 && i <= 4)
                    {
                        table[i, j] = "x";
                    }
                    else if (i >= 5 && i <= 9)
                    {
                        table[i, j] = "o";
                    }
                }
            }
        }
        public void TahtaYazdir(string[,] table)
        {
            for (int j = 0; j < 12; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    Console.Write(table[i, j]);
                    if (i == 11)
                        Console.WriteLine();
                }
            }
        }
        public bool UygunAlan(string[,] table, string userSign, int i, int j)
        {
            if (table[i, j - 1] == userSign || table[i, j + 1] == userSign ||
                table[i - 1, j] == userSign || table[i + 1, j] == userSign)
                return true;
            else
                return false;
        }
        public void TahtaDegistir(string[,] table, string userSign, int i, int j)
        {
            table[i - 1, j - 1] = userSign;
        }
        public string Kazanan(string[,] table)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (table[i, j] == "x")
                        num++;
                }
            }
            if (num == 100)
            {
                return "x";
            }
            else if (num == 0)
                return "o";
            else
                return null;
        }
    }
}
