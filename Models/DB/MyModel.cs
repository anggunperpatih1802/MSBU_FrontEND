using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis;
using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVCCallWebAPI_ANGGUN.Models.DB
{
    public  class tr_bpkb
    {
        [Key]
        public string agreement_number { get; set; }
        public string bpkb_no { get; set; }
        public string branch_id { get; set; }
        public DateTime? bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public DateTime? faktur_date { get; set; }
        public string location_id { get; set; }
        public string police_no { get; set; }
        public DateTime? bpkb_date_in { get; set; }

        [NotMapped]
        public List<ms_storage_location> ms_storage_locationCollection { get; set; }
    }
    public  class ms_storage_location
    {
        [Key]
        public string location_id { get; set; }
        public string location_name { get; set; }
    }

}
