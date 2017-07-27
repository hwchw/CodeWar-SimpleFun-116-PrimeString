using System;
using System.Collections.Generic;
using System.Linq;

namespace myjinxin
{
	public class Kata
	{
		public bool PrimeString(string s)
		{
			var isPrime = true;
			var targetLength = s.Length;
			var devidorList = new List<int>();

			//get devidor
			for (var i = 1; i < targetLength; i++)
			{
				if (targetLength % i == 0)
				{
					devidorList.Add(i);
				}
			}

			//check symbol
			foreach (var devidor in devidorList)
			{
				var arr = GetChunckedArray(s, devidor);
				var chunkedArr = arr as string[] ?? arr.ToArray();
				if (!CheckPrime(chunkedArr))
				{
					isPrime = CheckPrime(chunkedArr);
				}
			}

			return isPrime;
		}

		public static IEnumerable<string> GetChunckedArray(string str, int lengthOfChunk)
		{
			for (var index = 0; index < str.Length; index += lengthOfChunk)
			{
				yield return str.Substring(index, Math.Min(lengthOfChunk, str.Length - index));
			}
		}

		public bool CheckPrime(IEnumerable<string> chunkedArr)
		{
			var enumerable = chunkedArr as string[] ?? chunkedArr.ToArray();
			var symbol = enumerable.ToArray()[0];
			return enumerable.ToArray().Any(chunk => chunk != symbol);
		}
	}
}