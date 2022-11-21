using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Shared.Core.Entities;

namespace Trip.Domain.Entities;

/// <summary>
/// Поездка
/// </summary>
public class TripEntity : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public DriverEntity Driver { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public CompanionEntity Companion { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public CarEntity Car { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string AddressFrom { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string AddressTo { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime DateTime { get; set; }
}