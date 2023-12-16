﻿using Dapper;
using SysManageCRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace SysManageCRUD.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnection _bd;

        public DoctorRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB")); 
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            var sql = "INSERT INTO doctor(Name,IdSpecialty)" +
                "VALUES(@Name,@IdSpeacialty)";

            _bd.Execute(sql, new
            {
                doctor.Name,
                doctor.IdSpecialty
            }); 

            return doctor;
        }
        public void DeleteDoctor(int id)
        {
            var sql = "DELETE FROM Doctor Where IdDoctor=@IdDoctor";
            _bd.Execute(sql, new {IdDoctor = id});
        }

        public Doctor GetDoctor(int id)
        {
            var sql = "SELECT * FROM doctor Where IdDoctor=@IdDoctor";
            return _bd.Query<Doctor>(sql, new { IdDoctor= id }).Single(); 
        }

        public List<Doctor> GetDoctor()
        {
            var sql = "SELECT * FROM Doctor";
            return _bd.Query<Doctor>(sql).ToList();

        }

        public List<Doctor> GetSpecialtyDoctor()
        {
            var sql = "SELECT a.*, c.SpecialtyName FROM Doctor a INNER JOIN Specialty c " +
          "ON a.IdSpecialty=c.IdSpecialty ORDER BY IdDoctor DESC";

            var doctor = _bd.Query<Doctor, Specialty, Doctor>(sql, (a, c) =>
            {
                a.Specialty = c;
                return a;
            }, splitOn: "IdSpecialty");

            return doctor.Distinct().ToList();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var sql = "UPDATE Doctor SET Name=@Name,  IdSpecialty=@IdSpecialty Where IdDoctor=@IdDoctor";
            _bd.Execute(sql, doctor);
            return doctor;
        }
    }
}