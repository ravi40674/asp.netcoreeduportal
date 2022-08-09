using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;

namespace EducationPortal.Repository
{
    public class Slider : ISlider
    {
        private static EducationPortalDBContext _context;
        public readonly IWebHostEnvironment _IWebHostEnvironment;

        public Slider(EducationPortalDBContext context, IWebHostEnvironment IWebHostEnvironment)
        {
            _context = context;
            _IWebHostEnvironment = IWebHostEnvironment;
        }


        public SliderViewModel GetSliderDetailBySliderID(int sliderID)
        {
            return (from i in _context.tblSlider
                    where i.SliderID==sliderID
                    select new SliderViewModel
                    {
                        imgurl=i.Image,
                        IsActive=i.IsActive,
                        IsDeleted=i.IsDeleted,
                        SliderID=i.SliderID,
                        CreatedBy=i.CreatedBy,
                        CreatedDate=i.CreatedDate,
                        Description=i.Description,
                        ModifiedBy=i.ModifiedBy,
                        ModifiedDate=i.ModifiedDate,
                        PageName=i.PageName,
                        SortOrder=i.SortOrder,
                        Title=i.Title
                    }).FirstOrDefault();
        }

        public bool IsPageNameExists(string pageName)
        {
            var record = _context.tblSlider.Where(x => x.PageName == pageName).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUpdatePageExists(string pageName, int sliderID)
        {
            var record = _context.tblSlider.Where(x => x.PageName == pageName && x.SliderID != sliderID).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public SliderViewModel PostSliderDetailBySliderID(int sliderID, string fileName)
        {
            var record = (from i in _context.tblSlider
                          where i.SliderID == sliderID
                          select new SliderViewModel
                          {
                              imgurl = i.Image,
                              IsActive = i.IsActive,
                              IsDeleted = i.IsDeleted,
                              SliderID = i.SliderID,
                              CreatedBy = i.CreatedBy,
                              CreatedDate = i.CreatedDate,
                              PageName = i.PageName,
                              Description = i.Description,
                              SortOrder = i.SortOrder,
                              ModifiedBy = i.ModifiedBy,
                              ModifiedDate = i.ModifiedDate,
                              Title=i.Title
                          }).FirstOrDefault();
            return record;
        }

        public IQueryable<SliderViewModel> SliderListBind()
        {
            return from i in _context.tblSlider
                   select new SliderViewModel {
                   imgurl=i.Image,
                   IsActive=i.IsActive,
                   IsDeleted=i.IsDeleted,
                   SliderID=i.SliderID,
                   CreatedBy=i.CreatedBy,
                   CreatedDate=i.CreatedDate,
                   Description=i.Description,
                   ModifiedBy=i.ModifiedBy,
                   ModifiedDate=i.ModifiedDate,
                   PageName=i.PageName,
                   SortOrder=i.SortOrder,
                   Title=i.Title
                   };
        }

        public string Uploadimage(SliderViewModel model)
        {
            string filename = null;
            if (model.Image != null)
            {
                if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png" || model.Image.ContentType == "image/jpg")
                {
                    string path = Path.Combine(_IWebHostEnvironment.WebRootPath, "Images");
                    filename = model.PageName + "-" + model.Image.FileName;
                    string filepath = Path.Combine(path, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        model.Image.CopyTo(filestream);
                    }
                    return filename;
                }
            }
            return filename;
        }
    }
}
