using System;
using System.Linq;




namespace Exatel.Data.Gus
{
    public class UlicData
    {
        [
            System.Xml.Serialization.XmlElement("WOJ")
        ]
        public System.String WOJ
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("POW")
        ]
        public System.String POW
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("GMI")
        ]
        public System.String GMI
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("RODZ_GMI")
        ]
        public System.String ROD
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("CECHA")
        ]
        public System.String CECHA
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("NAZWA_1")
        ]
        public System.String NAZWA1
        {
            get;
            set;
        }


        [
            System.Xml.Serialization.XmlElement("NAZWA_2")
        ]
        public System.String NAZWA2
        {
            get;
            set;
        }






        public class UlicComparer : System.Collections.Generic.IComparer<UlicData>
        {
            public int Compare
            (
                UlicData x,
                UlicData y
            )
            {
                if (x == null)
                {
                    throw new System.ArgumentNullException(nameof(x));
                }


                if (y == null)
                {
                    throw new System.ArgumentNullException(nameof(y));
                }


                var compareWoj = x.WOJ.CompareTo(y.WOJ);
                var comparePow = x.POW.CompareTo(y.POW);
                var compareGmi = x.GMI.CompareTo(y.GMI);
                var compareRod = x.ROD.CompareTo(y.ROD);


                if (compareWoj != 0) return compareWoj; else
                if (comparePow != 0) return comparePow; else
                if (compareGmi != 0) return compareGmi; else
                if (compareRod != 0) return compareRod; else return (0);
            }
        }
    }
}
