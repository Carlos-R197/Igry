using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Igry.Models
{
    public class Password : BaseModel
    {
        private const int minimumAmountCharacters = 7;

        private readonly Regex specialCharactersExpression = new Regex(@'!\"#$%&\'() * +, -./:;<=>?@[\\]^_`{|}~');
        public string Value { get; set; }


        /// <summary>
        /// Returns true if the email contains at least 7 elements. 
        /// One of which has to be a special character and another a number.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Value.Length >= 7 && ContainsSpecialCharacter() &&
                Value.Any(t => char.IsNumber(t));
        }


        private bool ContainsSpecialCharacter()
        {
            MatchCollection matches = validEmailExpression.Matches(Value);

            return matches.Count > 0;
        }
    }
}
