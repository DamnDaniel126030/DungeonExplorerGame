using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class Player : GameElement
	{
		public int HP { get; set; }

		public Player(int x, int y) : base(x, y)
		{
			HP = 100;
		}

		public override void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.Write('P');
		}

		public void Moving(ConsoleKey direction, Map map)
		{
			switch (direction)
			{
				case ConsoleKey.UpArrow:
					if (Y > 0 && map.Atlas[Y - 1, X] == ' ')
					{
						Y--;
					}
					break;
				case ConsoleKey.DownArrow:
					if (Y < map.Height - 1 && map.Atlas[Y + 1, X] == ' ')
					{
						Y++;
					}
					break;
				case ConsoleKey.LeftArrow:
					if (X > 0 && map.Atlas[Y, X - 1] == ' ')
					{
						X--;
					}
					break;
				case ConsoleKey.RightArrow:
					if (X < map.Width - 1 && map.Atlas[Y, X + 1] == ' ')
					{
						X++;
					}
					break;
				default:
                    Console.WriteLine("You can only move with the arrow keys");
					break;

            }
		}
	}
}
