@echo off
PATH="%WINDIR%\Microsoft.NET\Framework\v1.0.3705";%PATH%
PATH="%WINDIR%\Microsoft.NET\Framework\v1.1.4322";%PATH%
PATH="%WINDIR%\Microsoft.NET\Framework\v2.0.50727";%PATH%
PATH="%WINDIR%\Microsoft.NET\Framework\v3.0";%PATH%
PATH="%WINDIR%\Microsoft.NET\Framework\v3.5";%PATH%
PATH="%WINDIR%\Microsoft.NET\Framework\v4.0.30319";%PATH%

Set enc=%1
Set tmp=%2
Set dec=%enc:~-2%
echo.# C#�VB.NET�R���p�C���[�̎g����
echo.# 
echo.# ^>csc ???.cs
echo.# ��c#�R���p�C��
echo.# ^>csc /target:winexe ???.cs
echo.# ��WindowsApp�Ƃ��ăR���p�C��
echo.#
echo.# ^>vbc ???.vb
echo.# ��VB.NET�R���p�C��
echo.# ^>vbc /target:winexe ???.vb
echo.# ��WindowsApp�Ƃ��ăR���p�C��
echo.#
echo.# ���݂�Windows�Ŋ�{�I�Ɏg���錾��(�g���q)��
echo.# bat,cs,css,html(hta),js,ps,vb,vbs,vba,(ini,exe)
echo.# �ł��B
echo.# 
if "%dec%"=="cs" (
	echo.# �I�����ꂽ�t�@�C��:%enc%
	csc %enc%
) else if "%dec%"=="vb" (
	echo.# �I�����ꂽ�t�@�C��:%enc%
	vbc %enc%
) else (
	cmd
)
if not %errorlevel% == 0 (
	echo. Error!
	PAUSE
) else (
	if "%dec%"=="cs" (
		start %enc:~0,-2%exe
	) else if "%dec%"=="vb" (
		start %enc:~0,-2%exe
	)
)