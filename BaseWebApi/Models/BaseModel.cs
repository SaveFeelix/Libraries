using BaseWebApi.Models.Types;

namespace BaseWebApi.Models;

public class BaseModel
{
    public int Id { get; set; }
    public int Version { get; set; } = 1;
    public bool Undeletable { get; set; } = false;
    public State State { get; set; } = State.Active;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Changed { get; set; } = DateTime.UtcNow;

    public virtual bool StateInsteadOfRemove() => false;
}

public class BaseModel<TDto> : BaseModel where TDto : new()
{
    public virtual TDto ToDto() => new();
}