using System;
using System.Collections.Generic;
using System.Text;

namespace Serverless_Pattern.Models
{
    public class response
    {
        public bool result;
        public string message;

        public response(bool result, string message)
        {
            this.result = result;
            this.message = message;
        }
    }
}
