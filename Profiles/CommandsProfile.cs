using AutoMapper;
using CodeCmdAPI.Models;
using CodeCmdAPI.Dtos;


namespace CodeCmdAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDtoRead>();
            CreateMap<CommandDtoWrite, Command>();
            CreateMap<CommandDtoUpdate, Command>();
            CreateMap<Command, CommandDtoUpdate>();
        }
    }
}