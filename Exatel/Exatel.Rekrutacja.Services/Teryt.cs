using System;
using System.Linq;




namespace Exatel
{
    public struct Teryt
    {
        public static System.Boolean TryParse(System.String text, out Teryt teryt)
        {
            teryt = new Teryt();


            if (string.IsNullOrEmpty(text))
            {
                return false;
            }


            else
            {
                if
                (
                    System.Text.RegularExpressions.Regex.IsMatch
                    (
                        text, @"/^(\d{7}|\d{6}|\d{4}|\d{2})$/"
                    )
                )
                {
                    return false;
                }


                else
                {
                    if (text.Length >= 7) teryt.rod = text.Substring(6, 1);
                    if (text.Length >= 6) teryt.gmi = text.Substring(4, 2);
                    if (text.Length >= 4) teryt.pow = text.Substring(2, 2);
                    if (text.Length >= 2) teryt.woj = text.Substring(0, 2);


                    return true;
                }
            }
        }




        #region Fields


        private System.String woj,
                              pow,
                              gmi,
                              rod;


        #endregion




        public Teryt(System.String text)
        {
            if (TryParse(text, out var teryt))
            {
                this = teryt;
            }
            else
            {
                throw new System.ArgumentException
                (
                    "Błędny format TERYT", nameof(text)
                );
            }
        }




        public System.String Woj
        {
            get => this.woj;
        }


        public System.String Pow
        {
            get => this.pow;
        }


        public System.String Gmi
        {
            get => this.gmi;
        }


        public System.String Rod
        {
            get => this.rod;
        }
    }
}
