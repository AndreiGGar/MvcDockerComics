using Microsoft.EntityFrameworkCore;
using MvcDockerComics.Context;
using MvcDockerComics.Models;

namespace MvcDockerComics.Repositories
{
    public class RepositoryComics
    {
        private DataContext context;

        public RepositoryComics(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            return await this.context.Comics.ToListAsync();
        }

        public async Task<Comic> FindComicAsync(int id)
        {
            return await this.context.Comics.FirstOrDefaultAsync(x => x.IdComic == id);
        }

        private async Task<int> GetMaxIdComicAsync()
        {
            return await this.context.Comics.MaxAsync(x => x.IdComic) + 1;
        }

        public async Task InsertComic(string nombre, string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = await this.GetMaxIdComicAsync();
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            this.context.Comics.Add(comic);
            await this.context.SaveChangesAsync();
        }
    }
}
