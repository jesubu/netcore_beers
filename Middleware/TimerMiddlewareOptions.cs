using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Middleware
{
    public class TimerMiddlewareOptions
    {
        public string Text { get; set; }

        public TimerMiddlewareOptions()
        {
            Text = "took";
        }

        public void SetDefaultMessage(string value)
        {
            Text = value;
        }
    }
}
