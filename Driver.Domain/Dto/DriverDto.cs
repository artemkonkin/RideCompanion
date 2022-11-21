namespace Driver.Domain.Dto;

/// <summary>
/// Водитель
/// </summary>
public class DriverDto
{
    public Guid Id { get; set; }
    
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