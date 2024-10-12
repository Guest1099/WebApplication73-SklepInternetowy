using Domain.Models;

namespace Domain.ViewModels.Categories
{
    public class CategoriesViewModel : BaseViewModel<Category>
    {
        public List<Category> Categories { get; set; }
    }
}
