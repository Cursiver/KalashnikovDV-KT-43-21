using KalashnikovDV_KT_43_21.Database;
using KalashnikovDV_KT_43_21.Filters.TeacherFilters;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace KalashnikovDV_KT_43_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teachers[]> GetTeachersByDisciplineAsync(TeacherDisciplineFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly InstitutDbContext _dbContext;

        public TeacherService(InstitutDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Teachers[]> GetTeachersByDisciplineAsync(TeacherDisciplineFilter filter, CancellationToken cancellationToken = default)
        { 
            var teachers = _dbContext.Set<Teachers>().Where(w => w.Disciplines.DisciplineName == filter.DisciplineName).ToArrayAsync(cancellationToken);

            return teachers;
        }
    }
}
