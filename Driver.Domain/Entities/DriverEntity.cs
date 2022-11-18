using Shared.Core.Entities;

namespace Driver.Domain.Entities;

/// <summary>
/// Водитель
/// </summary>
public class DriverEntity : BaseEntity
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public string UserId { get; set; }
    
    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }
}