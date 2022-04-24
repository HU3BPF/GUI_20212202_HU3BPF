using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Logic
{
    internal interface IMenuLogic
    {
        /// <summary>
        /// Ezzel a metódussal érjük el, hogy kiválaszt egy menüelemet a felhasználó.
        /// Ennek a hatására egy új modelnek kell majd betöltődni a BaseControl osztályba 
        /// </summary>
        /// <param name="selectedIndex"></param>
        public void SelectIndex(int selectedIndex);

        /// <summary>
        /// Ez növeli a kiválaszott menüelem indexét, a tartományokon belül maradva.
        /// Arra figyelv, hogy ha a Continue gombra lépnénk, akkor kihagyja ha nem lehet betölteni játékot.
        /// </summary>
        public void IncSelectedIndex();

        /// <summary>
        /// Ez csökkenti a kiválaszott menüelem indexét, a tartományokon belül maradva.
        /// Arra figyelv, hogy ha a Continue gombra lépnénk, akkor kihagyja ha nem lehet betölteni játékot.
        /// </summary>
        public void DescSelectedIndex();
    }
}
