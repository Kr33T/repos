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
		printf("��������: %f; �������: %f", Pm, Sq);
	}
	else
	{
		printf("����������� � ������� ������� �� ����������.");
	}
}

int main()
{
	system("chcp 1251 > nul");
	printf("1. ��������� ���� ������������ ���� <stdio.h> (������ ����� printf() ��� ������ ������ ������)\n");
	printf("2. �������� ���������������� ������������ ���� \"header.txt\"\n");
	printf("3. �������� ����������������� ���������� ������� 4 �������� �������������� ��������:\n3.1) ����� 2 � 4 = %d\n3.2) ��������� 2 � 4 = %d\n3.3) ��������� 2 �� 4 = %d\n3.4) ������� 2 �� 4 = %f\n", sum(2, 4), subtr(2, 4), mult(2, 4), div(2.0, 4.0));

	printf("4. ����������� ������� concat() ���������� ���� �����, ��������� ���������� �������: \"%s\" + \"%s\" = \"%s\"\n", A, B, concat(A, B));

	printf("5. ����������� ������� ��� �������� ����� � ������ � �������� (ConvertToString, ConvertToInt ��������������). ��������� ����������: ����� %d � ������ %s, ������ %s � ����� %d\n", X, ConvertToString(X), S, ConvertToInt(S));

	printf("����� ������� AB (A(1;3), B(2;5)) - %f\n", getLength(1, 3, 2, 5));

	showSAndPOfTriangle(1, 2, 3, 5, 1, 5);

	return 0;
}