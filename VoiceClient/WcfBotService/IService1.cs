using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfBotService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetDialogFlowAnswer(string message);
        [OperationContract]
        Task RecoFromMicrophoneAsync();
        [OperationContract]
        string GetDetectedText();
        // TODO: dodaj tutaj operacje usługi
    }


}
