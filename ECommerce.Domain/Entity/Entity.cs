using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain
{
    /// <summary>
    /// Primary fields for all tables of eCommerce.API
    /// </summary>
    public class Entity
    {
        [Key]
        public int Id { get; set; }
       
    }
}
