using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EducationRepository:BaseRepository<Education>,IEducationRepository
    {
        public EducationRepository(AppDbContext context):base(context){}

        public async Task<int> GetCountAsync()
        {
            return await _context.Educations.CountAsync();
        }

        public async Task<IEnumerable<Education>> GetPaginatedDatasAsync(int page, int take = 3)
        {
            return await _context.Educations.Skip((page * take)-take).Take(take).ToListAsync();
        }
    }
}
