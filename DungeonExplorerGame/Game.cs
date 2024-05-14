using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class Game
	{
		public Map map;
		public Player player;
		public Enemy enemy;
		public List<Potion> potions = new List<Potion>();
		public Random rnd = new Random();

		public Game()
		{
			map = new Map(15, 15);
			player = new Player(1, 1);
			enemy = new Enemy(rnd.Next(1, map.Width - 1), rnd.Next(1, map.Width - 1));
			GeneratePotions();
		}

		public void GeneratePotions()
		{
			for (int i = 0; i < 5; i++)
			{
				int x = rnd.Next(1, map.Width - 1);
				int y = rnd.Next(1, map.Height - 1);
				int hpChange = rnd.Next(100) > 50 ? 10 : -10;
				potions.Add(new Potion(x, y, hpChange));
			}
		}

		public void StartGame()
		{
			bool running = true;
			do
			{
				map.Draw();
				foreach (Potion potion in potions)
				{
					potion.Draw();
				}
				player.Draw();
				enemy.Draw();
				ConsoleKey direction = Console.ReadKey(true).Key;
				player.Moving(direction, map);
				//TODO: enemy moving
				//TODO: fight with enemy, if on the same spot
				//TODO: drink potion


			} while (running && player.HP > 0);

			if (player.HP <= 0)
			{
                Console.WriteLine("YOU DIED");
            }
		}
	}
}
