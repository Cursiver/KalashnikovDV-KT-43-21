using Microsoft.AspNetCore.Mvc;
using KalashnikovDV_KT_43_21.Filters.TeacherFilters;
using KalashnikovDV_KT_43_21.Interfaces.TeacherInterfaces;

namespace KalashnikovDV_KT_43_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //public class ServiceExtensions
    public class TeachersController : ControllerBase
    {
        public readonly ILogger<TeachersController> _logger;
        public readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost(Name = "GetTeachersByDiscipline")]
        public async Task<IActionResult> GetTeachersByDisciplineAsync(TeacherDisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByDisciplineAsync(filter, cancellationToken);

            return Ok(teachers);
        }
    }
}