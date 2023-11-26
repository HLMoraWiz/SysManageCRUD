using Dapper;
using SysManageCRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace SysManageCRUD.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDbConnection _bd;
        public LocationRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB")); 
        }
        public Location CreateLocation(Location location)
        {
            var sql = "INSERT INTO Location(HospitalName,Address)Values(@HospitalName,@Address)";
            _bd.Execute(sql, new
            {
                location.HospitalName,
                location.Address

            });

            return location; 
        }
        public void DeleteLocation(int id)
        {
            var sql = "DELETE FROM Location where IdLocation=@IdLocation";
            _bd.Execute(sql, new { idLocation = id }); 
        }

        public Location GetLocation(int id)
        {
            var sql = "SELECT * FROM Location where IdLocation=@IdLocation"; 
            return _bd.Query<Location>(sql, new { IdLocation = id }).Single();
        }

        public List<Location> GetLocations()
        {
            var sql = "SELECT * FROM Location"; 
            return _bd­.Query<Location>(sql).ToList();    
        }

        public Location UpdateLocation(Location location)
        {
            var sql = "UPDATE Location SET HospitalName = @HospitalName, Address=@Address  Where IdLocation=@IdLocation";
            _bd.Execute(sql, location);
            return location; 
        }
    }
}
