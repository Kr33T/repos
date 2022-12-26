#include <stdio.h>
#include <malloc.h>

typedef int (*f)(int, int);
typedef f* delegate;

int countFunc;

int sum(int, int);
int razn(int, int);
int mult(int, int);
int pow(int, int);
delegate initDelegate();
void addFunc(delegate, f);
void removeFunc(delegate, f);
void runDelegate(delegate);
void removeRecurringFunc(delegate);

int sum(int a, int b)
{
	return a + b;
}

int razn(int a, int b)
{
	return a - b;
}

int mult(int a, int b)
{
	return a * b;
}

int pow(int a, int n)
{
	int temp = a;
	for (int i = 1; i < n; i++)
	{
		a *= temp;
	}
	return a;
}

delegate initDelegate()
{
	delegate d = calloc(1, sizeof(f));
	return d;
}

void addFunc(delegate d, f f)
{
	d[countFunc] = f;
	countFunc++;
	d = realloc(d, (countFunc + 1) * sizeof(f));
}

void removeFunc(delegate d, f f)
{
	for (int i = 0; i < countFunc; i++)
	{
		if (d[i] == f)
		{
			countFunc--;
			for (int j = i; j < countFunc; j++)
			{
				d[j] = d[j + 1];
			}
			d = realloc(d, (countFunc + 1) * sizeof(f));
		}
	}
}

void runDelegate(delegate d, int a, int b)
{
	for (int i = 0; i < countFunc; i++)
	{
		if (d[i])
		{
			printf("%d\n", d[i](a, b));
		}
	}
}

void removeRecurringFunc(delegate d)
{
	for (int i = 0; i < countFunc; i++)
	{
		for (int j = i + 1; j < countFunc; j++)
		{
			if (d[i] == d[j])
			{
				countFunc--;
				for (int k = j; k < countFunc; k++)
				{
					d[k] = d[k + 1];
					i--;
				}
				d = realloc(d, (countFunc + 1) * sizeof(f));
			}
		}
	}
}

int main()
{
	delegate del = initDelegate();
	addFunc(del, pow);
	addFunc(del, sum);
	addFunc(del, razn);
	addFunc(del, mult);
	addFunc(del, pow);
	addFunc(del, pow);
	addFunc(del, sum);
	runDelegate(del, 2, 3);
	printf("\n");

	removeFunc(del, sum);
	runDelegate(del, 2, 3);
	printf("\n");

	removeRecurringFunc(del);
	runDelegate(del, 2, 3);

	return 0;
}