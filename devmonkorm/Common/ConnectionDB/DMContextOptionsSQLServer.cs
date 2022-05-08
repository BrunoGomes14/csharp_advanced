using Microsoft.Data.SqlClient;

namespace devmonkorm.Common
{
    public partial class DMContextOptions
    {
        public DMContextOptions UseSqlServer() 
        {
            var connection = new SqlConnection(ConnectionString);
            Connection = connection;
            
            return this;
        }
    }
}