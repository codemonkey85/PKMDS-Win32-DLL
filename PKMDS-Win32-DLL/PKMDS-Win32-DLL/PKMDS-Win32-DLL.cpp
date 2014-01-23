// PKMDS-Win32-DLL.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "../../../PKMDS/include/pkmds/pkmds_sql.h"
#include <comutil.h>

BSTR ANSItoBSTR(const char* input);

#define EXPORT extern "C" __declspec(dllexport) BSTR

EXPORT GetPKMName(int speciesid, int langid, const char * dbfilename)
{
	opendb(dbfilename);
	std::string ret = lookuppkmname(speciesid,langid).c_str();
	closedb();
	return ANSItoBSTR(ret.c_str());
}

BSTR ANSItoBSTR(const char* input)
{
    BSTR result = NULL;
    int lenA = lstrlenA(input);
    int lenW = ::MultiByteToWideChar(CP_ACP, 0, input, lenA, NULL, 0);
    if (lenW > 0)
    {
        result = ::SysAllocStringLen(0, lenW);
        ::MultiByteToWideChar(CP_ACP, 0, input, lenA, result, lenW);
    } 
    return result;
}
