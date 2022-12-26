#include <stdio.h>
#include <malloc.h>

void v1()
{
	int n = 10, k = 10;//n-размерность зубчатого массива, k-переменная отвечающая за резмерность массивов в зубчатом массиве
	int** array = calloc(n, sizeof(int*));//инициализируем массив с массивами (зубчатый массив)
	for (int i = 0; i < n; i++)//цикл по зубчатому массиву
	{
		array[i] = calloc(k, sizeof(int));//инициализируем элемент зубчатого массива (элементом зубчатого массива является массив)
		for (int j = 0; j < k; j++)//цикл по элементу зубчатого массива(по массиву в зубчатом массиве)
		{
			array[i][j] = j;//присваиваем элементам массивов зубчатого массива их индексы
			printf("%d ", array[i][j]);//вывод
		}
		printf("\n");
		k--;//уменьшаем размерность следующего массива
	}
}

void v2()
{
	int n = 6, k = 1;
	if (n % 2 == 0)
	{
		n++;
	}
	int** array = calloc(n, sizeof(int**));
	for (int i = 0; i < n; i++)
	{
		if (i < n / 2)
		{
			*(array + i) = calloc(k, sizeof(int*));
			for (int j = 0; j < k; j++)
			{
				array[i][j] = j;
				printf("%d ", array[i][j]);
			}
			printf("\n");
			k++;
		}
		else
		{
			*(array + i) = calloc(k, sizeof(int*));
			for (int j = 0; j < k; j++)
			{
				array[i][j] = j;
				printf("%d ", array[i][j]);
			}
			printf("\n");
			k--;
		}
	}
}

void v3()
{
	int n = 9, k = 10;
	int nn = n, nnn = n;
	int** array = calloc(n, sizeof(int*));
	for (int i = 0; i <= n; i++)
	{
		array[i] = calloc(k, sizeof(int));
		for (int j = 0; j < k; j++)
		{
			array[i][j] = nn;
			printf("%d ", array[i][j]);
			nn--;
		}
		printf("\n");
		nnn--;
		nn = nnn;
		k--;
	}
}

void v4()
{
	int n = 8, k;//n-размерность зубчатого массива, k-переменная отвечающая за резмерность массивов в зубчатом массиве
	n++;
	k = n;
	int** array = calloc(n, sizeof(int*));//инициализируем массив с массивами (зубчатый массив)
	for (int i = 0; i < n; i++)//цикл по зубчатому массиву
	{
		array[i] = calloc(k, sizeof(int));//инициализируем элемент зубчатого массива (элементом зубчатого массива является массив)
		for (int j = 0; j < k; j++)//цикл по элементу зубчатого массива(по массиву в зубчатом массиве)
		{
			array[i][j] = j * 2;//присваиваем элементам массивов зубчатого массива их индексы
			printf("%d ", array[i][j]);//вывод
		}
		printf("\n");
		k--;//уменьшаем размерность следующего массива
	}
}

int main()
{
	v4();

	return 0;
}