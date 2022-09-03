using AutoMapper;
using Chat_Api.Models;
using Chat_Business.Models;
using Chat_Business.Services;
using Chat_Business.Services.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService service;
        private readonly Mapper mapper;

        public MessageController(IMessageService _service)
        {
            service = _service;
            mapper = new Mapper(AutoMapper_API.GetMapperConfiguration());
        }
        [HttpGet]
        public IActionResult Get() =>
            Ok(mapper.Map<IEnumerable<MessageModelAPI>>(service.GetAll()));

        [HttpGet("{id}")]
        public IActionResult Get(int id) =>
            Ok(mapper.Map<MessageModelAPI>(service.GetById(id)));


        [HttpGet("pages/{chatId}")]
        public IActionResult GetPages(int chatId)
        {
            List<MessageModelAPI> all_messages = mapper.Map<List<MessageModelAPI>>(service.GetAll());
            MessageModelAPI[] chat_messages = all_messages.Where(x => x.chatId == chatId).ToArray();
            return Ok(chat_messages.Count() / 20 + 1);

        }

        [HttpGet("{chatId}/{page}")]
        public IActionResult GetPartial(int chatId, int page)
        {
            List<MessageModelAPI> all_messages = mapper.Map<List<MessageModelAPI>>(service.GetAll());
            MessageModelAPI[] chat_messages = all_messages.Where(x=>x.chatId == chatId).ToArray();

            if (chat_messages.Length - page * 20 < 20)
            {
                return Ok(chat_messages.Skip(page * 20).ToList());
            }
            else
            {
                return Ok(chat_messages.Skip(page * 20).Take(20).ToList());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MessageModelAPI value)
        {
            try
            {
                service.Create(mapper.Map<MessageModelBL>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("deletesef/{id}")]
        public IActionResult DeleteForSelf(int id )
        {
            MessageModelAPI message = mapper.Map<MessageModelAPI>(service.GetById(id));
            message.deletedForSelf = true;
            service.Update(mapper.Map<MessageModelBL>(message));
            return Ok(message);
        }

        [HttpPut]
        public IActionResult Put([FromBody] MessageModelAPI value)
        {
            try
            {
                service.Update(mapper.Map<MessageModelBL>(value));
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