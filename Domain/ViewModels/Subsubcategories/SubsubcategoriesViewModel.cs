using Domain.Models;

namespace Domain.ViewModels.Subsubcategories
{
    public class SubsubcategoriesViewModel : BaseViewModel<Subsubcategory>
    {
        public List<Subsubcategory> Subsubcategories { get; set; }
    }
}
