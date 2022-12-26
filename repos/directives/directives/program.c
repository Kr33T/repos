#include "headers.txt"

#define dA 3
#define dB 3
#define dC 2

void showSAndPOfTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
{
	//float a = getLength(x1, y1, x2, y2);
	//float b = getLength(x2, y2, x3, y3);
	//float c = getLength(x3, y3, x1, y1);

	int check = 0;

#if dA >= dB + dC || dB >= dA + dC || dC >= dA + dB
	check = 0;
#else
	check = 1;
#endif

	/*if (a >= b + c)
		check = 0;
	else if (b >= a + c)
		check = 0;
	else if (c >= a + b)
		check = 0;
	else check = 1;*/

	if (check == 1)
	{
		float Pm = dA + dB + dC;
		float p = Pm / 2;
		float Sq = sqrt(p * (p - dA) * (p - dB) * (p - dC));
		printf("Периметр: %f; Площадь: %f", Pm, Sq);
	}
	else
	{
		printf("Треугольник с данными точками не существует.");
	}
}

int main()
{
	system("chcp 1251 > nul");
	printf("1. Подключен файл заголовочный файл <stdio.h> (вызван метод printf() для вывода данной строки)\n");
	printf("2. Добавлен пользовательский заголовочный файл \"header.txt\"\n");
	printf("3. Проверка работоспособности написанных методов 4 основных арфиметических действия:\n3.1) Сумма 2 и 4 = %d\n3.2) Вычитание 2 и 4 = %d\n3.3) Умножение 2 на 4 = %d\n3.4) Деление 2 на 4 = %f\n", sum(2, 4), subtr(2, 4), mult(2, 4), div(2.0, 4.0));

	printf("4. Разработана функция concat() соединения двух строк, результат выполнения функции: \"%s\" + \"%s\" = \"%s\"\n", A, B, concat(A, B));

	printf("5. Разработаны функции для перевода числа в строку и наоборот (ConvertToString, ConvertToInt соответственно). Результат выполнения: число %d в строку %s, строку %s в число %d\n", X, ConvertToString(X), S, ConvertToInt(S));

	printf("Длина отрезка AB (A(1;3), B(2;5)) - %f\n", getLength(1, 3, 2, 5));

	showSAndPOfTriangle(1, 2, 3, 5, 1, 5);

	return 0;
}