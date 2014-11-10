﻿using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
    public class PromotionRepository : RepositoryBase<promotion>,IPromotionRepository
    {
                public PromotionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
        public interface IPromotionRepository :IRepository <promotion> {}
}
