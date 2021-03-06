﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Igry.Models
{
    public class Password : BaseModel
    {
        private const int minimumAmountCharacters = 7;
        private const string specialCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        public string Value { get; set; }


        /// <summary>
        /// Returns true if the password contains at least 7 elements. 
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
            foreach (char c in Value)
            {
                foreach (char sc in specialCharacters)
                {
                    if (c == sc)
                        return true;
                }
            }
            return false;
        }
    }
}
