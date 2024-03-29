﻿using System.Linq.Expressions;
using Webmarket.Modelss;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;

namespace WebMarket.DataAccess.Services
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ApplicatonDbContext01 _db;

        public CoverTypeService(ApplicatonDbContext01 db)
        {
            _db = db;
        }
        public void Add(CoverType entity)
        {
            _db.CoverTypes.Add(entity);
            _db.SaveChanges();

        }

        public IEnumerable<CoverType> GetAll()
        {
            IEnumerable<CoverType> query = _db.CoverTypes;
            return query;
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter)
        {
            IQueryable<CoverType> query = _db.CoverTypes;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(CoverType entity)
        {
            _db.CoverTypes.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<CoverType> entities)
        {
            _db.CoverTypes.RemoveRange(entities);
            _db.SaveChanges();
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
            _db.SaveChanges();

        }

    }
}
