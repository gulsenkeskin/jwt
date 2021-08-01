using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.API.DTOs;
using Proje.Core.Models;
using Proje.Core.Services;

namespace Proje.API.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]

    public class CariController:ControllerBase
    {

        private readonly IMapper _mapper;
        
        private readonly ICariService _cariService;

        public CariController(ICariService cariService, IMapper mapper)
        {
            _cariService = cariService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "CariGetAll")]
        public async Task<IActionResult> GetAll()
        {
            // throw new Exception("tüm dataları çekerken bir hata meydana geldi");
            var cariler = await _cariService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CariDto>>(cariler));

        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "CariId")]
        public async Task<IActionResult> GetById(int Id)
        {
            var cari = await _cariService.GetByIdAsync(Id);
            return Ok(_mapper.Map<CariDto>(cari));
        }

        [HttpPost]
        [Authorize(Roles = "CariPost")]
        public async Task<IActionResult> Save(CariDto cariDto)
        {
            var yenicari = await _cariService.AddAsync(_mapper.Map<Cari>(cariDto));

            return Created(string.Empty, _mapper.Map<CariDto>(yenicari));
        }

        [HttpPut]
        [Authorize(Roles = "CariUpdate")]
        public IActionResult Update(CariDto cariDto)
        {
            var cari = _cariService.Update(_mapper.Map<Cari>(cariDto));

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "CariDelete")]
        public IActionResult Remove(int Id)
        {
            var cari = _cariService.GetByIdAsync(Id).Result;
            _cariService.Remove(cari);
            return NoContent();
        }

        
    }
}