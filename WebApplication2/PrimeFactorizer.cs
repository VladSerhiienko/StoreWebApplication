using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace StoreWebApplication
{
  public class PrimeFactorizer
  {
    public static bool IsPrime(int i)
    {
      int s = (int)Math.Sqrt((double)i);
      for (int j = 2; j <= s; j++)
        if ((i % j) == 0)
          return false;
      return true;
    }

    public static IEnumerable<int> Factorize(int n)
    {
      int d = 2;
      while (n > 1)
      {
        while ((n % d) == 0)
        {
          yield return d; n /= d;
        }

        d += 1;
        if (d * d > n) if (n > 1)
          {
            yield return n; break;
          }
      }
    }

    public static string CompileToHtmlRandom()
    {
      int n = (new Random()).Next(100, 10000000);
      return CompileToHtml(n, Factorize(n));
    }

    public static string CompileToHtml(int n, IEnumerable<int> factors)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append("<h2>");
      builder.Append("<strong>" + n + "</strong>" + " factors: ");
      foreach (var i in factors)
        builder.Append(i + ", ");
      builder.Remove(builder.Length - 2, 2);
      builder.Append("</h2>");
      return builder.ToString();
    }



  }
}