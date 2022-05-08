using System.Data.Common;

namespace devmonkorm.Common
{
    public partial class DMContextOptions
    {
        public DMContextOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }
        public DbConnection Connection { get; private set; }
    }
}