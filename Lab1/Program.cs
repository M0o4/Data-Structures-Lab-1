using System;
using System.Diagnostics;

namespace Lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			
			int a, m;

			int x, y;

			string aAsString, mAsString;
			
			Console.WriteLine("ФИО: Индрей Владислав Федорович\nГруппа: 2-5\n");

			do
			{
				Console.Write("Введите целое число больше 0: ");
				aAsString = Console.ReadLine();

				if (!int.TryParse(aAsString, out a))
				{
					Console.WriteLine("Ошибка ввода, попробуйте снова!");
				}else if (a < 0)
				{
					Console.WriteLine("Недопустимое число, число не может быть меньше нуля!");
				}
				
			} while (!int.TryParse(aAsString, out a) || a<0);
			
			do
			{
				Console.Write("Введите целое число не больше 10^9: ");
				mAsString = Console.ReadLine();

				if (!int.TryParse(mAsString, out m))
				{
					Console.WriteLine("Ошибка ввода, попробуйте снова!");
				}else if (m > Math.Pow(10,9))
				{
					Console.WriteLine("Недопустимое число, число не может быть больше 10^9!");
				}
				
			} while (!int.TryParse(mAsString, out m) || m > Math.Pow(10,9));
			
			
			
			stopwatch.Start();
			
			int g = Gcd(a, m,out x,out y);

			if (g != 1)
			{
				Console.WriteLine(0);
			}
			else
			{
				x = (x % m + m) % m;
				Console.WriteLine(x);
			}
			
			stopwatch.Stop();
			Console.WriteLine("Время выполнения алгоритма: "+ stopwatch.Elapsed.TotalSeconds + "сек");

		}

		static int Gcd(int a, int m, out int x, out int y)
		{
			if (a == 0)
			{
				x = 0;
				y = 1;
				return m;
			}

			int x1, y1;

			int d = Gcd(m % a, a, out x1, out y1);
			
			x = y1 - (m / a) * x1;
			
			y = x1;
			
			return d;
		}
	}
}
