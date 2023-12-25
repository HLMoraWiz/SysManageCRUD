using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using SysManageCRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace SysManageCRUD.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly IDbConnection _bd;
        public SpecialtyRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB")); 
        }
        public Specialty CreateSpecialty(Specialty specialty)
        {
            var sql = "INSERT INTO Specialty(SpecialtyName)Values(@SpecialtyName)";
            _bd.Execute(sql, new
            {
                specialty.SpecialtyName
      
            });

            return specialty; 
        }
        public void DeleteSpecialty(int id)
        {
            var sql = "DELETE FROM Specialty where IdSpecialty=@IdSpecialty";
            _bd.Execute(sql, new { idSpecialty = id }); 
        }

        public Specialty GetSpecialty(int id)
        {
            var sql = "SELECT * FROM Specialty where IdSpecialty=@IdSpecialty"; 
            return _bd.Query<Specialty>(sql, new { IdSpecialty = id }).Single();
        }

        public List<Specialty> GetSpecialtyList()
        {
            var sql = "SELECT * FROM Specialty"; 
            return _bd­.Query<Specialty>(sql).ToList();    
        }

        public Specialty UpdateSpecialty(Specialty specialty)
        {
            var sql = "UPDATE Specialty SET SpecialtyName = @SpecialtyName  Where IdSpecialty=@IdSpecialty";
            _bd.Execute(sql, specialty);
            return specialty; 
        }

        //new.
        public IEnumerable<SelectListItem> GetSelectListSpecialty()
        {
            var sql = "SELECT * FROM specialty";
            var lista = _bd.Query<Specialty>(sql).ToList();
            SelectList listSpecialty = new SelectList(lista, "IdSpecialty", "SpecialtyName");

            return listSpecialty;
        }

        public bool SpecialtyExists(string specialtyName)
        {
            var sql = "SELECT COUNT(*) FROM Specialty WHERE SpecialtyName = @SpecialtyName";
            var count = _bd.QueryFirstOrDefault<int>(sql, new { SpecialtyName = specialtyName });
            return count > 0;
        }


    }
}
