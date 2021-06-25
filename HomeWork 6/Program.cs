using System;
using System.Diagnostics;

namespace HomeWork_6
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");     // выводим id и имя процесса
            }

            Console.WriteLine("Введите номер ID или имя процесса, который Вы хотите завершить:");

            string processForClosing = Console.ReadLine();
            Process myProcess = null;

            foreach (Process process in Process.GetProcesses())
            {
                while (myProcess == null)
                {
                    myProcess = matchingProcess(process, processForClosing);
                    break;
                }
            }

            ClosingProcesses(myProcess);
        }

        public static void ClosingProcesses (Process process)
        {
            process.Kill();
            Console.WriteLine($"Процесс {process.ProcessName} завершен.");
        }

        public static Process matchingProcess (Process process, string processForClosing)
        { 
            Process myProcess = null;

            if (process.Id.ToString().Equals(processForClosing))
            {
                myProcess = process;
            }
        
            else if (process.ProcessName.Equals(processForClosing))
            {
                myProcess = process;
            }
            
            return myProcess;
        }
    }
}
