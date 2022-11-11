using Shared.Core.Entities;

namespace Driver.Domain.Entities;

public class DriverEntity : IBaseEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    
    public string UserId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}