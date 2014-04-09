// PKMDS-Win32-DLL.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "../../externals/PKMDS/include/pkmds/pkmds_sql.h"
#include <comutil.h>

BSTR ANSItoBSTR(const char* input);

#define EXPORT extern "C" __declspec(dllexport)

EXPORT void OpenDB(const char * dbfilename)
{
	opendb(dbfilename);
}
EXPORT void CloseDB()
{
	closedb();
}

EXPORT BSTR GetPKMName(int speciesid, int langid)
{
	std::string ret = lookuppkmname(speciesid,langid).c_str();
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetItemName(int itemid, int generation, int langid)
{
	std::string ret = lookupitemname(itemid,generation,langid).c_str();
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetMoveName(int moveid, int langid)
{
	std::string ret = lookupmovename(moveid, langid).c_str();
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetPKMName_FromSav(const char * savefile, int box, int slot)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	decryptpkm(pkm);
	std::string ret = lookuppkmname(pkm);
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetTrainerName_FromSav(const char * savefile)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	std::wstring trainername = getwstring(sav->cur.trainername); // sav->cur.party.pokemon[0].otname;
	std::string trainernamestr = std::string(trainername.begin(),trainername.end());
	return ANSItoBSTR(trainernamestr.c_str());
}

EXPORT int GetTrainerTID_FromSav(const char * savefile)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	return sav->cur.tid;
}

EXPORT int GetTrainerSID_FromSav(const char * savefile)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	return sav->cur.sid;
}

EXPORT BSTR GetBoxName(const char * savefile, int box)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	std::wstring boxname = getwstring(sav->cur.boxnames[box]);
	std::string boxstr = std::string(boxname.begin(),boxname.end());
	return ANSItoBSTR(boxstr.c_str());
}

EXPORT int GetPKMStat(const char * savefile, int box, int slot, int stat)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	decryptpkm(pkm);
	int ret = getpkmstat(pkm,Stat_IDs::stat_ids(stat));
	return ret;
}

EXPORT void GetPKMData_INTERNAL(pokemon_obj * pokemon, const char * savefile, int box, int slot)
{
	bw2sav_obj * sav = new bw2sav_obj();
	read(savefile,sav);
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	decryptpkm(pkm);
	*pokemon = *pkm;
};

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
