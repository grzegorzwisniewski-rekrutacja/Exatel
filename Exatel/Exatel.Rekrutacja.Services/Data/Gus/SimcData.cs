﻿using System;
using System.Linq;




namespace Exatel.Data.Gus
{
    public class SimcData
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
            System.Xml.Serialization.XmlElement("NAZWA")
        ]
        public System.String NAZWA
        {
            get;
            set;
        }






        public class SimcComparer : System.Collections.Generic.IComparer<SimcData>
        {
            public int Compare
            (
                SimcData x,
                SimcData y
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
