using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public enum OrderStatus
    {
        ABERTA,
        ABANDONADA,
        AGUARDANDO_INTEGRACAO,
        NAO_AUTORIZADA,
        PAGO
    }
}
