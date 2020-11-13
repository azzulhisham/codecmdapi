using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodeCmdAPI.Models;

namespace CodeCmdAPI.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> FindForCommands(Expression<Func<Command, bool>> predicate)
        {
            var commands = new List<Command>()
            {
                new Command() {
                    Id = 1,
                    HowTo = "Code in C#",
                    Line = "Hello World",
                    Platform = "Programming"
                },

                new Command() {
                    Id = 2,
                    HowTo = "Code In VB",
                    Line = "Hello World",
                    Platform = "Programming"
                }
            };

            return commands;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command() {
                    Id = 0,
                    HowTo = "Say Hello",
                    Line = "Hello World",
                    Platform = "Programming"
                },

                new Command() {
                    Id = 1,
                    HowTo = "Code in C#",
                    Line = "Hello World",
                    Platform = "Programming"
                },

                new Command() {
                    Id = 2,
                    HowTo = "Code In VB",
                    Line = "Hello World",
                    Platform = "Programming"
                }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command() {
                Id = 0,
                HowTo = "Say Hello",
                Line = "Hello World",
                Platform = "Programming"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}