namespace Companion.Domain.Dto;

/// <summary>
/// Попутчик
/// </summary>
public class CompanionDto
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; }
    
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