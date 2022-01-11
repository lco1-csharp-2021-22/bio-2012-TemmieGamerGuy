using System;
using System.Collections.Generic;

namespace ValueTuplesExample
{
	class Program
	{
		public static string Trains(string flips, string pos, int limit, bool print = false, char stoppoint = '/') {
			Dictionary<char, List<char>> points = new Dictionary<char, List<char>>() { {'A',new List<char>(){'D','E','F','1'}},{'B',new List<char>(){'C','G','H','1'}},{'C',new List<char>(){'B','I','J','1'}},{'D',new List<char>(){'A','K','L','1'}},{'E',new List<char>(){'A','M','N','1'}},{'F',new List<char>(){'A','N','O','1'}},
				{'G',new List<char>(){'B','O','P','1'}},{'H',new List<char>(){'B','P','Q','1'}},{'I',new List<char>(){'C','Q','R','1'}},{'J',new List<char>(){'C','R','S','1'}},{'K',new List<char>(){'D','S','T','1'}},
				{'L',new List<char>(){'D','T','M','1'}},{'M',new List<char>(){'U','L','E','1'}},{'N',new List<char>(){'U','E','F','1'}},{'O',new List<char>(){'V','F','G','1'}},{'P',new List<char>(){'V','G','H','1'}},
				{'Q',new List<char>(){'W','H','I','1'}},{'R',new List<char>(){'W','I','J','1'}},{'S',new List<char>(){'X','J','K','1'}},{'T',new List<char>(){'X','K','L','1'}},{'U',new List<char>(){'V','M','N','1'}},
				{'V',new List<char>(){'U','O','P','1'}},{'W',new List<char>(){'X','Q','R','1'}},{'X',new List<char>(){'W','S','T','1'}},};
			char here = pos[0];
			char next = pos[1];
			foreach (char c in flips) { points[c][3] = '4'; }

			for (int i = 0; i < limit; i++)
			{
				if (print) Console.WriteLine(here);
				int entry = points[next].IndexOf(here);
				here = next;
				if (stoppoint != '/' && here == stoppoint) break;
				int state = points[here][3] - 48;
				if (state > 3)
				{
					if (entry == 0) { next = points[here][state - 3]; if (points[here][3] == '4') { points[here][3] = '5'; } else { points[here][3] = '4'; } }
					else next = points[here][0];
				}
				else
				{
					if (entry == 0) next = points[here][state];
					else { next = points[here][0]; points[here][3] = (char)(entry + 48); }
				}
			}
			return string.Concat(here, next);

		}
        static void Main(string[] args)
        {
			string flips = Console.ReadLine();
			string pos = Console.ReadLine();
			int limit = int.Parse(Console.ReadLine());
			string result = Trains(flips, pos, limit);
			Console.WriteLine(result);

			// Q2

		}

	}
}

