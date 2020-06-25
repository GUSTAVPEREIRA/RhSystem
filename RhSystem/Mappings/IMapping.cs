namespace RhSystem.Mappings
{
    using Microsoft.EntityFrameworkCore;

    public interface IMapping
    {
        public void Mapping(ref ModelBuilder builder);
    }
}