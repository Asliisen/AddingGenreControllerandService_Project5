using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model {get; set;}
        private readonly BookStoreDbContext _context;


        public CreateGenreCommand(BookStoreDbContext context, AutoMapper.IMapper _mapper, CreateGenreModel newGenre)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.Name == Model.Name);
            if(genre is not null)
            {
                throw new InvalidOperationException("already exist.");
            }

            genre = new Genre();
            genre.Name= Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
            
        }
    }

    public class CreateGenreModel
    {
        public string? Name {get; set;}
    }
}