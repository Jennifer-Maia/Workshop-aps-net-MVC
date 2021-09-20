using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        public void Insert(Seller obj)//Método = Insere um novo vendedor(obj) no banco de dados
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
            //Faz o join da tabela (pegue também tal items (nesse caso o departamento) tenho que colocar o using.Microsoft.EntityFrameworkCore;
            //Parâmetro antes do FirstOrDefault();
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {                  //Teste se não(!) tem um vendedor com o Id 
                throw new NotFoundException("Id not found"); //Lanço uma exeção
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }


        }
    }
}
