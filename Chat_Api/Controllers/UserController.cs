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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly Mapper mapper;

        public UserController(IUserService _service)
        {
            service = _service;
            mapper = new Mapper(AutoMapper_API.GetMapperConfiguration());
        }
        [HttpGet]
        public IActionResult Get() =>
            Ok(mapper.Map<IEnumerable<UserModelAPI>>(service.GetAll()));

        [HttpGet("{id}")]
        public IActionResult Get(int id) =>
            Ok(mapper.Map<UserModelAPI>(service.GetById(id)));



        [HttpPost]
        public IActionResult Post([FromBody] UserModelAPI value)
        {
            try
            {
                service.Create(mapper.Map<UserModelBL>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserModelAPI value)
        {
            try
            {
                service.Update(mapper.Map<UserModelBL>(value));
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