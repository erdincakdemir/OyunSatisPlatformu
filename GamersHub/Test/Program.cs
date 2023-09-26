using DataAccessLayer.Concreate.AdoNet;
using Entity.POCO;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdoGame ado = new AdoGame();

            //bool result = ado.Add(new Game { GameName = "Deneme2", Description = "Test Açıklaması2", CreatorName = "Grup 212", Price = 350.60, Rating = 4.6, Size = 400.25, Version = "V1.3" });
            //if (result)
            //{
            //    Console.WriteLine("Oyun Eklendi!");
            //}
            //else
            //{
            //    Console.WriteLine("Oyun Eklenemedi!");

            //}
            //Console.WriteLine("Oyun İsmi Gir : ");
            //string oyunİsmi = Console.ReadLine();
            //if (!String.IsNullOrEmpty(oyunİsmi))
            //{
            //    Game game = ado.Get(3);
            //    var result = ado.Update(new Game { Id = game.Id, GameName = oyunİsmi, Active = game.Active, Deleted = game.Deleted, CreatedTime = game.CreatedTime, UpdatedTime = DateTime.Now, CreatorName = game.CreatorName, Description = game.Description, Price = game.Price, Size = game.Size, Rating = game.Rating, Version = "V1.4" });

            //    if (result)
            //    {
            //        Console.WriteLine("Oyun Güncellendi!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Oyun Güncellenemedi!");

            //    }

            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Oyun İsmi Alanı Boş Geçilemez*");
            //}

            var game = ado.Get(3);
            bool sonuc = ado.Delete(game);
            if (sonuc)
            {
                Console.WriteLine("Silindi");
            }
            else
            {
                Console.WriteLine("Silinmedi");
            }

            //foreach (var item in result)
            //{
            //    console.writeline(new string('*', 50));
            //    console.writeline();
            //    console.writeline("oyun ıd : " + result.ıd);
            //    console.writeline("oyun ismi : " + result.gamename);
            //    console.writeline("oyun fiyatı : " + result.price);
            //    console.writeline("oyun açıklama : " + result.description);
            //    console.writeline("oyun yazar ismi : " + result.creatorname);
            //    console.writeline("oyun yazar ismi : " + result.version);
            //    console.writeline("oyun yazar ismi : " + result.rating);
            //    console.writeline("oyun yazar ismi : " + result.size);
            //    console.writeline();
            //    console.writeline(new String('*', 50));

            //}




            Console.ReadKey();

        }
    }
}
