namespace sb_sharp_u6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char key = '1';

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
                //метод выводящий данные
                case '2':
                //метод запускающий процесс добавления записи в конец файла
                default:
                    break;
            }

            static void Get()
            {

            }
        }
    }
}
