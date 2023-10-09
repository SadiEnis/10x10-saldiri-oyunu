using System;
using System.Threading;

namespace _10x10SaldiriOyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] OyunTahtası = new string[12, 12];
            int zar;
            int sutun, satir;

            Contents contents = new Contents();
            Player oyuncu1 = new Player();
            Player oyuncu2 = new Player();

            contents.Menu();

            Console.Write("Birinci oyuncunun adi: ");
            oyuncu1.Name = Console.ReadLine();

            Console.Write("İkinci oyuncunun adi: ");
            oyuncu2.Name = Console.ReadLine();

            Console.Write("Birinci oyuncu işaretini seçsin: ");
            string sign = Console.ReadLine();
            if (sign == "0")
            {
                oyuncu1._Sign = "0";
                oyuncu2._Sign = "1";
            }
            else if (sign == "1")
            {
                oyuncu1._Sign = "1";
                oyuncu2._Sign = "0";
            }
            else
            {
                Console.WriteLine("Hatalı girdi yaptın uygun giriş yap.");
                return;
            }

            contents.TahtaDoldur(OyunTahtası);
            contents.TahtaYazdir(OyunTahtası);
            Console.WriteLine("\n{0} Başlıyor..", oyuncu1.Name);
            while (true)
            {
                if (contents.Kazanan(OyunTahtası) != null)
                {
                    if (contents.Kazanan(OyunTahtası) == "x")
                        Console.WriteLine("x kazandı.");
                    else if (contents.Kazanan(OyunTahtası) == "o")
                        Console.WriteLine("o kazandı.");
                    break;
                }
                else
                {
                    Console.Write("{0} ZarDeğeri: ", oyuncu1.Name);
                    Thread.Sleep(1500);
                    zar = contents.ZarAt();
                    Console.WriteLine(zar);

                    for (int i = 1; i <= zar; i++)
                    {
                        Console.Write("Almak istediğiniz bölgenin sütun değerini giriniz: ");
                        
                        sutun = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Almak istediğiniz bölgenin satır değerini giriniz: ");
                        satir = Convert.ToInt32(Console.ReadLine());

                        if (!contents.UygunAlan(OyunTahtası, oyuncu1.Sign, sutun - 1, satir - 1))
                        {
                            i++;
                            Console.WriteLine("Hatalı bölge seçtiniz bir hakkınızı boşa harcadınız.");
                        }
                        else
                        {
                            contents.TahtaDegistir(OyunTahtası, oyuncu1.Sign, sutun, satir);
                            contents.TahtaYazdir(OyunTahtası);
                        }
                    }

                    Console.Write("{0} ZarDeğeri: ", oyuncu2.Name);
                    Thread.Sleep(1500);
                    zar = contents.ZarAt();
                    Console.WriteLine(zar);

                    for (int i = 1; i <= zar; i++)
                    {
                        Console.Write("Almak istediğiniz bölgenin sütun değerini giriniz: ");
                        sutun = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Almak istediğiniz bölgenin satır değerini giriniz: ");
                        satir = Convert.ToInt32(Console.ReadLine());

                        if (!contents.UygunAlan(OyunTahtası, oyuncu2.Sign, sutun - 1, satir - 1))
                        {
                            i++;
                            Console.WriteLine("Hatalı bölge seçtiniz bir hakkınızı boşa harcadınız.");
                        }
                        else
                        {
                            contents.TahtaDegistir(OyunTahtası, oyuncu2.Sign, sutun, satir);
                            contents.TahtaYazdir(OyunTahtası);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
