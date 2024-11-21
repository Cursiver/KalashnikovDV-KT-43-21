using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Models
{
    public class Disciplines
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; } = string.Empty;
        public int DepartmentId { get; set; } //Кафедра //дисциплин беск:1 кафедра
        public Department Department { get; set; } //навигационное свойство
    }
}
