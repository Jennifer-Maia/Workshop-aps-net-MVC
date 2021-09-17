using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context; //Readonly = previnir que essa dependência não possa ser alterada

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();//Retorna os departamentos ordenados por nome.
        }
    }
}
