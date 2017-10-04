using System;




namespace Exatel.Services.Rekrutacja.Data
{
    public interface IGminaDataService
    {
        /// <summary>
        /// </summary>
        ///
        /// <returns>
        /// </returns>

        Models.Terytorium.MiastoModelCollection MiastaGet();




        /// <summary>
        /// </summary>
        ///
        /// <param name="woj">
        /// </param>
        ///
        /// <param name="pow">
        /// </param>
        ///
        /// <param name="gmi">
        /// </param>
        ///
        /// <param name="rod">
        /// </param>
        ///
        /// <returns>
        /// </returns>

        Models.Terytorium.MiastoModelCollection MiastaGet(System.String woj, System.String pow, System.String gmi, System.String rod);
    }
}
