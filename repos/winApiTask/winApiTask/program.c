#include <windows.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR pCmdLine, int nCmdShow)
{
	MessageBox(NULL, L"Сообщение", L"Нажмите на одну из кнопок", MB_ICONQUESTION);
	return 0;
}