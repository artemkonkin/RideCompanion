namespace Shared.Core.Entities;

public interface IAuditableEntity
{
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