using Microsoft.EntityFrameworkCore;
//using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Models
{
    public class Departments
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
