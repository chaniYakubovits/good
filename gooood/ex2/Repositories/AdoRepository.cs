using ex2.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ex2.Repositories
{

    public class AdoRepository : IAdoRepository
    {
        private readonly TasksContext _context;
        public IConfiguration _configuration;
        //string Cnn;
        public AdoRepository(TasksContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            //Cnn = configuration.GetConnectionString("DefaultConnection");
        }

        public bool ProcessTransaction(TaskAndAttechment taskAndAttechment)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //string connectionString = "ConnectionString";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a local transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachment (Name) VALUES (@Name)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@Name", taskAndAttechment.Attachment.Name);
                        //command2.Parameters.AddWithValue("@Id", taskAndAttechment.Attachment.Id);
                        command2.ExecuteNonQuery();
                    } 

                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Name,Priority,DueDate,Status,ProjectId,UserId) " +
                        "VALUES (@Name,@Priority,@DueDate,@Status,@ProjectId,@UserId)", connection, transaction))
                    {
                        //command1.Parameters.AddWithValue("@Id", taskAndAttechment.task.Id);
                        command1.Parameters.AddWithValue("@Name", taskAndAttechment.task.Name);
                        command1.Parameters.AddWithValue("@Priority", taskAndAttechment.task.Priority);
                        command1.Parameters.AddWithValue("@DueDate", taskAndAttechment.task.DueDate);
                        command1.Parameters.AddWithValue("@Status", taskAndAttechment.task.Status);
                        command1.Parameters.AddWithValue("@ProjectId", taskAndAttechment.task.ProjectId);
                        command1.Parameters.AddWithValue("@UserId", taskAndAttechment.task.UserId);
                        command1.Parameters.AddWithValue("@AttachmentsId", taskAndAttechment.Attachment.Id);
                        command1.ExecuteNonQuery();
                    }

                    

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch (Exception ex)  
                {
                    Console.WriteLine("Transaction failed: " + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                    }
                    return false;
                }
            }
        }


        //public DataTable getByProject(int ProjactId)
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(Cnn))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            //commandtype
        //            command.CommandText = "getByProject";
        //            command.CommandType = CommandType.StoredProcedure;

        //            //paramters
        //            SqlParameter sqlParameter = new SqlParameter("@ProjactId", ProjactId);

        //            command.Parameters.Add(sqlParameter);

        //            connection.Open();

        //            using (SqlDataAdapter da = new SqlDataAdapter(command))
        //            {
        //                da.Fill(dt);

        //            }
        //        }
        //    }
        //    return dt;
        //}

        //public DataTable addAttachment(Attachment attachment)
        //{

        //    DataTable dt = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(Cnn))
        //    {
        //        using (SqlCommand command = new SqlCommand("Attachments_AddAttachment", connection))
        //        {
        //            command.CommandText = "Attachments_AddAttachment";
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.AddWithValue("@Name", attachment.Name);

        //            int rowsAffact = command.ExecuteNonQuery();

        //            connection.Open();

        //            using (SqlDataAdapter da = new SqlDataAdapter(command))
        //            {
        //                da.Fill(dt);

        //            }
        //        }
        //    }
        //    return dt;
        //}

    }
}
