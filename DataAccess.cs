using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ContactManagement
{
    public class DataAccess
    {
        public async static Task<int> CreateContact(string name,string phoneno,string address,string group)
        {

            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("contactDB")))
            {
                {
                    var output = 0;
                    try
                    {
                        List<Contact> contact = new List<Contact>();

                        contact.Add(new Contact { Contact_name = name, Phoneno = phoneno, Contact_address = address, Contact_group = group });

                        output = await Task.Run(() => connection.ExecuteAsync("[dbo].[InsertContact]  @Contact_name,@Phoneno,@Contact_address,@Contact_group", contact));
                    }
                    catch (SqlException sp)
                    {
                        Console.WriteLine(sp.Message);
                        throw sp;
                    }
                    return output;
                }
            }
        }

        public async static Task<List<Contact>> FetchContacts()
        {

            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("contactDB")))
            {
                {
                    List<Contact>contacts = new List<Contact>();

                    try
                    {
                        contacts = await Task.Run(() => connection.Query<Contact>("[dbo].[FetchContacts]").ToList());
                    }
                    catch (SqlException sp)
                    {
                        Console.WriteLine(sp.Message);
                        throw sp;
                    }
                    return contacts;
                }
            }
        }

        public async static Task<Contact> FetchContact(int id)
        {

            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("contactDB")))
            {
                {
                    Contact contact = new Contact();

                    try
                    {
                        contact = await Task.Run(() => connection.QuerySingleOrDefault<Contact>("[dbo].[FetchContact] @Id",new {Id  = id}));
                    }
                    catch (SqlException sp)
                    {
                        Console.WriteLine(sp.Message);
                        throw sp;
                    }
                    return contact;
                }
            }
        }

        public async static Task<int> UpdateContact(string name,string address,string phno,int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("contactDB")))
            {
  
                try
                {
                   return await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_UpdateContact] @Contact_name,@Phoneno,@Contact_address ,@Id", new { Contact_name =name, Phoneno = phno, Contact_address =address, Id =id }));
                }
                catch (SqlException sp)
                {
                    throw sp;
                }
            }
        }

        public async static Task<int> DeleteContact(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConnectionVal("contactDB")))
            {

                try
                {
                    return await Task.Run(() => connection.ExecuteAsync("[dbo].[STP_DeleteContact]  ,@Id", new { Id = id }));
                }
                catch (SqlException sp)
                {
                    throw sp;
                }
            }
        }
    }
}
