namespace lab3.Persons
{
    // Выделение класса (Extract Class) - правило рефакторинга
    public static class MathematicianExt
    {
        // Функции должны иметь небольшое количество аргументов
        // Лучше всего, когда аргументов вообще нет
        // Роберт Мартин "Чистый код" стр. 325
        public static Mathematician GetFastestMathematician(this Mathes mathes)
        {
            // Используйте пояснительные переменные
            // Роберт Мартин "Чистый код" стр. 335
            var fastest = mathes[0];
            foreach (Mathematician math in mathes)
            {
                if (math.ComputingSpeed > fastest.ComputingSpeed)
                {
                    fastest = math;
                }
            }

            return fastest;
        }

        // Содержательные имена
        // Роберт Мартин "Чистый код" стр. 349
        public static Mathematician GetMostAttentiveMathematician(this Mathes mathes)
        {
            var atten = mathes[mathes[0].Nickname];
            foreach (Mathematician math in mathes)
            {
                if (math.Attention > atten.Attention)
                {
                    atten = math;
                }
            }

            return atten;
        }
    }
}