using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Adapter
{
    public class iParaLinkPaymentCreateAdapter
        : AbstractIParaExecuter<iParaLinkPaymentCreateRequest, iParaLinkPaymentCreateResponse>
    {
        private readonly iParaClientConnection _iParaClientConnection;

        public iParaLinkPaymentCreateAdapter(iParaClientConnection iParaClientConnection) : base(iParaClientConnection)
        {
            _iParaClientConnection = iParaClientConnection;
        }
        public override string GetRequestUrl => _iParaClientConnection.BaseUrl + RequestUrlConstant.LinkPaymentCreate;
        public override string GetHashString(iParaLinkPaymentCreateRequest model)
        {
            return HashStringBuilderHelpers.GetHashString(_iParaClientConnection.PrivateKey, model.Name,
                                                          model.Surname, model.Email, model.Amount.ToString(),
                                                          model.ClientIp, HeaderHelpers.GetTransactionDateString());
        }
        public override string AcceptType => HeaderConstant.ApplicationJson;
        public override iParaLinkPaymentCreateResponse Execute(iParaLinkPaymentCreateRequest model)
        {
            model.Mode = _iParaClientConnection.GetMode();
            var hashString = this.GetHashString(model);

            var header = this.WebHeaderCollection(hashString);


            using (var httpCaller = new RestHttpCallerHelpers())
            {
                var result = httpCaller.PostJson<iParaLinkPaymentCreateResponse>(GetRequestUrl, header, model);
                return result;
            }
        }
    }
}