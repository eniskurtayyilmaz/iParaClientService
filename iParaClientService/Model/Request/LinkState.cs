using System.ComponentModel;

namespace iParaClientService.Model.Request
{

    public enum LinkState
    {
        [Description("Link İsteği Yapıldı")]
        /// <summary>
        /// Link isteği alındı
        /// </summary>
        LinkRequest = 0,
        [Description("Link Oluşturuldu")]
        /// <summary>
        /// Link URL’i yaratıldı
        /// </summary>
        LinkCreated = 1,
        [Description("Link Gönderildi")]
        /// <summary>
        /// Link Gönderildi, Ödeme Bekleniyor
        /// </summary>
        LinkSended = 2,
        [Description("Ödeme Başarılı")]
        /// <summary>
        /// Link ile Ödeme Başarılı
        /// </summary>
        LinkPaymentDone = 3,
        [Description("Zaman Aşımına Uğradı")]
        /// <summary>
        /// Link Zaman Aşımına Uğradı
        /// </summary>
        LinkPaymentTimeout = 98,
        [Description("Link Silindi")]
        /// <summary>
        /// Link Silindi
        /// </summary>
        LinkDeleted = 99
    }
}
