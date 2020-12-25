using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace Function
{
    public class FunctionHandler
    {
        public async Task<(int, string)> Handle(HttpRequest request)
        {
            var reader = new StreamReader(request.Body);
            var input = await reader.ReadToEndAsync();
            var isValidSiteswap = Siteswap.TryCreate(input, out var siteswap);
            return (200, $"Hello! Your input {input}. Dies ist {(isValidSiteswap? "ein":"kein")} valider Siteswap");
        }
    }

    public class Siteswap
    {
        public int[] Array { get; }
        public Siteswap(int[] array) 
        {
            this.Array = array;
        }
        public static bool TryCreate(string input, out Siteswap siteswap) 
        {
			if (TryCreate(input,out int[] array))
			{
                siteswap = new Siteswap(array);
                return array.Select((i,x)=> x+i).Distinct().Count() == array.Count();
			}
            siteswap = null;
            return false;
        }

        private static bool TryCreate(string input, out int[] array) 
        {
            try
            {

                array = input.Select(x => CharToSiteswapValue(x)).ToArray();
                return true;
            }
            catch (Exception e) 
            {
                array = new int[]{};
                return false;
            }
        }

        private static int CharToSiteswapValue(char c) 
        {
            var isInt = int.TryParse(c.ToString(), out var i);
			if (isInt)
			{
                return i;
			}
            return Convert.ToInt32(Encoding.ASCII.GetBytes(c.ToString()).Single());
        }

		public Siteswap()
		{

		}
    }
}