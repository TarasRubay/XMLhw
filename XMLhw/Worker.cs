using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLhw
{
    public enum Appointment {Director, Manager, Cliner };
    class Worker
    {
        public string ID { get; private set; }
        public string Name { get; private set; } = "";
        public string Surname { get; private set; } = "";
        public string PhoneNumber { get; set; } = "";
        public Appointment Appointment { get; set; }
        public Worker(string name, string surname, string phoneNumber, Appointment appointment)
        {
            ID = surname.GetHashCode().ToString();
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Appointment = appointment;
        }
        public Worker(string id, string name, string surname, string phoneNumber, Appointment appointment)
        {
           
            ID = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Appointment = appointment;
        }
        public override string ToString()
        {
            return $"\nID: {ID}\nName: {Name}\nSurname: {Surname}\nPhone number: {PhoneNumber}\nAppointment: {Appointment}";
        }


    }
}
