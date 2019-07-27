using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ECommerce.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SqlConnection _connection;
        protected readonly string _query;
        public Repository()
        {
            _connection = ConnectionFactory.GetConnection();
            _query = $@"Select * from {typeof(TEntity).Name}";
        }

        public List<TEntity> Entities { get; set; }

        public virtual void Add(TEntity obj)
        {
            Entities.Add(obj);
        }

        public List<TEntity> GetAll()
        {
            return _connection.Query<TEntity>(_query).AsList();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
       
    }
}
