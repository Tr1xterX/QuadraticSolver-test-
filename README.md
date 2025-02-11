# QuadraticSolver

QuadraticSolver — это консольное приложение на C#, которое решает квадратные уравнения вида \( ax^2 + bx + c = 0 \). Программа поддерживает ввод данных из файла и с консоли, а также выводит решения уравнений, включая комплексные числа, если они есть.

## Особенности

- Решение квадратных уравнений.
- Поддержка ввода данных из файла и консоли.
- Обработка комплексных чисел.
- Юнит-тесты для проверки корректности работы.

## Требования
- .NET Framework 4.7.2

Формат файла:
Файл должен содержать коэффициенты (a), (b) и (c) для каждого уравнения, разделенные пробелами. Каждое уравнение на новой строке.
Пример содержимого файла:
1 0 1
2 5 -3.5
1 1 1

## Структура проекта
QuadraticSolver: Основной проект, содержащий логику решения уравнений.
- Program Начальная точка запуска, каркас программы, что управляет ост файлами
- InputReader классы, отвечающие за чтение коэффициентов из файла/консоли
- ComplexFormatter обработка вывода корней удобного для чтения
- EquationSolver поиск корней квадратного уравнения
- EquationProcessor Формирование решения уравненя и вывод

UnitTests: Проект с юнит-тестами для проверки корректности работы основного проекта.

InputFileForTest: Папка с файлами значений коэффициентов.
