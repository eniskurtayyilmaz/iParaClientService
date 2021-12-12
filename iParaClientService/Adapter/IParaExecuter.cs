using iParaClientService.Domain;

namespace iParaClientService.Adapter
{
    public interface IParaExecuter
    {
        AbstractiParaResponseBase Execute(AbstractiParaRequestBase model);
    }
}