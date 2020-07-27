using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfRotatePic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IRotatePicService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IRotatePicService
    {
        [OperationContract]
        void RotatePic(int i);

        [OperationContract]
        string StartRotatePic(string path, int angle);
    }
}
