using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

/// <summary>
/// Game Data Class
/// </summary>
namespace TBQuestGame.DataLayer
{
    class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Zane",
                Age = 20,
                Title = Player.TitleName.Adventurer,
                Clan = Player.ClanType.HalfHuman,
                Health = 100,
                Lives = 3,
                Experience = 0,
                LocationId = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1), // Sword of Strength
                    new GameItemQuantity(GameItemById(2001), 5) // Gold Coin
                }
            };            
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 2;
            int columns = 2;

            Map gameMap = new Map(rows, columns);
                        
            // row 1
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Town of MillStone",
                Description = "The Town of MillStone Is souronded by fields and forest that the people can thrive on. " + " " +
                "But Beasts also lerk in the dark so beware. ",
                Accessible = true,
                ModifiyExperience = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1) // Elixar-Potion
                }
            };

            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "Yelma Forest",
                Description = "The Yelma Forest holds both treasure and reward. " +
                "But also treachery for wondering Adventurers looking for said treasure and rewards." ,
                Accessible = true,
                ModifyLives = -1,
                ModifiyExperience = +20,
                 GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4001), 1), // Astral Key
                    new GameItemQuantity(GameItemById(3001), 1) // Elixar-Potion
                }
            };
                        
            // row 2
            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 3,
                Name = "Fenral field",
                Description = "The Fenral field is a common destination for Adventurers." +
                "Is have some farms and wild animals across the way. ",
                Accessible = true,
                ModifiyExperience = +20,
                   GameItems = new ObservableCollection<GameItemQuantity>
                {
                   new GameItemQuantity(GameItemById(4002), 1), // Staff of Thorfin
                   new GameItemQuantity(GameItemById(2002), 1), // Diamond Coin
                   new GameItemQuantity(GameItemById(2001), 5), // Gold Coin
                }
            };

            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 4,
                Name = "Temple of Altaya",
                Description = "The Temple of Altaya is said to be built by demons and angels," +
                "but they have been at war for centurys. ",
                Accessible = false,
                RequiredLootId = 4001, // Astral Key
                ModifiyExperience = 50,
                ModifyLives = 3,
                RequiredExperience = 40,
                   GameItems = new ObservableCollection<GameItemQuantity>
                   {
                    new GameItemQuantity(GameItemById(1001), 1), // Duel Daggers
                    new GameItemQuantity(GameItemById(3001), 1), // Elixar-Potion
                    new GameItemQuantity(GameItemById(2003), 1) // Scroll of Athens
                   }
            };
            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Duel Daggers", 75, 1, 4, "Duel Daggers used for fast and agile attacks.", 10),
                new Weapon(1002, "Sword of Strength", 250, 1, 9, "A Sword that that amplifies the strength of the holder.", 20),
             
                new Treasure(2001, "Gold Coin", 10, Treasure.TreasureType.Gold, "Worth 24 karat gold coin", 1),
                new Treasure(2002, "Diamond Coin", 50, Treasure.TreasureType.Jewel, "A diamond shaped like a arrow head and quite valuable.", 1),
                new Treasure(2003, "Scroll of Athens", 10, Treasure.TreasureType.Scroll, "Said to be stolen by the Half Humans to advance there culture and Clan to the next level. ", 5),
              
                new Potion(3001, "Elixer of Satharia", 5, 40, 1, "A rare elixer from the Human clan extracted from the blood of Angels. Add 40 points of health.", 5),
               
                new Loot(4001, "Astral Key", 5, "Conjured by the Demon Clan to open Doors, hiding something you disire.", 5, "You have opened the Temple of Altaya", Loot.UseActionType.OPENLOCATION),
                new Loot(4002, "Staff of Thorfin", 5, "A metal staff enchanted by demons with a dark aura surrounding the staff", 5, "Grabbing the staff, you see shadows emerge from the staff and they pahse through you and you die.", Loot.UseActionType.KILLPLAYER)
            };
        }
    }
}
