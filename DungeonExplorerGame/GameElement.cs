using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class GameElement
	{
		public int X {  get; set; }
		public int Y { get; set; }

		public GameElement(int x, int y)
		{
			X = x;
			Y = y;
		}

		public virtual void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.WriteLine("?");
		}
	}
}
