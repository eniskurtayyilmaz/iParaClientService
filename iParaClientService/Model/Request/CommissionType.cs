using System.ComponentModel;

namespace iParaClientService.Model.Request
{
    public enum CommissionType
    {
        [Description("Satıcı")]
        /// <summary>
        /// Satıcı
        /// </summary>
        Seller = 1,
        [Description("Alıcı")]
        /// <summary>
        /// Müşteri
        /// </summary>
        Dealer = 2
    }
}