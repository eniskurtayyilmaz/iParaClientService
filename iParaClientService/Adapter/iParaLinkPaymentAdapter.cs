using iParaClientService.Constant;
using iParaClientService.Domain;
using iParaClientService.Model.Request;
using iParaClientService.Model.Response;
using iParaClientService.Service;
using iParaClientService.Utils;

namespace iParaClientService.Adapter
{

    public class iParaLinkPaymentAdapter
        : AbstractIParaExecuter<iParaLinkPaymentCreateRequest, iParaLinkPaymentCreateResponse>
    {
        private readonly iParaClientConnection _iParaClientConnection;

        public iParaLinkPaymentAdapter(iParaClientConnection iParaClientConnection) : base(iParaClientConnection)
        {
            _iParaClientConnection = iParaClientConnection;
        }
        public override string GetRequestUrl => RequestUrlConstant.LinkPaymentCreate;
        public override string GetHashString(iParaLinkPaymentCreateRequest model)
        {
            return HashStringBuilderHelpers.GetHashString(_iParaClientConnection.PrivateKey, model.Name,
                                                          model.Surname, model.Email, model.Amount.ToString(),
                                                          model.ClientIp, HeaderHelpers.GetTransactionDateString());
        }

        public override iParaLinkPaymentCreateResponse Execute(iParaLinkPaymentCreateRequest model)
        {
            var hashString = this.GetHashString(model);
            //iParaLinkPaymentCreateResponse
            //    result = _iParaClientConnection.CallRequest<iParaLinkPaymentCreateResponse>();

            return new iParaLinkPaymentCreateResponse()
            {
                ErrorCode = "errorCode"
            };
        }

    }
}