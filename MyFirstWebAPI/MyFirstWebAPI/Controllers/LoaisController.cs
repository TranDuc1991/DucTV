﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Data;
using MyFirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private MyDbcontext _context;

        public LoaisController(MyDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiId(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
