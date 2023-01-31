﻿using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoDefinitivoDINT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Mensajes
{
    class NuevaPersonaValueChangedMessage : ValueChangedMessage<Autor>
    {
        public NuevaPersonaValueChangedMessage(Autor autor) : base(autor) { }

    }
}