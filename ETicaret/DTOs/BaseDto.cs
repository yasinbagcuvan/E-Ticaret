namespace DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public int? RowNum { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }

    }
}
