using System;
using System.Collections.Generic;

namespace tp_laboratorio.Models;

public partial class Actor
{
    public int Id { get; set; }

    public string ActorName { get; set; } = null!;

    public DateOnly ActorBirthdate { get; set; }

    public int? ActorPicture { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
