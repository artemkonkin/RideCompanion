using Shared.Core.Entities;

namespace Driver.Domain.Dto;

/// <summary>
/// Авто
/// </summary>
public class CarDto : IAuditableEntity
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public string UserId { get; set; }
    
    /// <summary>
    /// Водитель
    /// </summary>
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Номер
    /// </summary>
    public string Number { get; set; }
    
    /// <summary>
    /// Цвет
    /// </summary>
    public string Color { get; set; }
    
    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; set; }
    
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