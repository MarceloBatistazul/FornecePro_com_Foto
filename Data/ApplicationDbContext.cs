using FornecePro_Com_Foto.Models;
using Microsoft.EntityFrameworkCore;

namespace FornecePro_Com_Foto.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }

        public DbSet<CadastroModels> Cadastros { get; set; }
    }
}
