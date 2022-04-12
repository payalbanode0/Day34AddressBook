using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    internal class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=Address_Book;Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetDetails()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM Address_Book_Table";

                    //Define Sql Command Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressBookModel.FirstName = dr.GetString(0);
                            addressBookModel.LastName = dr.GetString(1);
                            addressBookModel._address = dr.GetString(2);
                            addressBookModel.City = dr.GetString(3);
                            addressBookModel._State = dr.GetString(4);
                            addressBookModel.Zip = dr.GetInt32(5);
                            addressBookModel.PhoneNumber = dr.GetString(6);
                            addressBookModel.email = dr.GetString(7);
                            addressBookModel.RelationType = dr.GetString(8);


                            //display retieved record

                            Console.WriteLine("FirstName : " + "{0}" + ", Last Name : " + "{1}" + ", Address : " + "{2}" + ", City : " + "{3}" + ", State" + "{4}" + ", Zip : " + "{5}" + ", PhoneNumber : " + "{6}" + ", Email : " + "{7}" + ", Relation Type : " + "{8}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel._address, addressBookModel.City, addressBookModel._State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.email, addressBookModel.RelationType);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    //Close Data Reader
                    dr.Close();
                    this.connection.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //UC 17
        public void Update(AddressBookModel addressBookModel)
        {
            string query = @"Update Address_Book_Table Set RelationType ='Me' Where FirstName='Manoj'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AddressBookModel addressBook = new AddressBookModel();
            Console.WriteLine("Update Successfull");

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    addressBook.FirstName = dr.GetString(0);
                    addressBook.RelationType = dr.GetString(8);
                    //display 

                    Console.WriteLine("FirstName : " + "{0}" + "Relation Type : " + "{8}", addressBookModel.FirstName, addressBookModel.RelationType);


                }
            }
            dr.Close();
            this.connection.Close();
        }
        //UC 18 - Alter 
        public void Alter(AddressBookModel model)
        {
            string query = @"Alter Table Address_Book_Table Add StartDate datetime default GetDate() Not Null";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Alter Successfull Added StartDate Column");
            dr.Close();
            this.connection.Close();

        }
        //UC 18 Get Date
        public void GetDateRange(AddressBookModel model)
        {
            string query = @"Select * From Address_Book_Table Where StartDate Between '01-01-2000' And GetDate()";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AddressBookModel addressBookModel = new AddressBookModel();
            Console.WriteLine("Records in Data Range\n");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    addressBookModel.FirstName = dr.GetString(0);
                    addressBookModel.LastName = dr.GetString(1);
                    addressBookModel._address = dr.GetString(2);
                    addressBookModel.City = dr.GetString(3);
                    addressBookModel._State = dr.GetString(4);
                    addressBookModel.Zip = dr.GetInt32(5);
                    addressBookModel.PhoneNumber = dr.GetString(6);
                    addressBookModel.email = dr.GetString(7);
                    addressBookModel.RelationType = dr.GetString(8);
                    addressBookModel.StartDate = dr.GetDateTime(9);

                    Console.WriteLine("FirstName : " + "{0}" + ", Last Name : " + "{1}" + ", Address : " + "{2}" + ", City : " + "{3}" + ", State" + "{4}" + ", Zip : " + "{5}" + ", PhoneNumber : " + "{6}" + ", Email : " + "{7}" + ", Relation Type : " + "{8}" + ", Start Date : " + "{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel._address, addressBookModel.City, addressBookModel._State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.email, addressBookModel.RelationType, addressBookModel.StartDate);

                }
            }
            dr.Close();
            this.connection.Close();
        }

        //UC19
        public void Count(AddressBookModel model)
        {
            string query = @"Select Count(City) From Address_Book_Table Where City='Kazipet'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int count = dr.GetInt32(0);
                    Console.WriteLine("Count of City Kazipet : " + "{0}", count);
                }
            }
            Console.WriteLine("Alter Successfull Added StartDate Column");
            dr.Close();
            this.connection.Close();

        }

    }

}
    
    


   

    



