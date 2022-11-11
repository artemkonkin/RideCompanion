namespace Driver.Domain.Dto;

public class DriverDto
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}