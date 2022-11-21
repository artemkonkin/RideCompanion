using Companion.Domain.Entities;
using Driver.Domain.Entities;

namespace Trip.Domain.Dto;

/// <summary>
/// Поездка
/// </summary>
public class TripDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    
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
    
    /// <summary>
    /// Id создателя
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Id обновившего
    /// </summary>
    public Guid UpdateById { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Удален ли. True - да / False - нет
    /// </summary>
    public bool IsDeleted { get; set; }
}