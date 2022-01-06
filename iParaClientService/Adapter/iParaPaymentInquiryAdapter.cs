using iParaClientService.Constant;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Adapter
{
    public class iParaPaymentInquiryAdapter : AbstractIParaExecuter<iParaPaymentInquiryRequest, iParaPaymentInquiryResponse>
    {
        private readonly iParaClientConnection iParaClientConnection;

        public iParaPaymentInquiryAdapter(iParaClientConnection iParaClientConnection) : base(iParaClientConnection)
        {
            this.iParaClientConnection = iParaClientConnection;
        }

        public override string GetRequestUrl => iParaClientConnection.BaseUrl + RequestUrlConstant.PaymentInquiry;

        public override string AcceptType => HeaderConstant.ApplicationXml;
        public override string GetHashString(iParaPaymentInquiryRequest model)
        {
            return HashStringBuilderHelpers.GetHashString(iParaClientConnection.PrivateKey, model.OrderId, HeaderHelpers.GetTransactionDateString());
        }

        public override iParaPaymentInquiryResponse Execute(iParaPaymentInquiryRequest model)
        {
            //model.Mode = iParaClientConnection.GetMode();
            var hashString = this.GetHashString(model);

            var header = this.WebHeaderCollection(hashString);

            using (var httpCaller = new RestHttpCallerHelpers())
            {
                var result = httpCaller.PostXML<iParaPaymentInquiryResponse>(GetRequestUrl, header, model);
                return result;
            }
        }
    }
}