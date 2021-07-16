using DatabaseDataViewerWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DatabaseDataViewerWeb.Data
{
    public class IISFailedRequestDbContext : DbContext
    {
        public IISFailedRequestDbContext(DbContextOptions<IISFailedRequestDbContext> options) : base(options)
        {

        }
        public DbSet<t_fal_req_log> T_fal_req_log { get; set; }
    }
}
