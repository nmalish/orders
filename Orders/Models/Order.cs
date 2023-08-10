using System;
using System.Collections.Generic;

namespace Orders.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? StatusId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Status Status { get; set; }
}
