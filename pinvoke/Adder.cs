using System;
using System.Runtime.InteropServices;

namespace Adder
{
	public class Adder
	{
        [DllImport("./libadder.so")]
		public static extern int Add(int x, int y);		

		public static void Main()
		{
			int sum = Add(10, 20);			
			Console.WriteLine(sum);
		}
	}

}
