using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalog.Entities;

namespace ProductCatalog.Extensions
{
    public static class SoftDeleteEntityExtensions
    {
        public static bool Exist(this SoftDeleteEntity entity)
            => !(entity is null || entity.IsDeleted);
    }
}
