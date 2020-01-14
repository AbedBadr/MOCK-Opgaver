using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RestMeasurementService.Model;

namespace RestMeasurementService.DBUtility
{
    public class ManageMeasurements
    {
        private const string ConnectionString = "Server=tcp:abedmeasurement.database.windows.net,1433;Initial Catalog=Abed-MeasurementDB;Persist Security Info=False;User ID=abed;Password=Hej12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private const string GET_ALL = "select * from Measurement";
        private const string GET_ONE = "select * from Measurement WHERE Id = @ID";

        public IEnumerable<Measurement> GetAll()
        {
            List<Measurement> measurements = new List<Measurement>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ALL, conn))
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Measurement measurement = ReadNextElement(reader);
                        measurements.Add(measurement);
                    }
                    reader.Close();
                }

                return measurements;
            }
        }

        protected Measurement ReadNextElement(SqlDataReader reader)
        {
            Measurement measurement = new Measurement();
            measurement.Id = reader.GetInt32(0);
            measurement.Pressure = reader.GetDouble(1);
            measurement.Humidity = reader.GetDouble(2);
            measurement.Temperature = reader.GetDouble(3);
            measurement.TimeStamp = reader.GetDateTime(4);
            return measurement;
        }

        public Measurement GetById(int id)
        {
            Measurement measurement = new Measurement();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ONE, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        measurement = ReadNextElement(reader);
                    }
                    reader.Close();
                }

                return measurement;
            }
        }

        public void Add(Measurement measurement)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Measurement values (@param1,@param2,@param3,@param4)";
                        cmd.Parameters.AddWithValue("@param1", measurement.Pressure);
                        cmd.Parameters.AddWithValue("@param2", measurement.Humidity);
                        cmd.Parameters.AddWithValue("@param3", measurement.Temperature);
                        cmd.Parameters.AddWithValue("@param4", measurement.TimeStamp);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "delete from Measurement WHERE id=@ID";
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
