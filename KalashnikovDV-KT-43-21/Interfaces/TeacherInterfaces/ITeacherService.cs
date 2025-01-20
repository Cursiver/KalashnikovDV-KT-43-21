using KalashnikovDV_KT_43_21.Database;
using KalashnikovDV_KT_43_21.Filters.TeacherFilters;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace KalashnikovDV_KT_43_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teachers[]> GetTeachersByDisciplineAsync(TeacherDisciplineFilter filter, CancellationToken cancellationToken);
        public Task<Teachers[]> GetTeachersByDepartmentsAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        public Task<Disciplines[]> GetDisciplinesByTeacherAsync(DisciplineTeacherFilter filter, CancellationToken cancellationToken);
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
        public Task<Teachers[]> GetTeachersByDepartmentsAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teachers>().Where(w => w.Disciplines.Departments.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

            return teachers;
        }
        public async Task<Disciplines[]> GetDisciplinesByTeacherAsync(DisciplineTeacherFilter filter, CancellationToken cancellationToken = default)
        {
            var filterTeachers = await _dbContext.Set<Teachers>().Where(w => w.FirstName == filter.FirstName).ToArrayAsync(cancellationToken);

            var disciplineIds = filterTeachers.Select(t => t.DisciplineID);

            var disciplines = await _dbContext.Set<Disciplines>().Where(d => disciplineIds.Contains(d.DisciplineId)).ToArrayAsync(cancellationToken);
            
            return disciplines;
        }

    }
}
