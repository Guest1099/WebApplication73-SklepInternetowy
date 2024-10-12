using Domain.Models;

namespace Domain.ViewModels.Sizes
{
    public class SizesViewModel : BaseViewModel<Size>
    {
        public List<Size> Sizes { get; set; }
    }
}
