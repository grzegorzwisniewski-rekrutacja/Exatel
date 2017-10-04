using System;
using System.Linq;




namespace Exatel.Communications.Gus
{
    public sealed class TerytProxy : Proxy<TerytProxyContract>
    {
        /// <summary>
        /// </summary>
        ///
        /// <returns>
        /// </returns>

        public System.Boolean NoAuthTest()
        {
            return Channel.CzyZalogowany() == false;
        }




        /// <summary>
        /// </summary>
        ///
        /// <param name="date">
        /// </param>
        ///
        /// <returns>
        /// </returns>

        public Data.Gus.SimcDataCollection SimcGet
        (
            System.DateTime date
        )
        {
            var state = Channel.PobierzKatalogSIMCAdr(date);


            if (state == null)
            {
                return null;
            }




            var results = new Data.Gus.SimcDataCollection
            {
            };


            using
            (
                var content = new System.IO.MemoryStream(state.Zawartosc)
            )
            {
                using
                (
                    var zip = new System.IO.Compression.ZipArchive(content, System.IO.Compression.ZipArchiveMode.Read)
                )
                {
                    var entry = zip.Entries.FirstOrDefault
                    (
                        x => x.Name.EndsWith(".xml")
                    );


                    if (entry != null)
                    {
                        using
                        (
                            var simcs = entry.Open()
                        )
                        {
                            results.AddRange
                            (
                                (new System.Xml.Serialization.XmlSerializer(typeof(SimcsData)).Deserialize(simcs) as SimcsData).Simcs
                            );
                        }
                    }
                }
            }


            return results;
        }




        /// <summary>
        /// </summary>
        ///
        /// <param name="date">
        /// </param>
        ///
        /// <returns>
        /// </returns>

        public Data.Gus.UlicDataCollection UlicGet
        (
            System.DateTime date
        )
        {
            var state = Channel.PobierzKatalogULICAdr(date);


            if (state == null)
            {
                return null;
            }




            var results = new Data.Gus.UlicDataCollection
            {
            };


            using
            (
                var content = new System.IO.MemoryStream(state.Zawartosc)
            )
            {
                using
                (
                    var zip = new System.IO.Compression.ZipArchive(content, System.IO.Compression.ZipArchiveMode.Read)
                )
                {
                    var entry = zip.Entries.FirstOrDefault
                    (
                        x => x.Name.EndsWith(".xml")
                    );


                    if (entry != null)
                    {
                        using
                        (
                            var simcs = entry.Open()
                        )
                        {
                            results.AddRange
                            (
                                (new System.Xml.Serialization.XmlSerializer(typeof(UliceData)).Deserialize(simcs) as UliceData).Ulice
                            );
                        }
                    }
                }
            }


            return results;
        }






        [
            System.Xml.Serialization.XmlRoot("SIMC")
        ]
        public class SimcsData
        {
            #region Fields


            private Data.Gus.SimcDataCollection simcs;


            #endregion




            [
                System.Xml.Serialization.XmlArray("catalog"), System.Xml.Serialization.XmlArrayItem("row")
            ]
            public Data.Gus.SimcDataCollection Simcs
            {
                get
                {
                    return simcs ?? (simcs = new Data.Gus.SimcDataCollection());
                }
            }
        }






        [
            System.Xml.Serialization.XmlRoot("ULIC")
        ]
        public class UliceData
        {
            #region Fields


            private Data.Gus.UlicDataCollection ulice;


            #endregion




            [
                System.Xml.Serialization.XmlArray("catalog"), System.Xml.Serialization.XmlArrayItem("row")
            ]
            public Data.Gus.UlicDataCollection Ulice
            {
                get
                {
                    return ulice ?? (ulice = new Data.Gus.UlicDataCollection());
                }
            }
        }
    }
}
