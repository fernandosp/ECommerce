﻿using System.Collections.Generic;
/// <summary>
/// To List the amount of Products and to put it in onto PO
/// </summary>
namespace ECommerce.Domain
{
    public class OrderItens : Entity
    {
        List<Product> Products { get; set; }
    }

}
