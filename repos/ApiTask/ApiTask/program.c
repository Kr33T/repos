#include <windows.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR pCmdLine, int nCmdShow)
{
	MessageBox(NULL, "Привет, мир", "Тест", MB_OK);
	return 0;
}