// PKMDS-Win32-DLL.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "../../../PKMDS/include/pkmds/pkmds_sql.h"
#include <comutil.h>

BSTR ANSItoBSTR(const char* input);

#define EXPORT extern "C" __declspec(dllexport)

EXPORT BSTR GetPKMName(int speciesid, int langid, const char * dbfilename)
{
	opendb(dbfilename);
	std::string ret = lookuppkmname(speciesid,langid).c_str();
	closedb();
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetPKMName_FromSav(const char * savefile, int box, int slot, const char * dbfilename)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	decryptpkm(pkm);
	opendb(dbfilename);
	std::string ret = lookuppkmname(pkm);
	closedb();
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetBoxName(const char * savefile, int box)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	std::wstring boxname = (sav->cur.boxnames[box]);
	std::string boxstr = std::string(boxname.begin(),boxname.end());
	return ANSItoBSTR(boxstr.c_str());
}

EXPORT int GetPKMStat(const char * savefile, int box, int slot, int stat, const char * dbfilename)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	decryptpkm(pkm);
	opendb(dbfilename);
	int ret = getpkmstat(pkm,Stat_IDs::stat_ids(stat));
	closedb();
	return ret;
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
