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
				Console.Clear();

				map.Draw();

				Potion potionPickUp = potions.FirstOrDefault(potion => potion.X == player.X && potion.Y == player.Y);
				if (potionPickUp != null)
				{
					player.HP += potionPickUp.HPChange;
					potions.Remove(potionPickUp);
					Console.WriteLine($"You've found a potion! Your current health changed to: {player.HP}");
				}

				if (player.X == enemy.X && player.Y == enemy.Y)
				{
					Fighting();
					Console.WriteLine($"You had a fight with the enemy!\nYour new hp: {player.HP}\nThe enemy's new hp: {enemy.HP}");
				}

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

				EnemyMoving();



			} while (running && player.HP > 0);

			if (player.HP <= 0)
			{
                Console.WriteLine("YOU DIED");
            }
		}

		private void EnemyMoving()
		{
			int dx = rnd.Next(-1, 2);
			int dy = rnd.Next(-1, 2);

			int newX = enemy.X + dx;
			int newY = enemy.Y + dy;

			if (newX >= 1 && newX < map.Width - 1 && map.Atlas[enemy.Y, newX] == ' ')
			{
				enemy.X = newX;
			}
			if (newY >= 1 && newY < map.Height - 1 && map.Atlas[newY, enemy.X] == ' ')
			{
				enemy.Y = newY;
			}
		}

		private void Fighting()
		{
			player.HP -= rnd.Next(10, 30);
			enemy.HP -= rnd.Next(5, 20);
		}
	}
}
