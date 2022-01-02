using iParaClientService.Model.Request;
using iParaClientService.Utils;

namespace iParaClientService.Domain
{
    public class PaymentLink : IAmount
    {
        public int? Amount { set; get; }

        public string CreationDate { set; get; }

        public string Description { set; get; }

        public string Email { set; get; }

        public string Gsm { set; get; }

        public string LinkId { set; get; }

        public string LinkState { set; get; }

        public string Name { set; get; }

        public string Surname { set; get; }

        public string TaxNumber { set; get; }

        public string TcCertificate { set; get; }

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
