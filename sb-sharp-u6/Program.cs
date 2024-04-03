namespace sb_sharp_u6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char key = '1';
            int lastRecord = 0;
            string source = "EmployeeList.txt";
            string[] userInputFields = 
            {
                "Ф.И.О.",
                "возраст",
                "рост",
                "дата рождения",
                "место рождения"
            };

            Console.WriteLine(
                "Программа \"Справочник\" успешно загружена." +
                "\nВыберите действие:" +
                "\n1. Вывести данные" +
                "\n2. Добавить запись" +
                "\nДля выхода нажмите любую другую клавишу"
                );
            key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    ShowEmployeeList();
                    break;
                case '2':
                    AddRecord();
                    break;
                default:
                    break;
            }

            Console.ReadKey();

            void ShowEmployeeList()
            {
                Console.Clear();
                if (File.Exists(source))
                {
                   using(StreamReader streamReader = new StreamReader(source))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] data = line.Split('#');
                            Console.WriteLine(
                                $"Запись №{data[0]} " +
                                $"от {data[1]}\n\t" +
                                $"{data[2]}\n\t" +
                                $"Возраст: {data[3]}\n\t" +
                                $"Рост: {data[4]}\n\t" +
                                $"Дата рождения: {data[5]}\n\t" +
                                $"Место рождения: {data[6]}\n"
                                );
                        }

                    }
                }
                else
                    Console.WriteLine("Пока нет ни одной записи");
            }

            void AddRecord()
            {
                Console.Clear();
                if (File.Exists(source))
                    lastRecord = File.ReadAllLines(source).Length;
                else
                    lastRecord=0;

                using (StreamWriter streamWriter = new StreamWriter(source, true))
                {
                    streamWriter.Write($"{lastRecord + 1}#{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
                    for (int i = 0; i < userInputFields.Length; i++)
                    {
                        Console.Clear();
                        Console.Write($"Введите {userInputFields[i]}: ");
                        streamWriter.Write("#" + Console.ReadLine());
                    }

                }
            }
        }
    }
}
