using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorerGame
{
	internal class Map
	{
		public char[,] Atlas { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			Atlas = new char[Width, Height];
			GenerateMap();
		}

		private void GenerateMap()
		{
			for(int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					if(x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
					{
						Atlas[y, x] = '#';
					}
					else
					{
						Atlas[y, x] = ' ';
					}
				}
			}
		}

		public void Draw()
		{
			Console.Clear();
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Console.Write(Atlas[y, x]);
				}
                Console.WriteLine();
            }
		}
	}
}
