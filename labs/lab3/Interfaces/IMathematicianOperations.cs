// Выделение интерфейса (Extract Interface) - правило рефакторинга

namespace lab3.Interfaces
{
    // Имена на подходяшем уровне абстракции
    // Не используйте имена, передающие информацию о реализации
    // Роберт Мартин "Чистый код" стр. 351
    public interface IMathematicianOperations
    {
        // Имена функций должны описывать выполняемую операцию
        // Роберт Мартин "Чистый код" стр. 335
        double DoDivision(double x, double y);
        double DoMultiplication(double x, double y);
        double DoSubtraction(double x, double y);

        double DoAddition(double x, double y);
        // Функции должны быть написаны на одном уровне абстракции
        // Роберт Мартин "Чистый код" стр. 344
    }
}