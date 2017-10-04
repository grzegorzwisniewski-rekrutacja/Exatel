using System;
using System.Linq;




namespace Exatel.Services.Rekrutacja.Data
{
    public class GminaDataService : IGminaDataService
    {
        #region Fields


        private System.String userName,
                              password;


        #endregion




        public System.String UserName
        {
            get
            {
                return userName ?? (userName = System.Configuration.ConfigurationManager.AppSettings["GUS::USERNAME"]);
            }
            set
            {
                userName = value;
            }
        }


        public System.String Password
        {
            get
            {
                return password ?? (password = System.Configuration.ConfigurationManager.AppSettings["GUS::PASSWORD"]);
            }
            set
            {
                password = value;
            }
        }




        public Models.Terytorium.MiastoModelCollection MiastaGet()
        {
            var miasta = System.Runtime.Caching.MemoryCache.Default["Miasta"] as Models.Terytorium.MiastoModelCollection;


            if (miasta != null)
            {
                return new Models.Terytorium.MiastoModelCollection(miasta);
            }




            miasta = new Models.Terytorium.MiastoModelCollection
            {
            };


            using
            (
                var proxy = new Communications.Gus.TerytProxy()
            )
            {
                proxy.ClientCredentials.UserName.UserName = UserName;
                proxy.ClientCredentials.UserName.Password = Password;




                var isNotAuth = proxy.NoAuthTest();


                if (isNotAuth)
                {
                    throw new System.InvalidOperationException(Localizations.Dictionary.ErrorResource.RemoteNoAuth);
                }


                else
                {
                    var ulice = proxy.UlicGet(System.DateTime.Today);
                    var simcs = proxy.SimcGet(System.DateTime.Today);




                    ulice.Sort
                    (
                        new Exatel.Data.Gus.UlicData.UlicComparer()
                    );


                    simcs.Sort
                    (
                        new Exatel.Data.Gus.SimcData.SimcComparer()
                    );




                    {
                        foreach
                        (
                            var simc in simcs
                        )
                        {
                            miasta.Add
                            (
                                new Models.Terytorium.MiastoModel { Woj = simc.WOJ, Pow = simc.POW, Gmi = simc.GMI, Rod = simc.ROD, Nazwa = simc.NAZWA }
                            );
                        }
                    }




                    {
                        var i = 0;


                        foreach
                        (
                            var ulic in ulice
                        )
                        {
                            Models.Terytorium.MiastoModel miasto = null;


                            for
                            (
                                ; i < miasta.Count; i++
                            )
                            {
                                if
                                (
                                        miasta[i].Woj == ulic.WOJ
                                    &&  miasta[i].Pow == ulic.POW
                                    &&  miasta[i].Gmi == ulic.GMI
                                    &&  miasta[i].Rod == ulic.ROD
                                )
                                {
                                    miasto = miasta[i];


                                    break;
                                }
                                else
                                {
                                    miasto = null;
                                }
                            }


                            if
                            (
                                (miasto != null)
                            )
                            {
                                miasto.Ulice.Add
                                (
                                    new Models.Terytorium.UlicaModel { Cecha = ulic.CECHA, Nazwa = ulic.NAZWA1 }
                                );
                            }
                        }
                    }




                    System.Runtime.Caching.MemoryCache.Default.Set
                    (
                        "Miasta", miasta, new System.Runtime.Caching.CacheItemPolicy()
                    );
                }
            }


            return miasta;
        }




        public Models.Terytorium.MiastoModelCollection MiastaGet(System.String woj, System.String pow, System.String gmi, System.String rod)
        {
            if
            (
                string.IsNullOrEmpty(rod) == false && string.IsNullOrEmpty(gmi)
            )
            {
                throw new System.ArgumentException("Rodzaj może być ustawiony tylko z gminą", nameof(rod));
            }


            if
            (
                string.IsNullOrEmpty(gmi) == false && string.IsNullOrEmpty(pow)
            )
            {
                throw new System.ArgumentException("Gmina może być ustawiona tylko z powiatem", nameof(gmi));
            }


            if
            (
                string.IsNullOrEmpty(pow) == false && string.IsNullOrEmpty(woj)
            )
            {
                throw new System.ArgumentException("Powiat może być ustawiony tylko z województwem", nameof(pow));
            }




            var miasta = MiastaGet().Where
            (
                x =>
                (
                        ((string.IsNullOrEmpty(woj) == false && string.Equals(x.Woj, woj)) || string.IsNullOrEmpty(woj))
                    &&  ((string.IsNullOrEmpty(pow) == false && string.Equals(x.Pow, pow)) || string.IsNullOrEmpty(pow))
                    &&  ((string.IsNullOrEmpty(gmi) == false && string.Equals(x.Gmi, gmi)) || string.IsNullOrEmpty(gmi))
                    &&  ((string.IsNullOrEmpty(rod) == false && string.Equals(x.Rod, rod)) || string.IsNullOrEmpty(rod))
                )
            );


            return new Models.Terytorium.MiastoModelCollection(miasta);
        }
    }
}
