using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Mediator
{
    public class MessageMediatorDashboard: IMessageMediator
    {
        public MessageModel MessageModel { get; set; }
        public Dashboard Dashboard { get; set; }
        public bool RequireName { get; set; }

        public void SendMessage()
        {
            Dashboard.AppendMessageToTextBox();
        }
    }
}
