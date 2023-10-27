using Microsoft.EntityFrameworkCore;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Films
{
    public class DFilm : DIFilm
    {
        readonly ContextDBMaster DB;
        public DFilm(ContextDBMaster db)
        {
            DB = db;
        }
        public Task<Film> Create(Film film)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int filmId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await DB.Films.ToListAsync();
        }

        public Task<Film> Update(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
