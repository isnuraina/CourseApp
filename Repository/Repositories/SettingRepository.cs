using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
   public class SettingRepository:BaseRepository<Setting>,ISettingRepository

    {
        public SettingRepository(AppDbContext context):base(context)
        {
            
        }
        public async Task<int> GetCountAsync()
        {
            return await _context.Settings.CountAsync();
        }
    }
}
