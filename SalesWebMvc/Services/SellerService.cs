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

        public async Task<List<Seller>> FindAllAsync() //Assincrono
        {
            return await _context.Seller.ToListAsync();//Acessa a fonte de dados relacionado a tabela de vendedores e converte p/ minha lista
        }
        /*
        public void Insert(Seller obj)//Método = Insere um novo vendedor(obj) no banco de dados
        {
            _context.Add(obj);
            _context.SaveChanges();
        }*/
        //Assincrono
        public async Task InsertAsync(Seller obj)//Método = Insere um novo vendedor(obj) no banco de dados
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); //Coloco as referencias async e await em quem realmente acessa o banco de dados!
        }

        public async Task <Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            //Faz o join da tabela (pegue também tal items (nesse caso o departamento) tenho que colocar o using.Microsoft.EntityFrameworkCore;
            //Parâmetro antes do FirstOrDefault();
        }
        public async Task RemoveAsync (int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller obj)
        {
            //if (!_context.Seller.Any(x => x.Id == obj.Id))//Teste se não(!) tem um vendedor com o Id 
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id); //Assincrono/ hasAny = tem algum?
            if(!hasAny)
            {                  
                throw new NotFoundException("Id not found"); //Lanço uma exeção
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }


        }
    }
}
