using System.ComponentModel.DataAnnotations;

namespace SistemaVideos.Model
{
    public class Video
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
    }
}