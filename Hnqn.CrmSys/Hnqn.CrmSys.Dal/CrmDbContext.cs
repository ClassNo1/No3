using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Hnqn.CrmSys.Models;

namespace Hnqn.CrmSys.Dal
{
    public class CrmDbContext:DbContext
    {
        public CrmDbContext()
            :base("name=connStr")
        {

        }
        public DbSet<UserType> UserType { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<UserStatus> UserStatus { get; set; }

        public DbSet<CustomerInfo> CustomerInfo { get; set; }

        public DbSet<Professiona> Professiona { get; set; }

        public DbSet<Recording> Recording { get; set; }

        public DbSet<SchoolInfo> SchoolInfo { get; set; }

        public DbSet<SourceInfo> SourceInfo { get; set; }
    }
}
