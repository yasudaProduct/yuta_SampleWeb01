using Microsoft.AspNetCore.Mvc.Rendering;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.ViewModels
{
    public class MovieGenreViewModel
    {
        public List<Movie>? Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
