﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class PojectsController : ControllerBase
    {
        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //api/project/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200) 
            { 
                return BadRequest(); 
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}