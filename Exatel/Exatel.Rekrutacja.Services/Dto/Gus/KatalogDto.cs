using System;
using System.Linq;




namespace Exatel.Dto.Gus
{
    [
        System.Runtime.Serialization.DataContract
        (
            Name = "PlikKatalog", Namespace = "http://schemas.datacontract.org/2004/07/TerytUslugaWs1"
        )
    ]
    [
        System.Serializable
    ]
    public partial class KatalogDto
    {
        #region Fields


        private System.String base64;


        #endregion




        [
            System.Runtime.Serialization.IgnoreDataMember
        ]
        public System.Byte[] Zawartosc
        {
            get;
            private set;
        }


        [
            System.Runtime.Serialization.DataMember(Name = "nazwa_pliku")
        ]
        public string Nazwa
        {
            get;
            set;
        }


        [
            System.Runtime.Serialization.DataMember(Name = "opis")
        ]
        public string Opis
        {
            get;
            set;
        }


        [
            System.Runtime.Serialization.DataMember(Name = "plik_zawartosc")
        ]
        public string ZawartoscBase64
        {
            get
            {
                return base64;
            }
            set
            {
                base64 = value;


                if
                (
                    string.IsNullOrEmpty(base64) == false
                )
                {
                    try
                    {
                        Zawartosc = System.Convert.FromBase64String(base64);
                    }
                    catch { }
                }
            }
        }
    }
}
