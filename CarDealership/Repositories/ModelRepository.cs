using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Utils;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace CarDealership.Repositories
{
    internal class ModelRepository : IModelRepository
    {
        private CarDealershipMainContext db = new();

        public ModelRepository()
        {
            db.Models.Include(m => m.CarBrand).ToList();
        }

        public void AddModel(ModelDTO model)
        {
            db.Models.Add(new Model()
            {
                Name = model.Name,
                CarBrandId = model.CarBrandId,
                Image = ImageConverter.ConvertBitmapImageToByteArray(model.Image),
            });

            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var model = db.Models.Find(id);

            if (model != null) 
            {
                db.Models.Remove(model);

                return Save();
            }
            return false;
        }

        public List<ModelDTO> GetAll()
        {
            return db.Models.Include(m => m.CarBrand).Select(i => new ModelDTO(i)).ToList();
        }

        public void Update(ModelDTO model)
        {
            var m = db.Models.Find(model.Id);
            if (m != null)
            {
                m.Image = ImageConverter.ConvertBitmapImageToByteArray(model.Image);
                m.Name = model.Name;
                m.CarBrandId = model.CarBrandId;
                db.SaveChanges();
            }
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
