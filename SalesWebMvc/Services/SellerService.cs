using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context; //Readonly = previnir que essa dependência não possa ser alterada

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();//Acessa a fonte de dados relacionado a tabela de vendedores e converte p/ minha lista
        }
        public void Insert (Seller obj)//Método = Insere um novo vendedor(obj) no banco de dados
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById (int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove (int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
