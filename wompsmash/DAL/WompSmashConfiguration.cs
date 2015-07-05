using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using wompsmash.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace wompsmash.DAL
{
    public class WompSmashConfiguration : DbConfiguration
    {
        public WompSmashConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new WompSmashInterceptorTransientErrors());
            DbInterception.Add(new WompSmashInterceptorLogging());
        }
    }
}