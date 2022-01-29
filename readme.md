# iParaClientService

| Name | Status |
| ------ | ------ |
| Tests | ![Build and Tests](https://github.com/eniskurtayyilmaz/iParaClientService/actions/workflows/main.yml/badge.svg) |
| Nuget Published |[![Deploy to NuGet](https://github.com/eniskurtayyilmaz/iParaClientService/actions/workflows/nuget.yml/badge.svg)](https://www.nuget.org/packages/iParaClientService/) |

### Dependency
- .Net Framework >= 4.5.2
-- Newtonsoft.Json >= 13.0.0.0
- .Net Core - _Feature_

### Motivation
Honestly we had the job about iPara integration. When I check [their github repository](https://github.com/ipara), I didn't like it. It may be understandable for new integration, but If you have an idea to integration for your each project, It’s not good idea because of It makes you a stressed man. So, I decided to create a library and that will be sharing as open source.


### Installation
- Get your private and publich key from iPara Portal.
- Setup your environment in your code  _(like url, mode, publicKey, privateKey, version)_
- Get _iParaClientConnection_ instance
- Create request model 
- Use _iParaClientAdapter_ dependency of your request model
- Get the result!

### Example Create Link Request
```csharp
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
string baseUrl = "https://api.ipara.com/";
iParaConnectionMode mode = iParaConnectionMode.Test;
string version = "1.0";
using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
{
    var model = new iParaLinkPaymentCreateRequest
    {
        SendEmail = true,
        Name = "Kurtay",
        Surname = "Yılmaz",
        TaxNumber = "",
        ExpireDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss"),
        Gsm = "5397143516",
        /// Other required properties, like Email, ClientIp etc.
    };
    model.SetAmount(10.50); //10,50 TL EURO DOLAR
    var adapter = new iParaLinkPaymentCreateAdapter(connection);
    var result = adapter.Execute(model);
    
    //result.Link
    //https://portal.ipara.com/faces/payment/transaction_link_payment.jsf?linkToken=00224d3V13qW77y5D0DkfRB6w%3D%3D
}
````

### Example Created Link List Request
```csharp
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
string baseUrl = "https://api.ipara.com/";
iParaConnectionMode mode = iParaConnectionMode.Test;
string version = "1.0";
using (var connection = new iParaClientConnection(baseUrl, publicKey, privateKey, mode, version))
{
    string linkId = "iParaLinkPaymentCreateResponse.LinkPaymentId";
    var model = new iParaLinkPaymentListRequest
    {
        PageSize = 15,
        PageIndex = 1,
        Email = "kurtayyilmaz@gmail.com",
        LinkId = linkId, //Optional
        LinkState = LinkState.LinkPaymentDone //Optional
        /// Other optional properties, like Email, GSM etc
    };
    var adapter = new iParaLinkPaymentListAdapter(connection);
    var result = adapter.Execute(model);
}
````

### Buy me a coffee
You can [buy me a coffee](https://www.buymeacoffee.com/eniskurtay) if you want to say _thank you_:) 