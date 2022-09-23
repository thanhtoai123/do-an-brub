﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;
using Rez.Models;

namespace Rez.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("/[area]/[controller]")]
    [ApiController]
    public class DiemDanh : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiemDanh(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DienDanh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.DiemDanh>>> GetDienDanh()
        {
            return await _context.DienDanh.ToListAsync();
        }

        // GET: api/DienDanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DiemDanh>> GetDienDanh(Guid id)
        {
            var dienDanh = await _context.DienDanh.FindAsync(id);

            if (dienDanh == null)
            {
                return NotFound();
            }

            return dienDanh;
        }

        // PUT: api/DienDanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDienDanh(Guid id, Models.DiemDanh dienDanh)
        {
            if (id != dienDanh.Id)
            {
                return BadRequest();
            }

            _context.Entry(dienDanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DienDanhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DienDanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.DiemDanh>> PostDienDanh(Models.DiemDanh dienDanh)
        {
            _context.DienDanh.Add(dienDanh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDienDanh", new { id = dienDanh.Id }, dienDanh);
        }

        // DELETE: api/DienDanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDienDanh(Guid id)
        {
            var dienDanh = await _context.DienDanh.FindAsync(id);
            if (dienDanh == null)
            {
                return NotFound();
            }

            _context.DienDanh.Remove(dienDanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DienDanhExists(Guid id)
        {
            return _context.DienDanh.Any(e => e.Id == id);
        }
    }
}
