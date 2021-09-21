using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context; //Readonly = previnir que essa dependência não possa ser alterada

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        /* OPERAÇÃO SINCRONA!
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();//Retorna os departamentos ordenados por nome.
        }*/

        //OPERAÇÃO ASSINCRONA!
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();//Retorna os departamentos ordenados por nome.
        }
    }
}
