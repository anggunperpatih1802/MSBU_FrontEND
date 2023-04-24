using Microsoft.EntityFrameworkCore;
using MVCCallWebAPI_ANGGUN.Models.DB;

#nullable disable

namespace MVCCallWebAPI_ANGGUN.Models.DB
{
    public partial class DB_Demo_APIContext : DbContext
    {
        public DB_Demo_APIContext()
        {
        }

        public DB_Demo_APIContext(DbContextOptions<DB_Demo_APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tr_bpkb> tr_bpkb { get; set; }
        public virtual DbSet<ms_storage_location> ms_storage_location { get; set; }


    }
}