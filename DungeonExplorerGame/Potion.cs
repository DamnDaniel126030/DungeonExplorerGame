using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class Potion : GameElement
	{
		public int HPChange { get; set; }

		public Potion(int x, int y, int hpChange) : base(x, y)
		{
			HPChange = hpChange;
		}

		public override void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.Write(HPChange > 0 ? '+' : '-');
		}
	}
}
