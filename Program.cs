using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPersons = new List<Person>();

            string conectionString = "Data Source=DESKTOP-5E70RM2;Initial Catalog=TestDb;Integrated Security=True;Pooling=False";
            NewMethod(listOfPersons, conectionString);

            //foreach (Person item in listOfPersons)
            //{
            //    item.printToConsole();
            //}

            //Console.ReadLine();

            AddPersonToTable(conectionString);
          


        }

        public static void NewMethod(List<Person> listOfPersons, string conectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Person";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader DataFromDb = command.ExecuteReader();
                    if (DataFromDb.HasRows)
                    {
                        while (DataFromDb.Read())
                        {
                            listOfPersons.Add(new Person(DataFromDb.GetString(0), DataFromDb.GetString(1), DataFromDb.GetInt32(2), DataFromDb.GetString(3)));

                        }
                    }

                    else
                    {
                        Console.WriteLine("no rows in table");
                    }



                    connection.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }

      static void AddPersonToTable(string conectionString)
        {
            Console.WriteLine("Enter first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter age ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter birthday");
            string date = Console.ReadLine(); ;
            try
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Person(fname,lname,age,birthday) 
                                    VALUES ('{fname}','{lname}',{age},'{date}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowEffected);
                   


                    connection.Close();
                }

            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {
                Console.WriteLine("error");
            }
        }


      
    }
}
