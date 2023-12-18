using System.Diagnostics; // Подключаем необходимые пространства имен

internal class Program
{
    private static void Main(string[] args)  // Главная точка входа в программу
    {
        AllInfoProcess(); // Вызываем метод, который выводит информацию о процессах

        static void AllInfoProcess()
        {
            var myProcess = from proc in Process.GetProcesses(".")    // Получаем все запущенные процессы, сортируем по идентификатору
                            orderby proc.Id
                            select proc;
            Console.WriteLine("\n*** Текущие процессы ***\n");  // Выводим заголовок
            int flag = 0;
            foreach (var p in myProcess)
            {
                if (flag < 3) // Выводим информацию только для первых 3-х процессов
                    Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                flag++;
            }

            Console.WriteLine("-----------------------------------------------");

            foreach (var p in myProcess) // Выводим информацию о всех процессах
                Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
        }
    }
}
