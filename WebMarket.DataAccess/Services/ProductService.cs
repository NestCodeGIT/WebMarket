using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webmarket.Modelss;
using Webmarket.Modelss.ViewModel;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicatonDbContext01 _db;

        public ProductService (ApplicatonDbContext01 db)
        {
            _db = db;
        }
        public void Add(ProductVM entity)
        {
            _db.Products.Add(entity.Product);
            _db.SaveChanges();

        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(c => c.Category).Include(c => c.CoverType);
            return query;
        }

        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }
       

        public void Update(Product obj)
        {
            var Objproduct = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (Objproduct!=null)
            {
                Objproduct.Title = obj.Title;
                Objproduct.Description = obj.Description;
                Objproduct.ShortDescription = obj.ShortDescription;
                Objproduct.ISBN = obj.ISBN;
                Objproduct.Author = obj.Author;
                Objproduct.ListPrice = obj.ListPrice;
                Objproduct.Price = obj.Price;
                Objproduct.Price50 = obj.Price50;
                Objproduct.Price100 = obj.Price100;
                if (obj.ImgeUrl != null)
                {
                    Objproduct.ImgeUrl = obj.ImgeUrl;
                }
              
                Objproduct.CategoryId = obj.CategoryId;
                Objproduct.CoverTypeId = obj.CoverTypeId;
            }

            _db.SaveChanges();

        }

    }
}
