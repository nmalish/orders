﻿using System;
using System.Collections.Generic;

namespace Orders.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
