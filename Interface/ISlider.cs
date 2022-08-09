using EducationPortal.ViewModel;
using System.Linq;

namespace EducationPortal.Interface
{
    public interface ISlider
    {
        SliderViewModel GetSliderDetailBySliderID(int sliderID);
        bool IsPageNameExists(string pageName);
        string Uploadimage(SliderViewModel model);
        SliderViewModel PostSliderDetailBySliderID(int sliderID, string fileName);
        IQueryable<SliderViewModel> SliderListBind();
        bool IsUpdatePageExists(string pageName, int sliderID);
    }
}
