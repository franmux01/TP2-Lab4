using Xunit;
using tp_laboratorio.Models;

public class MovieTests
{
    [Fact]
    public void TestMovieName()
    {
        var movie = new Movie { MovieName = "Example Movie" };
        Assert.Equal("Example Movie", movie.MovieName);
    }

    [Fact]
    public void TestMovieGenre()
    {
        var movie = new Movie { MovieGenre = "Example Genre" };
        Assert.Equal("Example Genre", movie.MovieGenre);
    }

    [Fact]
    public void TestActorName()
    {
        var movie = new Actor { ActorName = "Example Actor" };
        Assert.Equal("Example Actor", movie.ActorName);
    }
}

