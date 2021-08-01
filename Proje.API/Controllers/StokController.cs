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
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Data;
using System.Text;

namespace Proje.API.Controllers
{
    [Authorize] 
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StokController:ControllerBase
    {
        private readonly IMapper _mapper;
        
        private readonly IStokService _stokService;

        public StokController(IStokService stokService, IMapper mapper)
        {
            _stokService = stokService;
            _mapper = mapper;
          
        }

        [HttpGet]
        [Authorize(Roles = "StokGetAll")]
        public async Task<IActionResult> GetAll()
        {      
            var stoklar = await _stokService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{baslangic}")]
        [Authorize(Roles = "StokGetBaslangic")]
        public async Task<IActionResult> Start(string baslangic)
        {    
          var stoklar = await _stokService.Where(s => s.stok_kod.StartsWith(baslangic));   
          return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{bitis}")]
        [Authorize(Roles = "StokGetBitis")]
        public async Task<IActionResult> End(string bitis)
        {    
          var stoklar = await _stokService.Where(s => s.stok_kod.EndsWith(bitis));   
          return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{iceren}")]
        [Authorize(Roles = "StokGetIceren")]
        public async Task<IActionResult> Contains(string iceren)
        {    
          var stoklar = await _stokService.Where(s => s.stok_kod.Contains(iceren));   
          return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{stokKod}")]
        [Authorize(Roles = "StokGetKod")]
        public async Task<IActionResult> StokKod(string stokKod)
        {    
          var stoklar = await _stokService.Where(s => s.stok_kod.Equals(stokKod));   
          return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{baslangic}/{bitis}")]
        [Authorize(Roles = "StokGetArasinda")]
        public async Task<IActionResult> Arasinda(string baslangic,string bitis)
        {    
          var stoklar = await _stokService.Where(s => s.stok_kod.StartsWith(baslangic)&& s.stok_kod.EndsWith(bitis));   
          return Ok(_mapper.Map<IEnumerable<StokDto>>(stoklar));
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "StokGetId")]

        public async Task<IActionResult> GetById(int Id)
        {
            var stok = await _stokService.GetByIdAsync(Id);
            return Ok(_mapper.Map<StokDto>(stok));
        }

        [HttpPost]
        [Authorize(Roles = "StokPost")]
        public async Task<IActionResult> Save(StokDto stokDto)
        {
            var yenistok = await _stokService.AddAsync(_mapper.Map<Stok>(stokDto));

            return Created(string.Empty, _mapper.Map<StokDto>(yenistok));
        }

        [HttpPut]
        [Authorize(Roles = "StokPut")]
        public IActionResult Update(StokDto stokDto)
        {
            var stok = _stokService.Update(_mapper.Map<Stok>(stokDto));

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "StokDelete")]
        public IActionResult Remove(int Id)
        {
            var stok = _stokService.GetByIdAsync(Id).Result;
            _stokService.Remove(stok);
            return NoContent();
        }        
    }
}