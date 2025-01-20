using System.Text.Json.Serialization;

namespace KalashnikovDV_KT_43_21.Models
{
    public class Teachers
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int DisciplineID { get; set; }
        //[JsonIgnore]  //отключено в рамках теста
        public Disciplines Disciplines { get; set; } //навигационное свойство
    }
}
