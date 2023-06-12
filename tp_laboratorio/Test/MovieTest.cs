using Xunit;
using tp_laboratorio.Models;

public class MovieTests
{
    [Fact]
    public void TestMovieName()
    {
        var movie = new Movie { MovieName = "Toy Story 3" };
        Assert.Equal("Toy Story 3", movie.MovieName);
    }

    [Fact]
    public void TestMovieGenre()
    {
        var movie = new Movie { MovieGenre = "Kids" };
        Assert.Equal("Kids", movie.MovieGenre);
    }

    [Fact]
    public void TestActorName()
    {
        var movie = new Actor { ActorName = "Woody" };
        Assert.Equal("Woody", movie.ActorName);
    }
}

