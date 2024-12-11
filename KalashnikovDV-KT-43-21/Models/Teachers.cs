using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Models
{
    public class Teachers
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int FKDisciplineID { get; set; }
        public Disciplines Disciplines { get; set; } //навигационное свойство
    }
}
