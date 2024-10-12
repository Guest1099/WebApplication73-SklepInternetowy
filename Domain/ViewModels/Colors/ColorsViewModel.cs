using Domain.Models;

namespace Domain.ViewModels.Colors
{
    public class ColorsViewModel : BaseViewModel<Color>
    {
        public List<Color> Colors { get; set; }
    }
}
