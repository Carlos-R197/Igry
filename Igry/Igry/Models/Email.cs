using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Igry.Models
{
    public class Email : BaseModel
    {
        private readonly Regex validEmailExpression = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
        public string Value { get; set; }
           
        public bool IsValid()
        {
            MatchCollection matches = validEmailExpression.Matches(Value);
            
            return matches.Count > 0;              
        }
    }

}
