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
            throw new NotImplementedException();
        }

        public Patient DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatients()
        {
            var sql = "SELECT * FROM Patient"; 
            return _bd­.Query<Patient>(sql).ToList();    
        }

        public Patient UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
