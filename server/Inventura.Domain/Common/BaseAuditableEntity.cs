namespace Inventura.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? LastUpdatedBy { get; set; }
}

public abstract class BaseAuditableEntity : BaseAuditableEntity<int> { }
