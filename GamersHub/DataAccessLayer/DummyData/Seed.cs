using DataAccessLayer.DBContext;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DummyData
{
    public static class Seed
    {
        static GamersHubContext context = new GamersHubContext();
        public static void SeedData()
        {
            List<Game> games = new List<Game>
            {
                new Game(){GameName="Forza Horizon 5",Description="Dünyanın en iyi araçlarında sınırsız, eğlenceli sürücülük aksiyonuyla dolu Meksika'nın capcanlı açık dünya manzaralarını keşfedin. Üst düzey Horizon Ralli deneyiminde engebeli Sierra Nueva yollarını fethedin. Forza Horizon 5 oyunu gerekir, genişletme ayrı satılır.",Price=299.50,Size=110000,Rating=4.5,Version="V5.2",CreatorName="Playground Games"},

                new Game{GameName="Baldur's Gate 3",Description="Partini topla ve dostluk, ihanet, fedakârlık, hayatta kalma ve mutlak güç arzusuyla dolu bir hikâyede Unutulmuş Diyarlar'a dön.",Price=799.50,Size=150000,Rating=4.3,Version="V4.2",CreatorName="Larian Studios"},

                new Game{
                    GameName="Fireboy & Watergirl: Elements",Description="Help Fireboy and Watergirl explore the 7 Elemental temples!",Price=2.50,Size=177,Rating=5.0,Version="V222.2", CreatorName = "Oslo Albet"}
            };
            foreach (var game in games)
            {
                context.Games.Add(game);
            }
            context.SaveChanges();

            List<Category> categories = new List<Category>()
            {
                new Category{CategoryName="Aksiyon",Description="Aksiyon Oyunları Kategorisi"},
                new Category{CategoryName="Macera",Description="Macera Oyunları Kategorisi"},
                new Category{CategoryName="RYO",Description="RYO Oyunları Kategorisi"},
                new Category{CategoryName="Strateji",Description="Strateji Oyunları Kategorisi"},
                new Category{CategoryName="Simülasyon",Description="Simülasyon Oyunları Kategorisi"},
                new Category{CategoryName="Yarış",Description="Yarış Oyunları Kategorisi"},
                new Category{CategoryName="Spor",Description="Spor Oyunları Kategorisi"},
            };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            List<Image> images = new List<Image>
            {
                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/header.jpg?t=1692199916",AltText="Forza Horizon 5 Kapak Görseli",GameID=1},
                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/ss_cf56e25a0290556ba83229eb0ab370d10be0407c.600x338.jpg?t=1692199916",AltText="Forza Horizon 5 GamePlay Görseli", GameID=1},

                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/header.jpg?t=1692294127",AltText="Baldur's Gate 3 Kapak Görseli",GameID=2},
                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_c73bc54415178c07fef85f54ee26621728c77504.600x338.jpg?t=1692294127",AltText="Baldur's Gate 3 GamePlay Görseli",GameID=2},

                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1003480/header.jpg?t=1548336521",AltText="Fireboy & Watergirl: Elements Kapak Görseli",GameID=3},
                new Image{ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1003480/ss_ec9b416a28b562a72566d245189782265b2a2f33.600x338.jpg?t=1548336521",AltText="Fireboy & Watergirl: Elements GamePlay Görseli",GameID=3}
            };

            foreach (var image in images)
            {
                context.Images.Add(image);
            }
            context.SaveChanges();

            List<GameCategory> gameCategories = new List<GameCategory>
            {
                new GameCategory{GameId=1,CategoryId=1},
                new GameCategory{GameId=1,CategoryId=2},
                new GameCategory{GameId=1,CategoryId=6},
                new GameCategory{GameId=1,CategoryId=5},
                new GameCategory{GameId=1,CategoryId=7},

                new GameCategory{GameId=2,CategoryId=2},
                new GameCategory{GameId=2,CategoryId=3},
                new GameCategory{GameId=2,CategoryId=4},

                new GameCategory{GameId=3,CategoryId=1}



            };

            context.GameCategories.AddRange(gameCategories);
            context.SaveChanges();
        }
    }
}
