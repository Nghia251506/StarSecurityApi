using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;


namespace StarSecurityApi.Service
{
    public class GradeService : IGradeService
    {
        private readonly AppDbContext _context; //Declaration

        public GradeService(AppDbContext context) //Contructor
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetAllSync() 
        {
            return await _context.Grades.ToListAsync(); //ToListAsync() to perform asynchronous queries (without blocking the thread).
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await _context.Grades.FirstOrDefaultAsync(e => e.Id == id); //Get the first record whose Id matches the passed id.
        }

        public async Task<GradeReadDto> CreateAsync(GradeCreateDto dto) //GradeCreateDto (contains only the information needed from the client).
        {
            var grade = new Grade //Create a new Grade object.
            {
                Name = dto.Name,
                Level = dto.Level,
                Description = dto.Description
            };

            _context.Grades.Add(grade); //Call _context.Grades.Add() to add to DbSet.
            await _context.SaveChangesAsync(); //SaveChangesAsync() to save to Database.

            return new GradeReadDto //Return GradeReadDto to send back to the client (do not return the original model to avoid exposing unnecessary data).
            {
                Id = grade.Id,
                Name = grade.Name,
                Level = grade.Level,
                Description = grade.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, Grade grade)
        {
            var existing = await _context.Grades.FindAsync(id);
            if (existing == null) return false;

            existing.Name = grade.Name;
            existing.Level = grade.Level;
            existing.Description = grade.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _context.Grades.FindAsync(id);
            if (emp == null) return false;

            _context.Grades.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}




























