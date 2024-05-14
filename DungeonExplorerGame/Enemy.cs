using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class Enemy : GameElement
	{
		public int HP { get; set; }
		
		public Enemy(int x, int y) : base(x, y)
		{
			HP = 50;
		}

		public override void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.Write('E');
		}
	}
}
