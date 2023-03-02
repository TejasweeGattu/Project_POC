using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.DTO
{
    public class Dto
    {
        public string Cname { get; set; }

        public string Dname { get; set; } = null!;

        public string Dhod { get; set; } = null!;

        public string Dblock { get; set; } = null!;

        public bool ActiveFlag { get; set; }
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

       
    }
}
