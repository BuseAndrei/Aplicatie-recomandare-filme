using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie_recomandare_filme
{
    public class MovieViewModel
    {
        public ApiHandler apiHandler = new ApiHandler();

        public Movie CurrentMovie { get; set; }
        public Movie Movie { get; private set; }

        public async void LoadMovie(int id)
        {
            CurrentMovie = await apiHandler.GetMovie(id);
            // aici ar putea fi și logica de actualizare a interfeței utilizator
        }

        public async Task GetMovie(int id)
        {
            Movie = await apiHandler.GetMovie(id);
        }

    }
}
