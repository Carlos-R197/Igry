using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Igry.Models
{
    public class Email : BaseModel
    {
        public string Value { get; set; }
           
        public bool IsValid()
        {
            return !HasWhiteSpace() && Value.Contains('@');              
        }

        private bool HasWhiteSpace()
        {
            foreach (char c in Value)
            {
                if (c == ' ')
                    return true;
            }

            return false;
        }
    }

}
