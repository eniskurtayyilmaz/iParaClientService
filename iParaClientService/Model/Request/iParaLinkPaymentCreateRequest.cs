using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;
using Newtonsoft.Json;

namespace iParaClientService.Model.Request
{
    public class iParaLinkPaymentCreateRequest : AbstractiParaRequestBase, IAmount
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string TcCertificate { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string Gsm { get; set; }

        public string Description { get; set; }

        public bool ThreeD { get; set; }

        public string ExpireDate { get; set; }

        public bool SendEmail { get; set; }

        public CommissionType CommissionType { get; set; }

        public string ClientIp { get; set; }

        public int Amount { get; protected set; }

        public CommissionType? InstallmentTwoCommissionType { get; set; }
        public CommissionType? InstallmentThreeCommissionType { get; set; }
        public CommissionType? InstallmentFourCommissionType { get; set; }
        public CommissionType? InstallmentFiveCommissionType { get; set; }
        public CommissionType? InstallmentSixCommissionType { get; set; }
        public CommissionType? InstallmentSevenCommissionType { get; set; }
        public CommissionType? InstallmentEightCommissionType { get; set; }
        public CommissionType? InstallmentNineCommissionType { get; set; }
        public CommissionType? InstallmentTenCommissionType { get; set; }
        public CommissionType? InstallmentElevenCommissionType { get; set; }
        public CommissionType? InstallmentTwelveCommissionType { get; set; }

        public List<int> InstallmentList { get; set; }
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
