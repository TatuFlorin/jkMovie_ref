﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface IMovieRepository : IBaseRepository<jkMovie.Domain.Entities.Movie>
    {
    }
}
