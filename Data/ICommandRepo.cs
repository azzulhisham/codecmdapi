using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodeCmdAPI.Models;


namespace CodeCmdAPI.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        
        IEnumerable<Command> GetAllCommands();
        IEnumerable<Command> FindForCommands(Expression<Func<Command, bool>> predicate);
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
    }
}