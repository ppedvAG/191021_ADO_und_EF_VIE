using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.ProjectAli.Domain
{
    public class MyConcurrencyException : Exception
    {
        public MyConcurrencyException(string Message) : base(Message){}
        public Action DBWins { get; set; }
        public Action UserWins { get; set; }
    }
}
