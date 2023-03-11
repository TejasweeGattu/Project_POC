using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataAccess_Layer.Models;

namespace DataAccess_Layer.FileModels
{
    public class FileDetails
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
        public int Sid { get; set; }
        public string FileName { get; set; }
            public byte[] FileData { get; set; }
            public FileType FileType { get; set; }
        public virtual Student SidNavigation { get; set; } = null!;

    }
}
