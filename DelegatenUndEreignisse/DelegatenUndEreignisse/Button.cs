using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        public EventHandler ButtonClick { get; set; }
        public void Klick()
        {
            if(ButtonClick != null)
                ButtonClick(this, EventArgs.Empty);
        }
    }
}
