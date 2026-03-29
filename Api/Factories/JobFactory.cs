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
            new Job { Id = 1 },
            new Job { Id = 2 },
            new Job { Id = 3 },
        ];

        public Job? GetById(int id) =>
            _jobs.FirstOrDefault(j => j.Id == id);

        public IEnumerable<Job> GetAll() => _jobs;
    }
}
