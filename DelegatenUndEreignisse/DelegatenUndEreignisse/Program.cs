﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Program
    {
        // Delegate-Type
        // Signatur: void ___ (Parameterliste)
        public delegate void MeinDelegat();
        public delegate void MeinDelegatFürC(int zahl);
        public delegate int Rechner(int z1, int z2);
        static void Main(string[] args)
        {
            #region .NET 1.0
            //MeinDelegat del = new MeinDelegat(A);
            //del += B;
            //del.Invoke();

            //MeinDelegatFürC del2 = new MeinDelegatFürC(C);
            //del2 += D;
            //del2.Invoke(99);

            //Rechner meinRechner = Add;          // Kurzschreibweise für: new Rechner(Add);
            //meinRechner += Sub;
            //meinRechner += Add;
            //int erg1 = meinRechner(123, 456);   // Kurzschreibweise für meinrechner.Invoke(123,456);
            //Console.WriteLine(erg1); 
            #endregion

            #region Action<T>, Func<T> und EventHandler
            //// Action -> Alle Delegaten, die void sind
            //Action a1 = A;
            //Action<int> a2 = C;

            //a1();
            //a2(12);

            //// Func<T> -> Alles mit Rückgabe
            //Func<int, int, int> rechner = Add;
            //Console.WriteLine(rechner(12,99));

            //// EventHandler: Für Oberflächen

            //EventHandler handler = ButtonSpeichern_Click; 
            #endregion

            // Anwendungsfall:

            Button b1 = new Button();

            b1.ButtonClick += ButtonSpeichern_Click;
            b1.ButtonClick += Logger;

            b1.Klick();
            b1.Klick();
            b1.Klick();
            b1.ButtonClick -= Logger;
            b1.Klick();
            b1.Klick();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: Button wurde geklickt");
        }

        private static void ButtonSpeichern_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        private static void A()
        {
            Console.WriteLine("A");
        }
        private static void B()
        {
            Console.WriteLine("B");
        }
        private static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }
        private static void D(int zahl)
        {
            Console.WriteLine($"D{zahl}");
        }

        private static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
        private static int Sub(int z1, int z2)
        {
            return z1 - z2;
        }

    }
}
