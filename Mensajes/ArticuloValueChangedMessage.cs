﻿using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoDefinitivoDINT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Mensajes
{
    class ArticuloValueChangedMessage : ValueChangedMessage<Articulo>
    {
        public ArticuloValueChangedMessage(Articulo articulo) : base(articulo) { }
    }
}