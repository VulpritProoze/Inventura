namespace Inventura.Application.Common.Models;

public class ModelDto
{
    // Fields you want to extract from the original entity
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            // CreateMap<Entity, ModelDto>();
        }
    }
}
