using System.ComponentModel.DataAnnotations;

namespace CodeCmdAPI.Dtos
{
    public class CommandDtoWrite
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        [MaxLength(50)]
        public string Platform { get; set; }
    }
}