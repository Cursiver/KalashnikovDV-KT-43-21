namespace KalashnikovDV_KT_43_21.Models
{
    public class Disciplines
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; } = string.Empty;

        public int DepartmentId { get; set; } //Кафедра
        //[JsonIgnore]  //отключено в рамках теста
        public Departments Departments { get; set; } //навигационное свойство

    }
}
