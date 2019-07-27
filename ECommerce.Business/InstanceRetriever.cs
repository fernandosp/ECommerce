using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain;
using ECommerce.Data;

namespace ECommerce.Business
{
    public class InstanceRetriever<T> where T : Entity {
        private static IRepository<T> repository;

        static public List<T> GetList() {
            return repository.GetAll();
        }

        public InstanceRetriever(IRepository<T> obj) {

            repository = obj;
        }
    }
}
