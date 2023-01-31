using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Mensajes
{
    class NuevaPersonaValueChangedMessage : ValueChangedMessage<string>
    {
        public NuevaPersonaValueChangedMessage(string autor) : base(autor) { }

    }
}
