namespace Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int? RowNum { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }

        public int AppUserId { get; set; }
       // public AppUser AppUser { get; set; }

    }
}
