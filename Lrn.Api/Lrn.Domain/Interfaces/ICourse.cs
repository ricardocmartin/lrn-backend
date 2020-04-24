using System;

namespace Lrn.Domain.Interfaces
{
    public interface ICourse
    {
        DateTime Created { get; set; }
        string Description { get; set; }
        string Idiom { get; set; }
        DateTime Modificated { get; set; }
        string Name { get; set; }
        string Thumbnail { get; set; }
    }
}