using System;
using System.Linq;




namespace Exatel.Models.Terytorium
{
    public class MiastoModel
    {
        #region Fields


        private UlicaModelCollection ulice = null;


        #endregion




        /// <summary>
        ///   Pobiera lub ustawia dwuznakowy symbol województwa
        /// </summary>

        public System.String Woj
        {
            get;
            set;
        }


        /// <summary>
        ///   Pobiera lub ustawia dwuznakowy symbol powiatu
        /// </summary>

        public System.String Pow
        {
            get;
            set;
        }


        /// <summary>
        ///   Pobiera lub ustawia dwuznakowy symbol gminy
        /// </summary>

        public System.String Gmi
        {
            get;
            set;
        }


        /// <summary>
        ///   Pobiera lub ustawia jednoznakowy symbol rodzaju gminy
        /// </summary>

        public System.String Rod
        {
            get;
            set;
        }


        /// <summary>
        ///   Pobiera nazwę
        /// </summary>

        public System.String Nazwa
        {
            get;
            set;
        }


        /// <summary>
        ///   Pobiera kolekcję ulic w gminie
        /// </summary>

        public UlicaModelCollection Ulice
        {
            get
            {
                return ulice ?? (ulice = new UlicaModelCollection());
            }
        }
    }
}
