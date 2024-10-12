using Domain.Models.Enums;

namespace Domain.Models
{
    public static class NI
    {
        public static string CategoryId { get; set; }
        public static string SubcategoryId { get; set; }
        public static string SubsubcategoryId { get; set; }
        public static string CategoryName { get; set; }
        public static string SubcategoryName { get; set; }
        public static string SubsubcategoryName { get; set; }
        public static Navigation Navigation { get; set; }
    }
}
