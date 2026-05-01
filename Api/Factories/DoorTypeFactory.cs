using BusinessApi.Models;

namespace BusinessApi.Factories
{
    public interface IDoorTypeFactory
    {
        IEnumerable<DoorType> GetAll();
        DoorType? GetById(int id);
        DoorType Create(DoorType doorType);
        DoorType? Update(int id, DoorType doorType);
        bool Delete(int id);
    }

    public class DoorTypeFactory : IDoorTypeFactory
    {
        private static int _nextId = 4;

        private static readonly List<DoorType> _doorTypes =
        [
            new DoorType
            {
                Id = 1,
                Name = "Solid Core Timber",
                LeafType = "Single",
                Material = "Timber",
                Description = "Standard solid core timber door, suitable for interior and exterior use.",
                IsActive = true,
                Price = 500.00f,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new DoorType
            {
                Id = 2,
                Name = "Hollow Core",
                LeafType = "Single",
                Material = "Composite",
                Description = "Lightweight hollow core door for interior use.",
                IsActive = true,
                Price = 69.00f,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new DoorType
            {
                Id = 3,
                Name = "Fire Door",
                LeafType = "Single",
                Material = "Steel",
                Description = "FRR 60/60/60 rated fire door for commercial buildings.",
                IsActive = true,
                Price = 56.23f,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
        ];

        public IEnumerable<DoorType> GetAll() => _doorTypes;

        public DoorType? GetById(int id) =>
            _doorTypes.FirstOrDefault(d => d.Id == id);

        public DoorType Create(DoorType doorType)
        {
            doorType.Id = _nextId++;
            doorType.CreatedAt = DateTime.UtcNow;
            _doorTypes.Add(doorType);
            return doorType;
        }

        public DoorType? Update(int id, DoorType doorType)
        {
            var existing = _doorTypes.FirstOrDefault(d => d.Id == id);
            if (existing is null) return null;

            existing.Name = doorType.Name;
            existing.LeafType = doorType.LeafType;
            existing.Material = doorType.Material;
            existing.Description = doorType.Description;
            existing.IsActive = doorType.IsActive;
            return existing;
        }

        public bool Delete(int id)
        {
            var existing = _doorTypes.FirstOrDefault(d => d.Id == id);
            if (existing is null) return false;
            _doorTypes.Remove(existing);
            return true;
        }
    }
}
