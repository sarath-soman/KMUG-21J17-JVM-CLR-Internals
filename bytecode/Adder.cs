using System;
namespace ExpressionToIL
{
	public class Adder
	{
		public int Add(int x, int y)
		{
			return x + y;
		}

		public static void Main()
		{
			int sum = new Adder().Add(10, 20);
			sum++;
			Console.WriteLine(sum);
		}
	}

}
