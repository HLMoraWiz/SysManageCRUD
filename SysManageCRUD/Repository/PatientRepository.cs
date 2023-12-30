using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var sql = "INSERT INTO Patient(PatientName,LastName,IdCard,Age,Description)Values(@PatientName,@LastName,@IdCard,@Age,@Description)";
            _bd.Execute(sql, new
            {
                patient.PatientName,
                patient.IdCard,
                patient.LastName,
                patient.Age,
                patient.Description

            });

            return patient; 
        }

        public void DeletePatient(int id)
        {
            var sql = "DELETE FROM Patient where IdPatient=@IdPatient";
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
            var sql = "UPDATE Patient SET PatientName =@PatientName, LastName=@LastName,IdCard=@IdCard,Age=@Age,Description=@Description Where IdPatient=@IdPatient";
            _bd.Execute(sql, patient);
            return patient; 
        }


        public IEnumerable<SelectListItem> GetSelectListPatient()
        {
            var sql = "SELECT * FROM patient";
            var lista = _bd.Query<Patient>(sql).ToList();
            SelectList listPatient = new SelectList(lista, "IdPatient", "PatientName");

            return listPatient;
        }

        public bool PatientExists(string idCard)
        {
            var sql = "SELECT COUNT(*) FROM Patient WHERE IdCard = @IdCard";
            var count = _bd.QueryFirstOrDefault<int>(sql, new { IdCard = idCard });
            return count > 0;
        }

        public bool PatientyHasAppointment(int id)
        {
           
                var sql = "SELECT COUNT(*) FROM Appointment WHERE IdPatient = @IdPatient";
                var count = _bd.QueryFirstOrDefault<int>(sql, new { IdPatient = id });
                return count > 0;
            
        }
    }
}
