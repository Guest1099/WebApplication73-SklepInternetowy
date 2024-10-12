using Domain.Models;

namespace Domain.ViewModels.Subcategories
{
    public class SubcategoriesViewModel : BaseViewModel<Subcategory>
    {
        public List<Subcategory> Subcategories { get; set; }
    }
}
