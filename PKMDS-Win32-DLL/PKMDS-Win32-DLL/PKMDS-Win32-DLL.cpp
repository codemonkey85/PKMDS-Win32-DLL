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

EXPORT void GetSAVData_INTERNAL(bw2sav_obj * save, const char * savefile)
{
	read(savefile,save);
};

EXPORT void GetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	*pokemon = *pkm;
};

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

EXPORT BSTR GetPKMName_FromObj/*_FromSav*/(pokemon_obj * pkm/*, int box, int slot*/)
{
	//pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	//if(!(pkm->isboxdatadecrypted))
	//{
	//	decryptpkm(pkm);
	//}
	std::string ret = lookuppkmname(pkm);
	return ANSItoBSTR(ret.c_str());
}

EXPORT BSTR GetTrainerName_FromSav(bw2sav_obj * sav)
{
	std::wstring trainername = getwstring(sav->cur.trainername);
	std::string trainernamestr = std::string(trainername.begin(),trainername.end());
	return ANSItoBSTR(trainernamestr.c_str());
}

EXPORT int GetTrainerTID_FromSav(bw2sav_obj * sav)
{
	return sav->cur.tid;
}

EXPORT int GetTrainerSID_FromSav(bw2sav_obj * sav)
{
	return sav->cur.sid;
}

EXPORT BSTR GetBoxName(bw2sav_obj * sav, int box)
{
	std::wstring boxname = getwstring(sav->cur.boxnames[box]);
	std::string boxstr = std::string(boxname.begin(),boxname.end());
	return ANSItoBSTR(boxstr.c_str());
}

EXPORT int GetPKMStat(bw2sav_obj * sav, int box, int slot, int stat)
{
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	int ret = getpkmstat(pkm,Stat_IDs::stat_ids(stat));
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
