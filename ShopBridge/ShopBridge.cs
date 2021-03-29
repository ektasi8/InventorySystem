namespace ShopBridge
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopBridge")]
    public partial class ShopBridge
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public double? Price { get; set; }

        public int? Qty { get; set; }

        public bool? Status { get; set; }
    }
}
