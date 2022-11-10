namespace Shared.Core.Entities;

public interface IAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public Guid CreatedBy { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Guid UpdateBy { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime UpdateDate { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool IsDeleted { get; set; }
}