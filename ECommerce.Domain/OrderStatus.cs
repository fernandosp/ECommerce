using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// It is all status order when any shop cart had began <Open | Missing | Waiting for Integration Response | Unauthorized | Paid>
/// </summary>
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
