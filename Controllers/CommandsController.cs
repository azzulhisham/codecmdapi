using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeCmdAPI.Models;
using CodeCmdAPI.Data;
using CodeCmdAPI.Dtos;
using AutoMapper;
using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace CodeCmdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<CommandDtoRead>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandDtoRead>>(commandItems));
        }

        [HttpGet("for/{query}")]
        public ActionResult<IEnumerable<CommandDtoRead>> GetForCommands(string query)
        {
            var commandItems = _repo.FindForCommands(n => n.Line.Contains(query));

            return Ok(_mapper.Map<IEnumerable<CommandDtoRead>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandDtoRead> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);

            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandDtoRead>(commandItem));
            }
            else 
            {
                return NotFound();
            }
        }   

        //Post api/commands
        [HttpPost]
        public ActionResult<CommandDtoRead> CreateNewCommand(CommandDtoWrite commandDtoWrite)
        {
            var command = _mapper.Map<Command>(commandDtoWrite);
            _repo.CreateCommand(command);

            try
            {
                var result = _repo.SaveChanges();
                
                if (result)
                {
                    var respondData = _mapper.Map<CommandDtoRead>(command);
                    return CreatedAtRoute(nameof(GetCommandById), new {Id = respondData.Id}, respondData);               
                }
                else
                {
                    return BadRequest();
                }                
            }
            catch (System.Exception)
            {     
                return BadRequest();
            }
        }  

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandDtoUpdate commandDtoUpdate)
        {
            var commandFromRepo = _repo.GetCommandById(id);

            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandDtoUpdate, commandFromRepo);
            
            _repo.UpdateCommand(commandFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }  

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandDtoUpdate> patchDoc)
        {
            var commandFromRepo = _repo.GetCommandById(id);

            if (commandFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandDtoUpdate>(commandFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);

            _repo.UpdateCommand(commandFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }    

        [HttpDelete("{id}")]
        public ActionResult DeleteCommands(int id)
        {
            var commandFromRepo = _repo.GetCommandById(id);

            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteCommand(commandFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }                                 
    }
}