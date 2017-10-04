using System;




namespace Exatel.Services.Rekrutacja
{
    public interface IGminaService
    {
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

        Models.Terytorium.MiastoModelCollection MiastaSearch(System.String woj, System.String pow, System.String gmi, System.String rod);
    }
}
