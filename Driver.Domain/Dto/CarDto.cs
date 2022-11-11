﻿namespace Driver.Domain.Dto;

public class CarDto
{
    public Guid Id { get; set; }
    
    public Guid DriverId { get; set; }
    public string Number { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }
    
    public Guid CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}