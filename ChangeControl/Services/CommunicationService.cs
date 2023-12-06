using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeControl.Services
{
    public interface ICommunicationService
    {
        event Action<string> DataReceived;

        void SendData(string data);
    }

    public class CommunicationService : ICommunicationService
    {
        public event Action<string> DataReceived;

        public void SendData(string data)
        {
            DataReceived?.Invoke(data);
        }
    }
}
