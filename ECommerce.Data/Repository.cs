using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ECommerce.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SqlConnection _connection;
        protected readonly string _query;
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _connection = ConnectionFactory.GetConnection(_config.GetConnectionString("DefaultConnection"));
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
