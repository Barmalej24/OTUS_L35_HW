namespace OTUS_L35_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            var demoDict = new OtusDictionary();

            demoDict.Add(1, "элемент 1");
            demoDict.Add(2, "элемент 2");
            demoDict.Add(6, "элемент 6");
            demoDict.Add(5, "");
            demoDict.Add(8, "элемент 8");

            Console.WriteLine("Добавим в словарь элементов с ключами вызывающие коллизию");
            demoDict.Add(65, "элемент 65");
            demoDict.Add(6, "Меняем 6");
            demoDict.Add(5, "Меняем 5");

            Console.WriteLine("Добавим в словарь еще элементов");
            demoDict.Add(33, "33");
            demoDict.Add(-111, "-111");
            demoDict.Add(222, "первый 222");
            demoDict.Add(222, "второй 222");

            Console.WriteLine("Добавим в словарь 10 элементов со случайными ключами двумя способами (add / индексатор)");
            for (int i = 0; i < 5; i++)
            {
                int key = rng.Next();
                demoDict.Add(key, $"элемент {key}");

                key = rng.Next();
                demoDict[key] = $"элемент {key}";
            }

            Console.WriteLine("Проверяем работу словаря");
            Console.WriteLine("Get элементов");
            Console.WriteLine(demoDict.Get(6));
            Console.WriteLine(demoDict.Get(222));
            Console.WriteLine(demoDict.Get(5155));            

            Console.WriteLine("Индексатор работает");
            demoDict[3] = null;
            Console.WriteLine(demoDict[-111]);

            Console.ReadKey();
        }
    }
}
