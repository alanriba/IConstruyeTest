using System;
using Microsoft.EntityFrameworkCore;

namespace IConstruye.Dac.Helpers.Interfaces
{
    public interface IInitialize
    {
         
            void Initialize(ModelBuilder modelBuilder);
      
    }
}

