﻿using BudgetPlannerBE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Infrastructure.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
