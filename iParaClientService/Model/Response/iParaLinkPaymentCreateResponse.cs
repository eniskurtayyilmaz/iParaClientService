using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Domain;
using iParaClientService.Model.Request;
using iParaClientService.Utils;

namespace iParaClientService.Model.Response
{

    public class iParaLinkPaymentCreateResponse : AbstractiParaResponseBase, IAmount
    {
        public string Link { get; set; }

        public string LinkPaymentId { get; set; }

        public int? Amount { get; set; }

        public void SetAmount(double money)
        {
            this.Amount = money.SetAmount();
        }

        public double GetAmount()
        {
            return this.Amount.GetAmount();
        }
    }
}
