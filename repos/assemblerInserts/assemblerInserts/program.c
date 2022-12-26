#include <stdio.h>

int sum(int, int);
int razn(int, int);
int mult(int, int);
int div(int, int);

int sum(int a, int b)
{
	int c;
	__asm
	{
		mov eax, a;
		add eax, b;
		mov c, eax;
	}
	return c;
}

int razn(int a, int b)
{
	int c;
	__asm
	{
		mov eax, a;
		sub eax, b;
		mov c, eax;
	}
	return c;
}

int mult(int a, int b)
{
	int c;
	__asm
	{
		mov eax, a;
		imul eax, b;
		mov c, eax;
	}
	return c;
}

int div(int a, int b)
{
	int c;
	_asm {
		mov eax, a;
		mov edx, b;
		div b
		mov c, eax
	}
	return c;
}

int percent(int a, int b)
{
	int c;
	__asm
	{
		mov eax, a
		mov edx, 0
		div b
		mov c, edx
	}
	return c;
}

int compare2(int a, int b)
{
	int c;
	__asm
	{
		mov eax, a
		mov ebx, b
		cmp eax, ebx
		je a1; //ravny
		jb a2; //vtoroe
		ja a3; //pervoe
	a1:
		mov c, 0
		jmp exit;
	a2:
		mov c, 2
		jmp exit
	a3:
		mov c, 1
		jmp exit;

	exit:
	}
	return c;
}

int compare3(int a, int b, int c)
{
	int r;
	__asm
	{
		mov eax, a
		mov ebx, b
		mov ecx, c
		cmp eax, ebx
		je a1; //ravn
		jb a2; //vtoroe
		ja a3; //pervoe
	a1:
		cmp eax, ecx
		je a4; //ravn
		jb a5; //tretie
		ja a6; //vtoroe
	a2:
		cmp ebx, ecx
		je a8; //ravn
		jb a5; //tretie
		ja a6; //vtoroe
	a3 :
		cmp eax, ecx
		je a7; //pervoe
		jb a5; //tretie
		ja a7; //pervoe
	a4:
		mov r, 0
		jmp exit;
	a5:
		mov r, 3
		jmp exit;
	a6:
		mov r, 2
		jmp exit;
	a7:
		mov r, 1
		jmp exit;
	a8:
		cmp eax, ecx
		je a4; //ravn
		jb a5; //tretie
		ja a7; //pervoe

	exit:
	}
	return r;
}

void replace(int a, int b)
{
	/*int temp = *a;
	*a = *b;
	*b = temp;*/
	__asm
	{
		lds eax, a
		lds ebx, b
		mov a, ebx
		mov b, eax
	}
}

int main()
{
	int a = 3, b = 9;
	printf("%d %d\n", a, b);
	replace(&a, &b);
	printf("%d %d", a, b);

	return 0;
}