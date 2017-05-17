using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace BrownBag.SQLInjection.Cmd
{
    public class Program
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SqlInjection;Integrated Security=True";

        /// <summary>
        /// Entry Point for testing SQL Injection
        /// BrownBag.SQLInjection.Console.exe --name "' OR 1=1 --"
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args.Any(a => a == "--debug"))
            {
                Debugger.Launch();
            }

            string value = string.Empty;
            if (args.Any(a => a.Equals("--name")))
            {
                var index = Array.FindIndex(args, a => a.Contains("--name"));
                value = args[++index];

                // Validate the input
                if(args.Any(a => a.Equals("--replace")))
                {
                    value = value.Replace("'", "").Replace("`", "");
                }
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(args.Any(a => a.Equals("--parameter"))
                    ? $"select * from [DataEntry] where [Name] = @Name"
                    : $"select * from [DataEntry] where [Name] = '{value}'", connection);

                // Secure and Validate the input
                if (args.Any(a => a.Equals("--parameter")))
                {
                    command.Parameters.Add(new SqlParameter("@Name", value));
                }

                var dataAdapter = new SqlDataAdapter(command);
                var dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                Console.WriteLine(dataSet.GetXml());
            }
        }
    }
}
