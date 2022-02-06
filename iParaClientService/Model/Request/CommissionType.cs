using System.ComponentModel;

namespace iParaClientService.Model.Request
{
    public enum CommissionType
    {
        /// <summary>
        /// Satıcı
        /// </summary>
        [Description("Satıcı")]
        Seller = 1,
        
        /// <summary>
        /// Müşteri - Alıcı
        /// </summary>
        [Description("Alıcı")]
        Dealer = 2
    }
}