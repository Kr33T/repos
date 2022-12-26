#include <stdio.h>
#include <malloc.h>

struct MyStruct {

	int a;
	struct MyStruct* next; // указатель на след.элемент.


};

typedef struct MyStruct LOS; // определение нового имени для типа данных

LOS* initLOS(int n) {
	LOS* start = malloc(sizeof(LOS)); // создаем первый элемент
	start->a = 1; // первого элементу даем начальное значение
	start->next = NULL; // потому что 2го элемента еще нету
	LOS* x, * y; // указатель на текущий и следующий элемент (1 и 2 элемент)
	x = start; // задаем указателю на первый элемент значение 1 (бошка)
	for (size_t i = 0; i < n - 1; i++)
	{
		y = malloc(sizeof(LOS)); // инициализируем след.элемент
		y->a = x->a + 1; // задаем следующему элементу значение (предыдущего +1)
		x->next = y; // для настоящего элемента задаем адрес следующего 
		x = y; // текущий элемент стал следующим
	}
	x->next = NULL; // задаем последнему элементу нулевое значение указателю на след элемент. потому что у последнего пары нет
	return start;

}

void showLOS(LOS* list) {


	while (list) { //пока list != NULL

		printf("%d ", list->a);
		list = list->next; // двигаем указатель на след элемент.

	}

	printf("\n");

}

void deleteLOS(LOS* list)
{
	LOS* temp = list->next; // храним след. элемент
	while (temp) {


		temp = list->next; // запоминаем следующий
		free(list); // удаляем настоящий
		list = temp; // следующий стал первым

	}
}

//v1
LOS* trade(LOS* list) {

	LOS* start = list; // запомнили первый элемент
	int count = 0;
	while (list) { // считаем  количество введеных элементов

		list = list->next;
		count++;
	}
	//count--;
	list = start;
	for (size_t i = 1; i < count; i++)
	{
		list = list->next;
	}

	list->next = start;
	list = start;

	for (size_t i = 1; i < count / 2; i++)
	{
		list = list->next;
	}
	int* temp = list->next;
	list->next = NULL;
	list = temp;


	return list;


}

//v2
LOS* deleteElement(LOS* list, int a)
{
	LOS* start = list; //башка

	if (list->a == a)// случай, если первый элемент будет иметь указанное значение
	{
		return list->next;//возвращаем в качестве башки 2 элемент, т.е первый элемент у нас фактически забывается
	}

	while (list)//цикл по всему списку
	{
		if (list->next->a == a)//Если мы находимся на первом элементе, то мы проверяем не его значение, а значение следующего элемента (list->next->a) и если оно совпадает с указанным аргуметом "а", то мы останавливаемся на элементе, предшествующему элементу, который неоходимо удалить
		{
			break;
		}
		list = list->next;//если условие не выполнилось, то переходим к следующему элементу
	}
	list->next = list->next->next;//так как мы остановились перед элементом, который нужно удалить, то мы можем переприсвоить поле next элемента, на котором остановились, указателем через один элемент (скипнув тот, который необходимо удалить)

	list = start;//возвращаемся в башку

	return list;
}

//v3
void changeElement(LOS* list, int index, int a)
{
	LOS* start = list;//башка
	int count = 0;//количество элементов
	while (list)//подсчет количества элементов
	{
		count++;
		list = list->next;
	}
	
	list = start;//возвращаем башку на место

	if (index < count)//указанный в аргументе индекс не может быть больше количества элементов
	{
		for (int i = 0; i < count; i++)//проходимся по всему списку
		{
			if (i == index)//если индекс элемента соответствует индексу, указанному в аргументах, то переприсваиваем значение данного элемента и выходим из цикла
			{
				list->a = a;
				break;
			}
			list = list->next;//для переноса указателя по списку
		}

		list = start;//возвращаем башку на место
	}
	else
	{
		printf("Введен некорректный индекс (дольше чем количество элементов в ЛОС)");
	}
}

//v4 от 1 до k, k > 1
LOS* deletePartOfList(LOS* list, int k)
{
	LOS* start = list;//башка
	int count = 0;// количество элементов
	while (list)//подсчет количества
	{
		count++;
		list = list->next;
	}

	list = start;//возвращаем башку

	if (k < count)//указанный в аргументе индекс не может быть больше количества элементов
	{
		for (int i = 0; i < count; i++)//цикл по списку
		{
			if (i >= k)//так как нам необходимо найти элемент, который стоит после указанного в аргументах индекса k, проверяем условие. Как только мы дойдем до индекса, который равен k, выходим из цикла, остановившись на элементе, который необходимо удалить последним (т.к необходимо удалить элементы от 1 до k)
			{
				break;
			}
			list = list->next;//передвижение по списку
		}

		int* temp = list->next;//записываем в переменную адрес элемента, следующего за тем, который необходимо удалить последним

		list = start;//возвращаем башку

		list->next = temp;//вторым элементом указываем тот, который стоял после того элемента, который необходимо было удалить последним

		return list;
	}
	else
	{
		printf("Введен некорректный индекс (дольше чем количество элементов в ЛОС)");
		return start;
	}
}

int main()
{
	system("chcp 1251 > nul");
	printf("Введите количество n натуральных чисел ");
	int n;
	scanf_s("%d", &n);

	LOS* list = initLOS(n);
	showLOS(list);
	//deleteLOS(list);
	//list = trade(list);
	//list = deleteElement(list, 1);
	//changeElement(list, 5, 1);
	//list = deletePartOfList(list, 4);
	showLOS(list);
	system("pause");
	return 0;
}