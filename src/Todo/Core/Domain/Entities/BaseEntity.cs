namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateTime { get; set; }
    virtual public DateTime UpdatedDate { get; set; }
}