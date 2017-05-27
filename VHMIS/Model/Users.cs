﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Users
    {
        private string id;
        private string idNo;
        private string contact;
        private string contact2;
        private string surname;
        private string lastname;       
        private string email;      
        private string nationality;
        private string address;
        private string kin;
        private string kincontact;
        private string passwords;       
        private string designation;
        private string roles;
        private string gender;
        private string image;
        private string clinicID;
        private string clinicDesignation;
        private string initialPassword;
        private string account;
        private string status;
        private string practice;
        private string specialisation;
        private string sub;
        private string created;
        private string department;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string IdNo
        {
            get
            {
                return idNo;
            }

            set
            {
                idNo = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public string Contact2
        {
            get
            {
                return contact2;
            }

            set
            {
                contact2 = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Nationality
        {
            get
            {
                return nationality;
            }

            set
            {
                nationality = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Kin
        {
            get
            {
                return kin;
            }

            set
            {
                kin = value;
            }
        }

        public string Kincontact
        {
            get
            {
                return kincontact;
            }

            set
            {
                kincontact = value;
            }
        }

        public string Passwords
        {
            get
            {
                return passwords;
            }

            set
            {
                passwords = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }

        public string Roles
        {
            get
            {
                return roles;
            }

            set
            {
                roles = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string ClinicID
        {
            get
            {
                return clinicID;
            }

            set
            {
                clinicID = value;
            }
        }

        public string ClinicDesignation
        {
            get
            {
                return clinicDesignation;
            }

            set
            {
                clinicDesignation = value;
            }
        }

        public string InitialPassword
        {
            get
            {
                return initialPassword;
            }

            set
            {
                initialPassword = value;
            }
        }

        public string Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Practice
        {
            get
            {
                return practice;
            }

            set
            {
                practice = value;
            }
        }

        public string Specialisation
        {
            get
            {
                return specialisation;
            }

            set
            {
                specialisation = value;
            }
        }

        public string Sub
        {
            get
            {
                return sub;
            }

            set
            {
                sub = value;
            }
        }

        public string Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public Users(string id, string idNo, string contact, string contact2, string surname, string lastname,string email, string nationality, string address, string kin, string kincontact, string passwords, string designation, string roles, string gender, string image, string clinicID, string clinicDesignation, string initialPassword, string account, string status, string practice, string specialisation, string sub, string created,string department)
        {
            this.Id = id;
            this.IdNo = idNo;
            this.Contact = contact;
            this.Contact2 = contact2;
            this.Surname = surname;
            this.Lastname = lastname;
           
            this.Email = email;
            this.Nationality = nationality;
            this.Address = address;
            this.Kin = kin;
            this.Kincontact = kincontact;
            this.Passwords = passwords;
            this.Designation = designation;
            this.Roles = roles;
            this.Gender = gender;
            this.Image = image;
            this.ClinicID = clinicID;
            this.ClinicDesignation = clinicDesignation;
            this.InitialPassword = initialPassword;
            this.Account = account;
            this.Status = status;
            this.Practice = practice;
            this.Specialisation = specialisation;
            this.Sub = sub;
            this.Created = created;
            this.Department = department;
        }

        public static List<Users> ListUsers()
        {           
            DBConnect.OpenConn();
            List<Users> users = new List<Users>();
            string SQL = "SELECT * FROM users";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                string images=null;
            
                    if (!Reader.IsDBNull(11))
                    {
                        images = Reader["image"].ToString();                       
                    }
                    else
                    {
                        images = null;
                    }           
                    Users p = new Users(Reader["id"].ToString(), Reader["idno"].ToString(), Reader["contact"].ToString(), Reader["contact2"].ToString(), Reader["surname"].ToString(), Reader["lastname"].ToString(), Reader["email"].ToString(), Reader["nationality"].ToString(), Reader["address"].ToString(), Reader["kin"].ToString(), Reader["kincontact"].ToString(), Reader["passwords"].ToString(), Reader["designation"].ToString(), Reader["roles"].ToString(), Reader["gender"].ToString(), images, Reader["clinicID"].ToString(), Reader["clinicDesignation"].ToString(), Reader["initialPassword"].ToString(), Reader["account"].ToString(), Reader["status"].ToString(), Reader["practice"].ToString(), Reader["specialisation"].ToString(), Reader["sub"].ToString(), Reader["created"].ToString(),Reader["department"].ToString());
                    users.Add(p);                

            }
            DBConnect.CloseConn();

            return users;
           
        }
    }
}