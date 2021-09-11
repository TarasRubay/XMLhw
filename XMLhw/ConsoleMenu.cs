using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLhw
{
    public class ConsoleMenu
    {
        public static long GenereteID { get; set; } = 0;
        public ConsoleMenu(string Path, string ns)
        {
            menu = 100;
            max_menu = 10;
            switch_on = menu;
            path = Path;
            Namespace = ns;
        }
        int menu { get; }
        int max_menu { get; }
        int switch_on { get; set; }

        string path { get; } = "";
        public string Namespace { get; } = "";
        List<Worker> workers { get; set; } = new List<Worker>();

        public void Start()
        {
            XMLdataManager manager = new XMLdataManager(path, Namespace);
            do
            {
                switch (switch_on)
                {
                    case 100:
                        do
                        {
                            try
                            {
                                Print();
                                switch_on = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception msg)
                            {
                                Console.WriteLine(msg.Message);
                                switch_on = menu;
                            }
                            Console.Clear();
                        } while (switch_on < 0 || switch_on > max_menu);

                        break;
                    case 1:
                        Console.WriteLine("Read data to *.xml file");
                        workers = manager.LoadData();
                        Console.WriteLine("Read data completed...");
                        switch_on = menu;
                        break;
                    case 2:
                        Console.WriteLine("View all worker");
                        if(workers.Count != 0)
                            foreach (var item in workers)
                            {
                                Console.WriteLine(item);
                            }
                        else Console.WriteLine("List workers is empty!");
                        switch_on = menu;
                        break;
                    case 3:
                        Console.WriteLine("Add worker");
                        AddWorker();
                        switch_on = menu;
                        break;
                    case 4:
                        Console.WriteLine("Find using");
                        switch_on = menu;
                        FindWorker();
                        switch_on = menu;
                        break;
                    case 5:
                        Console.WriteLine("Save data to *.xml file");
                        if (workers.Count() != 0)
                        {
                            manager.SaveData(workers);
                            Console.WriteLine("Data is saved...");
                        }
                        else Console.WriteLine("List is empty");
                        switch_on = menu;
                        break;
                    default:
                        break;
                }

            } while (switch_on != 0);

        }
        void Print()
        {
            Console.WriteLine();
            Console.WriteLine($"1 - Read XML from file: {path}");
            Console.WriteLine("2 - View all list workers");
            Console.WriteLine("3 - Add worker");
            Console.WriteLine("4 - Find worker");
            Console.WriteLine($"5 - Save XML from file: {path}");
            Console.WriteLine("0 - exit");
        }
        void PrintFindUsing()
        {
            Console.WriteLine("1 - Find worker using surname");
            Console.WriteLine("2 - Find worker using name");
            Console.WriteLine("3 - Find worker using ID");
            Console.WriteLine("0 - exit");
        }
        void PrintActionWorker()
        {
            Console.WriteLine("1 - Change phone number");
            Console.WriteLine("2 - Change appointment");
            Console.WriteLine("3 - Delete worker");
            Console.WriteLine("0 - exit");
        }
        void AddWorker() {
            string name = "", surename = "";
            bool check = false;
            do
            {
                        Console.WriteLine("Enter Name");
                try
                {
                    check = false;
                    name = Console.ReadLine();
                }
                catch (Exception msg)
                {
                    Console.Clear();
                    Console.WriteLine(msg.Message);
                    check = true;
                }
            } while (check);
            
            do
            {
                        Console.WriteLine("Enter Surname");
                try
                {
                    check = false;
                    surename = Console.ReadLine();
                }
                catch (Exception msg)
                {
                    Console.Clear();
                    Console.WriteLine(msg.Message);
                    check = true;
                }
            } while (check);

            workers.Add(new Worker(name,surename,SetPhoneNumber(), (Appointment)ChoiceAppointment()));
            Console.WriteLine("Worker is add...");
        }
        string SetPhoneNumber()
        {
            string phoneNumber = "";
            bool check = false;
            do
            {
                Console.WriteLine("Enter phone number Length 10");
                try
                {
                    check = false;
                    phoneNumber = Console.ReadLine();
                    if (phoneNumber.Length > 10 || phoneNumber.Length < 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Length 10");
                        check = true;
                    }
                }
                catch (Exception msg)
                {
                    Console.Clear();
                    Console.WriteLine(msg.Message);
                    check = true;
                }
            } while (check);
            return phoneNumber;
        }
        byte ChoiceAppointment()
        {
            Console.WriteLine("Choice appointment");
            foreach (Appointment item in Enum.GetValues(typeof(Appointment)))
            {
                Console.WriteLine($"{Convert.ToInt32(item)} - {item}");
            }
            byte appointm;
            do
            {
                appointm = Convert.ToByte(Console.ReadLine());
            } while (appointm > Enum.GetValues(typeof(Appointment)).Length || appointm < 0);
            return appointm;
        }
        void FindWorker()
        { 
            string find = "";
            IEnumerable<Worker> workerS;
            do
            {
                switch (switch_on)
                {
                    case 100:
                        do
                        {
                            try
                            {
                                PrintFindUsing();
                                switch_on = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception msg)
                            {
                                Console.WriteLine(msg.Message);
                                switch_on = menu;
                            }
                            Console.Clear();
                        } while (switch_on < 0 || switch_on > 3);

                        break;
                    case 1:
                        Console.WriteLine("Find worker using surname");
                        find = Console.ReadLine();
                        workerS = workers.FindAll(w => w.Surname.ToLower() == find.ToLower());
                        if (workerS.Count() != 0)
                        {
                            ChangeWorker(FindChanger(workerS));
                        }
                        else Console.WriteLine("Worker not found");
                        switch_on = menu;
                        break;
                    case 2:
                        Console.WriteLine("Find worker using name");
                        find = Console.ReadLine();
                        workerS = workers.FindAll(w => w.Name.ToLower() == find.ToLower());
                        if (workerS.Count() != 0)
                        {
                            ChangeWorker(FindChanger(workerS));
                        }
                        else Console.WriteLine("Worker not found");
                        switch_on = menu;
                        break;
                    case 3:
                        Console.WriteLine("Find worker using ID");
                        find = Console.ReadLine();
                        workerS = workers.FindAll(w => w.ID.ToLower() == find.ToLower());
                        if (workerS.Count() != 0)
                        {
                            ChangeWorker(FindChanger(workerS));
                        }
                        else Console.WriteLine("Worker not found");
                        switch_on = menu;
                        break;
                    default:
                        break;
                }

            } while (switch_on != 0);
          
        }
        void ChangeWorker(in Worker worker)
        {
            switch_on = menu;
            do
            {
                switch (switch_on)
                {
                    case 100:
                        do
                        {
                            try
                            {
                                PrintActionWorker();
                                switch_on = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception msg)
                            {
                                Console.WriteLine(msg.Message);
                                switch_on = menu;
                            }
                            Console.Clear();
                        } while (switch_on < 0 || switch_on > 3);

                        break;
                    case 1:
                        Console.WriteLine("Change phone number");
                        worker.PhoneNumber = SetPhoneNumber();
                        Console.WriteLine("phone number is change...");
                        switch_on = menu;
                        break;
                    case 2:
                        Console.WriteLine("Change appointment");
                        worker.Appointment = (Appointment)ChoiceAppointment();
                        Console.WriteLine("Appointment is change...");
                        switch_on = menu;
                        break;
                    case 3:
                        Console.WriteLine(" Delete worker");
                        workers.Remove(worker);
                        Console.WriteLine("This worker is removed...");
                        switch_on = 0;
                        break;
                    default:
                        break;
                }

            } while (switch_on != 0);
        }
        Worker FindChanger(IEnumerable<Worker> workers)
        {
            bool check = false;
           
                byte i = 0;
                foreach (Worker item in workers) Console.WriteLine($"{i++} <<<<<<<<<<<<\n{item}");

                do
                {
                    Console.WriteLine("Choice worker");
                    try
                    {
                        switch_on = Convert.ToInt32(Console.ReadLine());
                        if (switch_on > workers.Count() || switch_on < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("out of range");
                            check = true;
                        }
                    }
                    catch (Exception msg)
                    {
                        Console.Clear();
                        Console.WriteLine(msg.Message);
                        check = true;
                    }
                } while (check);
                return workers.ElementAt(switch_on);
            
        }
    }
}
