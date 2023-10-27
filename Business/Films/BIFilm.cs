using Models.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Films
{
    public interface BIFilm
    {
        Task<IEnumerable<Film>> GetAll();
        Task<Film> Create(Film film);
        Task<Film> Update(Film film);
        Task<bool> Delete(int filmId);
    }
}
