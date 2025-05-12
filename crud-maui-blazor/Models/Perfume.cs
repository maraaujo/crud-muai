using SQLite;

namespace crud_maui_blazor.Models
{
    public class Perfume
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Name { get; set; }
    
        public double? Volume { get; set; }
    }
}
