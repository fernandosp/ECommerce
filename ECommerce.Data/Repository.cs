using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ECommerce.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly string _query;
        protected readonly string _config;

        public Repository(IConfiguration config)
        {
            _config = config.GetConnectionString("DefaultConnection");
            _query = $@"Select * from {typeof(TEntity).Name}";
        }

        public List<TEntity> Entities { get; set; }

        public virtual TEntity Add(TEntity obj)
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<TEntity>("", obj).Single();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.GetAll<TEntity>().ToList();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Get<TEntity>(id);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

        public List<TEntity> QueryAll(string query)
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<TEntity>(query).ToList();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

        public TEntity Query(string query)
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<TEntity>(query).SingleOrDefault();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

        public TEntity Query(string query, object obj)
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<TEntity>(query, obj).SingleOrDefault();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
        }

    }
}
