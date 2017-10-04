using System;
using System.Linq;




namespace Exatel.Services.Rekrutacja
{
    public class GminaService : IGminaService
    {
        #region Fields


        #region Services


        private Data.IGminaDataService dataOperator = null;


        #endregion


        #endregion




        public GminaService()
            :this
            (
                new Data.GminaDataService()
            )
        {
        }




        public GminaService(Data.IGminaDataService dataOperator)
        {
            this.dataOperator = dataOperator ?? throw new System.ArgumentNullException(nameof(dataOperator));
        }




        public Models.Terytorium.MiastoModelCollection MiastaSearch(System.String woj, System.String pow, System.String gmi, System.String rod)
        {
            return dataOperator.MiastaGet(woj, pow, gmi, rod);
        }
    }
}
