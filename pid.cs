using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        AllInfoProcess();

        static void AllInfoProcess()
        {
            var myProcess = from proc in Process.GetProcesses(".")
                            orderby proc.Id
                            select proc;
            Console.WriteLine("\n*** Текущие процессы ***\n");
            int flag = 0;
            foreach (var p in myProcess)
            {
                if (flag < 3)
                    Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                flag++;
            }

            Console.WriteLine("-----------------------------------------------");

            foreach (var p in myProcess)
                Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
        }
    }
}
