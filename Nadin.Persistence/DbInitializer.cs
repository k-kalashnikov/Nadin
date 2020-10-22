using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Persistence
{
    public class DbInitializer
    {
        public static Task SeedAsync(ApplicationDbContext context)
        {
            return Task.CompletedTask;
        }
    }
}
