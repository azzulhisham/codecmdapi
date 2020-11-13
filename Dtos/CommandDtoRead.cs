using System.ComponentModel.DataAnnotations;

namespace CodeCmdAPI.Dtos
{
    public class CommandDtoRead
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }
    }
}