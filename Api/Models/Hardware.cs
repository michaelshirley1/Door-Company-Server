namespace BusinessApi.Models
{
    public class DoorType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LeafType { get; set; }
        public string? Material { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class HingeType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Finish { get; set; }
        public string? SizeMm { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class HandleType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Finish { get; set; }
        public string? Mechanism { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
