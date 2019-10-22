using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        // Variante "Lang"
        //private EventHandler buttonClick;
        //public event EventHandler ClickEvent
        //{
        //    add
        //    {
        //        buttonClick += value;
        //    }
        //    remove
        //    {
        //        buttonClick -= value;
        //    }
        //}

        // "AutoProperty"-Variante
        public event EventHandler ClickEvent; // event-Schlüsselwort

        public void Klick()
        {
            if(ClickEvent != null)
                ClickEvent(this, EventArgs.Empty);
        }
    }
}
