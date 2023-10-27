using Data.Films;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Films
{
    public class BFilm : BIFilm
    {
        readonly DIFilm Repo;
        public BFilm(DIFilm repo)
        {
            Repo = repo;
        }
        public async Task<Film> Create(Film film)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int filmId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await Repo.GetAll();
        }

        public Task<Film> Update(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
