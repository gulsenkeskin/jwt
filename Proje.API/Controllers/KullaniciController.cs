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
    
    public class KullaniciController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService, IMapper mapper)
        {
            _kullaniciService = kullaniciService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "KullaniciGetAll")]
        public async Task<IActionResult> GetAll()
        {
            // throw new Exception("tüm dataları çekerken bir hata meydana geldi");
            var kullanicilar = await _kullaniciService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<KullaniciDto>>(kullanicilar));

        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "KullaniciGetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(Id);
            return Ok(_mapper.Map<KullaniciDto>(kullanici));
        }

        // [HttpPost]
        // public async Task<IActionResult> Save(KullaniciDto kullaniciDto)
        // {
        //     var yenikullanici = await _kullaniciService.AddAsync(_mapper.Map<Kullanici>(kullaniciDto));

        //     return Created(string.Empty, _mapper.Map<KullaniciDto>(yenikullanici));
        // }

        [HttpPut]
        [Authorize(Roles = "KullaniciUpdate")]
        public IActionResult Update(KullaniciDto kullaniciDto)
        {
            var kullanici = _kullaniciService.Update(_mapper.Map<Kullanici>(kullaniciDto));

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "KullaniciDelete")]
        public IActionResult Remove(Guid Id)
        {
            var kullanici = _kullaniciService.GetByIdAsync(Id).Result;
            _kullaniciService.Remove(kullanici);
            return NoContent();
        }
    }
}
