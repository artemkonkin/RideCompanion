﻿using Shared.Core.Entities;

namespace Product.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public bool IsActive { get; set; } = true;
    public string Description { get; set; }
    public decimal Rate { get; set; }
    public decimal BuyingPrice { get; set; }
    public string ConfidentialData { get; set; }
}