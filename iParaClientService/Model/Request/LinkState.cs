namespace iParaClientService.Model.Request
{

    public enum LinkState
    {
        /// <summary>
        /// Link isteği alındı
        /// </summary>
        LinkRequest = 0,
        /// <summary>
        /// Link URL’i yaratıldı
        /// </summary>
        LinkCreated = 1,
        /// <summary>
        /// Link Gönderildi, Ödeme Bekleniyor
        /// </summary>
        LinkSended = 2,
        /// <summary>
        /// Link ile Ödeme Başarılı
        /// </summary>
        LinkPaymentDone = 3,
        /// <summary>
        /// Link Zaman Aşımına Uğradı
        /// </summary>
        LinkPaymentTimeout = 98,
        /// <summary>
        /// Link Silindi
        /// </summary>
        LinkDeleted = 99
    }
}
