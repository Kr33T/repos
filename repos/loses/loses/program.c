#include <stdio.h>
#include <malloc.h>

struct MyStruct {

	int a;
	struct MyStruct* next; // ��������� �� ����.�������.


};

typedef struct MyStruct LOS; // ����������� ������ ����� ��� ���� ������

LOS* initLOS(int n) {
	LOS* start = malloc(sizeof(LOS)); // ������� ������ �������
	start->a = 1; // ������� �������� ���� ��������� ��������
	start->next = NULL; // ������ ��� 2�� �������� ��� ����
	LOS* x, * y; // ��������� �� ������� � ��������� ������� (1 � 2 �������)
	x = start; // ������ ��������� �� ������ ������� �������� 1 (�����)
	for (size_t i = 0; i < n - 1; i++)
	{
		y = malloc(sizeof(LOS)); // �������������� ����.�������
		y->a = x->a + 1; // ������ ���������� �������� �������� (����������� +1)
		x->next = y; // ��� ���������� �������� ������ ����� ���������� 
		x = y; // ������� ������� ���� ���������
	}
	x->next = NULL; // ������ ���������� �������� ������� �������� ��������� �� ���� �������. ������ ��� � ���������� ���� ���
	return start;

}

void showLOS(LOS* list) {


	while (list) { //���� list != NULL

		printf("%d ", list->a);
		list = list->next; // ������� ��������� �� ���� �������.

	}

	printf("\n");

}

void deleteLOS(LOS* list)
{
	LOS* temp = list->next; // ������ ����. �������
	while (temp) {


		temp = list->next; // ���������� ���������
		free(list); // ������� ���������
		list = temp; // ��������� ���� ������

	}
}

//v1
LOS* trade(LOS* list) {

	LOS* start = list; // ��������� ������ �������
	int count = 0;
	while (list) { // �������  ���������� �������� ���������

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
	LOS* start = list; //�����

	if (list->a == a)// ������, ���� ������ ������� ����� ����� ��������� ��������
	{
		return list->next;//���������� � �������� ����� 2 �������, �.� ������ ������� � ��� ���������� ����������
	}

	while (list)//���� �� ����� ������
	{
		if (list->next->a == a)//���� �� ��������� �� ������ ��������, �� �� ��������� �� ��� ��������, � �������� ���������� �������� (list->next->a) � ���� ��� ��������� � ��������� ��������� "�", �� �� ��������������� �� ��������, ��������������� ��������, ������� ��������� �������
		{
			break;
		}
		list = list->next;//���� ������� �� �����������, �� ��������� � ���������� ��������
	}
	list->next = list->next->next;//��� ��� �� ������������ ����� ���������, ������� ����� �������, �� �� ����� ������������� ���� next ��������, �� ������� ������������, ���������� ����� ���� ������� (������� ���, ������� ���������� �������)

	list = start;//������������ � �����

	return list;
}

//v3
void changeElement(LOS* list, int index, int a)
{
	LOS* start = list;//�����
	int count = 0;//���������� ���������
	while (list)//������� ���������� ���������
	{
		count++;
		list = list->next;
	}
	
	list = start;//���������� ����� �� �����

	if (index < count)//��������� � ��������� ������ �� ����� ���� ������ ���������� ���������
	{
		for (int i = 0; i < count; i++)//���������� �� ����� ������
		{
			if (i == index)//���� ������ �������� ������������� �������, ���������� � ����������, �� ��������������� �������� ������� �������� � ������� �� �����
			{
				list->a = a;
				break;
			}
			list = list->next;//��� �������� ��������� �� ������
		}

		list = start;//���������� ����� �� �����
	}
	else
	{
		printf("������ ������������ ������ (������ ��� ���������� ��������� � ���)");
	}
}

//v4 �� 1 �� k, k > 1
LOS* deletePartOfList(LOS* list, int k)
{
	LOS* start = list;//�����
	int count = 0;// ���������� ���������
	while (list)//������� ����������
	{
		count++;
		list = list->next;
	}

	list = start;//���������� �����

	if (k < count)//��������� � ��������� ������ �� ����� ���� ������ ���������� ���������
	{
		for (int i = 0; i < count; i++)//���� �� ������
		{
			if (i >= k)//��� ��� ��� ���������� ����� �������, ������� ����� ����� ���������� � ���������� ������� k, ��������� �������. ��� ������ �� ������ �� �������, ������� ����� k, ������� �� �����, ������������� �� ��������, ������� ���������� ������� ��������� (�.� ���������� ������� �������� �� 1 �� k)
			{
				break;
			}
			list = list->next;//������������ �� ������
		}

		int* temp = list->next;//���������� � ���������� ����� ��������, ���������� �� ���, ������� ���������� ������� ���������

		list = start;//���������� �����

		list->next = temp;//������ ��������� ��������� ���, ������� ����� ����� ���� ��������, ������� ���������� ���� ������� ���������

		return list;
	}
	else
	{
		printf("������ ������������ ������ (������ ��� ���������� ��������� � ���)");
		return start;
	}
}

int main()
{
	system("chcp 1251 > nul");
	printf("������� ���������� n ����������� ����� ");
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