using Dapper;
using SysManageCRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace SysManageCRUD.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _bd;
        public PatientRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB")); 
        }
        public Patient CreatePatient(Patient patient)
        {
            var sql = "INSERT INTO Patient(Name,LastName,Age,Description)Values(@Name,@LastName,@Age,@Description)";
            _bd.Execute(sql, new
            {
                patient.Name,
                patient.LastName,
                patient.Age,
                patient.Description

            });

            return patient; 
        }

        public void DeletePatient(int id)
        {
            var sql = "DELETE * FROM Patient where IdPatient=@IdPatient";
            _bd.Execute(sql, new { idPatient = id }); 
        }

        public Patient GetPatient(int id)
        {
            var sql = "SELECT * FROM Patient where IdPatient=@IdPatient"; 
            return _bd.Query<Patient>(sql, new { IdPatient = id }).Single();
        }

        public List<Patient> GetPatients()
        {
            var sql = "SELECT * FROM Patient"; 
            return _bd­.Query<Patient>(sql).ToList();    
        }

        public Patient UpdatePatient(Patient patient)
        {
            var sql = "UPDATE Patient SET Name = @Name, LastName=@LastName,Age=@Age,Description=@Description Where IdPatient=@IdPatient";
            _bd.Execute(sql, patient);
            return patient; 
        }
    }
}
