using AutoMapper;
using Chat_Api.Models;
using Chat_Business.Models;
using Chat_Business.Services;
using Chat_Business.Services.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Chat_Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/chats")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService service;
        private readonly Mapper mapper;

        public ChatController(IChatService _service)
        {
            service = _service;
            mapper = new Mapper(AutoMapper_API.GetMapperConfiguration());
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var res = mapper.Map<IEnumerable<ChatModelAPI>>(service.GetAll());
            return Ok(res);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) =>
            Ok(mapper.Map<ChatModelAPI>(service.GetById(id)));



        [HttpPost]
        public IActionResult Post([FromBody] ChatModelAPI value)
        {
            try
            {
                service.Create(mapper.Map<ChatModelBL>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ChatModelAPI value)
        {
            try
            {
                service.Update(mapper.Map<ChatModelBL>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}