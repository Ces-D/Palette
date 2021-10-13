using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.Entities
{
    public class Hex
    {
        private Hex() { }

        public static Hex From(string hexString)
        {
            var hex = new Hex();

            try
            {
                var hexFormatPattern = new Regex(@"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})");
                if (hexFormatPattern.IsMatch(hexString))
                {
                    if (hexString.Length == 7)
                    {
                        hex.Red = hexString.Substring(1, 2);
                        hex.Green = hexString.Substring(3, 2);
                        hex.Blue = hexString.Substring(5, 2);
                    }
                    else
                    {
                        hex.Red = hexString.Substring(1, 1);
                        hex.Green = hexString.Substring(2, 1);
                        hex.Blue = hexString.Substring(3, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HexInvalidException(hexString, ex);
            }

            return hex;
        }

        public string Red { get; private set; }
        public string Green { get; private set; }
        public string Blue { get; private set; }

        public static implicit operator string(Hex hex) => hex.ToString();
        public override string ToString() => $"#{Red}{Green}{Blue}";
    }
}
