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
}

