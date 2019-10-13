using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Mediator
{
    class MessageMediatorSubDashboard: IMessageMediator
    {
        public MessageModel MessageModel { get; set; }
        public SubDashboard SubDashboard { get; set; }
        public bool RequireName { get; set; }

        public void SendMessage()
        {
            SubDashboard.AppendNameAndMessageToTextBox();
        }
    }
}
