using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models {
    public class Seller {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)] //Coloca o link no email p/ já abrir meu app de email padrão
        public string Email { get; set; }
        [Display (Name = "Birth Date")] //Escolho como quero a escrita (antes estava junto agora defini com espaço)
        [DataType(DataType.Date)] //Coloco somente a data (posso definir outros formatos depois do .), antes estava com data e hr.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]//Altero a forma da data
        public DateTime BirthDate { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]//Coloca casas decimais no valor
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        //Lista de vendas associada ao meu vendedor.
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
            //LINQ = Filtrei para as datas coincidirem e somei sr com as vendas
        }
    }
}
