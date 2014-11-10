using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable 
    { 
        ecommerceContext DataContext { get; } 
    }
}
