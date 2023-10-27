using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Films
{
    public interface DIFilm
    {
        Task<IEnumerable<Film>> GetAll();
        Task<Film> Create(Film film);
        Task<Film> Update(Film film);
        Task<bool> Delete(int filmId);
    }
}
