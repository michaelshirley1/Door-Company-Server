using BusinessApi.Interfaces;
using BusinessApi.Models;

namespace BusinessApi.Factories
{
    public interface IJobFactory
    {
        Job? GetById(int id);
        IEnumerable<Job> GetAll();
    }

    public class JobFactory : IJobFactory
    {
        private static readonly List<Job> _jobs =
        [
            new Job { Id = 1, Title = "Install HVAC System",    Description = "Full installation at site A", Status = "In Progress" },
            new Job { Id = 2, Title = "Electrical Rewire",      Description = "Rewire warehouse B",          Status = "Pending"     },
            new Job { Id = 3, Title = "Plumbing Repair",        Description = "Fix leaks in building C",     Status = "Completed"   },
        ];

        public Job? GetById(int id) =>
            _jobs.FirstOrDefault(j => j.Id == id);

        public IEnumerable<Job> GetAll() => _jobs;
    }
}
