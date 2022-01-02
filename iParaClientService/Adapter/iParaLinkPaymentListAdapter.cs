using iParaClientService.Constant;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Adapter
{
    public class iParaLinkPaymentListAdapter : AbstractIParaExecuter<iParaLinkPaymentListRequest, iParaLinkPaymentListResponse>
    {
        private readonly iParaClientConnection iParaClientConnection;

        public iParaLinkPaymentListAdapter(iParaClientConnection iParaClientConnection) : base(iParaClientConnection)
        {
            this.iParaClientConnection = iParaClientConnection;
        }

        public override string GetRequestUrl => iParaClientConnection.BaseUrl + RequestUrlConstant.LinkPaymentList;

        public override string AcceptType => HeaderConstant.ApplicationJson;

        public override string GetHashString(iParaLinkPaymentListRequest model)
        {
            return HashStringBuilderHelpers.GetHashString(iParaClientConnection.PrivateKey, model.ClientIp, HeaderHelpers.GetTransactionDateString());
        }

        public override iParaLinkPaymentListResponse Execute(iParaLinkPaymentListRequest model)
        {
            model.Mode = iParaClientConnection.GetMode();
            var hashString = this.GetHashString(model);

            var header = this.WebHeaderCollection(hashString);

            using (var httpCaller = new RestHttpCallerHelpers())
            {
                var result = httpCaller.PostJson<iParaLinkPaymentListResponse>(GetRequestUrl, header, model);
                return result;
            }
        }
    }
}