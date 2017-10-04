using System;




namespace Exatel.Communications.Gus
{
    [
        System.ServiceModel.ServiceContract
    ]
    public interface TerytProxyContract
    {
        /// <summary>
        ///   Pobiera stan użytkownika
        /// </summary>
        ///
        /// <returns>
        ///   true: jeśli użytkownik zalogowany
        /// </returns>

        [
            System.ServiceModel.OperationContractAttribute
            (
                Action = "http://tempuri.org/ITerytWs1/CzyZalogowany", ReplyAction = "http://tempuri.org/ITerytWs1/CzyZalogowanyResponse"
            )
        ]
        System.Boolean CzyZalogowany();


        /// <summary>
        ///   Pobiera dane o miejscowościach z systemu identyfikatorów SIMC z wybranego stanu katalogu w wersji adresowej.
        /// </summary>
        ///
        /// <param name="DataStanu">
        ///   Data w formacie 'YYYY-MM-DD'
        /// </param>

        [
            System.ServiceModel.OperationContractAttribute
            (
                Action = "http://tempuri.org/ITerytWs1/PobierzKatalogSIMCAdr", ReplyAction = "http://tempuri.org/ITerytWs1/PobierzKatalogSIMCAdrResponse"
            )
        ]
        Dto.Gus.KatalogDto PobierzKatalogSIMCAdr(System.DateTime DataStanu);


        /// <summary>
        ///   Pobiera katalog ulic dla wskazanego stanu w wersji adresowej.
        /// </summary>
        ///
        /// <param name="DataStanu">
        ///   Data w formacie 'YYYY-MM-DD'
        /// </param>

        [
            System.ServiceModel.OperationContractAttribute
            (
                Action = "http://tempuri.org/ITerytWs1/PobierzKatalogULICAdr", ReplyAction = "http://tempuri.org/ITerytWs1/PobierzKatalogULICAdrResponse"
            )
        ]
        Dto.Gus.KatalogDto PobierzKatalogULICAdr(System.DateTime DataStanu);
    }
}
