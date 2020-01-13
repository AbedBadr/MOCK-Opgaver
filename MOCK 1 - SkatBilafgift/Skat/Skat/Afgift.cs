using System;

namespace Skat
{
    public class Afgift
    {
        /// <summary>
        /// Udregner registreringsafgiften på en personbil
        /// udfra prisen
        /// </summary>
        /// <param name="pris">prisen på bilen</param>
        /// <returns>registreringsafgiften på bilen</returns>
        public static int BilAfgift(int pris)
        {
            double bilAfgift = 0;

            if (pris < 0) throw new ArgumentException("Price can't be under 0");
            if (pris <= 200000) bilAfgift = pris * 0.85;
            else bilAfgift = (pris * 1.50) - 130000;

            return (int)bilAfgift;
        }

        /// <summary>
        /// Udregner registreringsafgiften på en elbil
        /// udfra prisen
        /// </summary>
        /// <param name="pris">prisen på elbilen</param>
        /// <returns>registreringsafgiften på elbilen</returns>
        public static int ElBilAfgift(int pris)
        {
            double elbilAfgift = BilAfgift(pris) * 0.20;
            return (int) elbilAfgift;
        }
    }
}
