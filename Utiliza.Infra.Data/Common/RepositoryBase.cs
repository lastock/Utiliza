using System;
using System.Data;
using System.Data.SqlClient;
using Utiliza.Infra.Data.Config;

namespace Utiliza.Infra.Data.Common
{
    public class RepositoryBase : IDisposable
    {
        public IDbConnection UtilizaConnection
        {
            get { return new SqlConnection(Helper.ConnextionString("")); }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
