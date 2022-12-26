#include <stdio.h>
#include <malloc.h>

void task1()
{
	int a;
	int* p = &a;
	printf("Введите значение переменной а: ");
	scanf_s("%d", p);
	printf("Значение переменной: %d", *p);
}

void task2() 
{
	int* a = calloc(1000000, sizeof(int));


}

int main() 
{
	system("chcp 1251 > nul");
	printf("Введите номер задачи: ");
	int n;
	scanf_s("%d", &n);
	switch (n) 
	{
	case 1:
		task1();
		break;
	case 2:
		task2();
		break;
	case 3:
		break;
	case 4:
		break;
	default:
		printf("Вы ввели некорректный номер задачи");
		break;
	}
}