using Dapper;
using SysManageCRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace SysManageCRUD.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbConnection _bd;

        public AppointmentRepository(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB"));
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            var sql = "INSERT INTO appointment(Date,IdPatient,IdLocation,IdDoctor)" + "Values(@Date,@IdPatient,@IdLocation,@IdDoctor)";
            _bd.Execute(sql
                , new
                {
                    appointment.Date,
                    appointment.IdPatient,
                    appointment.IdLocation,
                    appointment.IdDoctor

                });

            return appointment;

        }

        public void DeleteAppointment(int id)
        {
            var sql = "DELETE FROM Appointment Where IdAppointment=@IdAppointment";
            _bd.Execute(sql, new {IdAppointment = id });
        }

        public Appointment GetAppointment(int id)
        {
            var sql = "SELECT * FROM appointment where IdAppointment=@IdAppointment";
            return _bd.Query<Appointment>(sql, new { IdAppointment = id }).Single(); 
        }


        public List<Appointment> GetAppointment()
        {
            var sql = @"SELECT  p.IdAppointment, Date, p.IdPatient,PatientName, p.IdLocation,HospitalName,p.IdDoctor,DoctorName
            FROM Appointment p
			INNER JOIN Location lt ON Lt.IdLocation = p.IdLocation
			INNER JOIN Doctor   dt ON Dt.IdDoctor = p.IdDoctor
			INNER JOIN Patient pt ON Pt.IdPatient = p.IdPatient
			ORDER BY p.IdAppointment DESC";

            var appointments = _bd.Query<Appointment, Patient, Location, Doctor, Appointment>(
                sql,
                (appointment, patient, location, doctor) =>
                {
                    appointment.Patient = patient;
                    appointment.Location = location;
                    appointment.Doctor = doctor;
                    return appointment;
                },
                splitOn: "IdPatient,IdLocation,IdDoctor"
            );

            return appointments.Distinct().ToList();
        }
        public Appointment UpdateAppointment(Appointment appointment)
        {
            var sql = "UPDATE Appointment SET Date=@Date,IdPatient=@IdPatient,IdLocation=@IdLocation,IdDoctor=@IdDoctor Where IdAppointment=@IdAppointment";
            _bd.Execute(sql, appointment);
            return appointment; 
        }
    }
}
