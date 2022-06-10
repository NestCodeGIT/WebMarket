using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Modelss;

namespace WebMarket.DataAccess.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicatonDbContext01 _db;

        public CategoryService( ApplicatonDbContext01 db)
        {
            _db = db;
        }
        public void Add( Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();

        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _db.Categories;
            return query;
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _db.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Category entity)
        {
            _db.Categories.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.Categories.RemoveRange(entities);
            _db.SaveChanges();
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();

        }

    }
}
