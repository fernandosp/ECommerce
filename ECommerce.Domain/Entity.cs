using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public class Entity
    {
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        public string Nome { get; set; }
    }
}
