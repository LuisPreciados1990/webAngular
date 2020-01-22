using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models.Formas.BAN;
using WebSystem.Models.Formas.CNT;
using WebSystem.Models.Formas.COB;
using WebSystem.Models.Formas.ELEC;
using WebSystem.Models.Formas.INV;
using WebSystem.Models.Formas.PAG;
using WebSystem.Models.main;
using WebSystem.Models.StoredProcedure;

namespace WebSystem.Models
{
    public class ApplicationDbContextRoot: DbContext
    {
        public ApplicationDbContextRoot(DbContextOptions<ApplicationDbContextRoot> options)
        : base(options) { }

        public DbSet<Usuario> USUARIOS { get; set; }    
    }
}
