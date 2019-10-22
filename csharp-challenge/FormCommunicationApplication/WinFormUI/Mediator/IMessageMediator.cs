using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Mediator
{
    public interface IMessageMediator
    {
        MessageModel MessageModel { get; set; }
        bool RequireName { get; set; }

        void SendMessage();
    }
}
