using Microsoft.EntityFrameworkCore;
using CodeCmdAPI.Models;

namespace CodeCmdAPI.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; } 
    }   
}