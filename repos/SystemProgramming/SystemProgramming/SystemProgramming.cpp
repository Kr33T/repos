#include <stdio.h>
#include <iostream>

int main()
{
    system("chcp 1251 > null");
    int n = 0;
    bool check = false;
    printf("Введите номер задачи: ");
    while (true) {
        scanf_s("%d", &n);
        switch (n) {
        case 1:
            check = true;
            break;
        case 2:
            check = true;
            break;
        case 3:
            check = true;
            break;
        default:
            check = false;
            printf("Вы ввели некорретный номер задачи!\nПовторите ввод: ");
            break;
        }
        if (check) {
            break;
        }
    }
    
}