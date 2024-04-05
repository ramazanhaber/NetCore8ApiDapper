using NetCore8ApiDapper.Helper;
using NetCore8ApiDapper.Interfaces;
using NetCore8ApiDapper.Models;

namespace NetCore8ApiDapper.Repository
{
    public class OgrencilerRepository : GenericRepository<Ogrenciler>, IOgrencilerRepository
    {
        public OgrencilerRepository(DatabaseConnections connections, IConfiguration configuration) : base(connections, configuration)
        {
        }


    }

}
