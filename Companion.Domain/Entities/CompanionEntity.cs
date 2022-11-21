using Shared.Core.Entities;

namespace Companion.Domain.Entities;

/// <summary>
/// Попутчик
/// </summary>
public class CompanionEntity : BaseEntity
{
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
}