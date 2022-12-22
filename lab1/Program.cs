using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Library;Integrated Security=True";

        string queryString =
            "SELECT books.id, name, price, date_taken, readers.first_name, readers.last_name,  writers.first_name, writers.last_name " +
            "FROM books " +
            "INNER JOIN readers ON books.reader_id=readers.id " +
            "INNER JOIN writers ON books.writer_id=writers.id";


        using (SqlConnection connection =
            new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
