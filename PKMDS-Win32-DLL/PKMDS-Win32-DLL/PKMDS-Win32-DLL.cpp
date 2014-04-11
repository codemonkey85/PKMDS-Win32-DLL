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
EXPORT void OpenImgDB(const char * dbfilename)
{
	openimgdb(dbfilename);
}
EXPORT void CloseImgDB()
{
	openimgdb();
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
EXPORT void SetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	if(!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	calcchecksum(pokemon);
	//encryptpkm(pokemon);
	sav->cur.boxes[box].pokemon[slot] = *pokemon;
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
EXPORT BSTR GetMoveTypeName(uint16 moveid, int langid)
{
	std::string ret = lookupmovetypename(moveid, langid).c_str();
	return ANSItoBSTR(ret.c_str());
}
EXPORT BSTR GetPKMName_FromObj(pokemon_obj * pkm)
{
	std::string ret = lookuppkmname(pkm);
	return ANSItoBSTR(ret.c_str());
}
EXPORT int GetPKMMoveID(pokemon_obj * pokemon, int moveid)
{
	return pokemon->moves[moveid];
}
EXPORT BSTR GetTrainerName_FromSav(bw2sav_obj * sav)
{
	std::wstring trainername = getwstring(sav->cur.trainername,OTLENGTH);
	std::string trainernamestr = std::string(trainername.begin(),trainername.end());
	return ANSItoBSTR(trainernamestr.c_str());
}
EXPORT void SetTrainerName_FromSav_INTERNAL(bw2sav_obj * sav, wchar_t * name, int namelength)
{
	setsavetrainername(sav,name,namelength);
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
EXPORT int GetPKMStat_FromObj(pokemon_obj * pkm, int stat)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	int ret = getpkmstat(pkm,Stat_IDs::stat_ids(stat));
	return ret;
}
EXPORT void GetPKMSprite_INTERNAL(pokemon_obj * pkm, byte ** picdata, int * size, int generation)
{
	std::ostringstream o;
	getspritesql(o,pkm,generation);
	getapic(o,picdata,size);
}
EXPORT void GetPKMIcon_INTERNAL(pokemon_obj * pkm, byte ** picdata, int * size, int generation)
{
	std::ostringstream o;
	geticonsql(o,pkm,generation);
	getapic(o,picdata,size);
}
EXPORT void GetTypePic_INTERNAL(int type, byte ** picdata, int * size)
{
	std::ostringstream o;
	gettypesql(o,type);
	getapic(o,picdata,size);
}
EXPORT int GetPKMLevel(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	int ret = getpkmlevel(pkm);
	return ret;
}
EXPORT void SetPKMLevel(pokemon_obj * pkm, int level)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->exp = getpkmexpatlevel(pkm->species,level);
}
EXPORT int GetPKMSpeciesID(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return int(pkm->species);
}
EXPORT void SetPKMSpeciesID(pokemon_obj * pkm, int speciesid)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->species = Species::species(speciesid);
}
EXPORT void GetShinyStar_INTERNAL(byte ** picdata, int * size)
{
	std::ostringstream o;
	o << "select image from misc where identifier = \"shiny\"";
	getapic(o,picdata,size);
}
EXPORT void GetGenderPic_INTERNAL(int gender, byte ** picdata, int * size)
{
	std::ostringstream o;
	std::string strgender = "male";
	if(gender == int(Genders::female))
	{
		strgender = "female";
	}
	o << "select image from misc where identifier = \"" + strgender + "\"";
	getapic(o,picdata,size);
}
EXPORT void GetWallpaperImage_INTERNAL(int wallpaper,byte ** picdata, int * size)
{
	std::ostringstream o;
	getwallpapersql(o,wallpaper);
	getapic(o,picdata,size);
}
EXPORT void GetItemImage_INTERNAL(int item,byte ** picdata, int * size)
{
	std::ostringstream o;
	if(((item >= (int)Items::tm01) & (item <= (int)Items::tm92)) | ((item >= (int)Items::tm93) & (item <= (int)Items::tm95)) | ((item >= (int)Items::hm01) & (item <= (int)Items::hm06)))
	{
		std::string mprefix = "tm-";
		if((item >= (int)Items::hm01) & (item <= (int)Items::hm06)){mprefix = "hm-";}
		std::string sql = "select image from items where (identifier = \"" + mprefix + getmachinetypename(Items::items(item)) + "\")";
		o << sql.c_str();
	}
	else if((item >= (int)Items::datacard01) & (item <= (int)Items::datacard27))
	{
		std::string sql = "select image from items where (identifier = \"data-card\")";
		o << sql.c_str();
	}
	else
	{
		getitemsql(o,item);
	}
	getapic(o,picdata,size);
}
EXPORT void GetMarkingImage_INTERNAL(int marking, bool marked,byte ** picdata, int * size)
{
	std::ostringstream o;
	getmarkingsql(o,Markings::markings(marking),marked);
	getapic(o,picdata,size);
}
EXPORT void GetBallPic_INTERNAL(int ball,byte ** picdata, int * size)
{
	std::ostringstream o;
	getballsql(o,Balls::balls(ball));
	getapic(o,picdata,size);
}
EXPORT void GetMoveCategoryImage_INTERNAL(int move,byte ** picdata, int * size)
{
	std::ostringstream o;
	getmovecatsql(o,Moves::moves(move));
	getapic(o,picdata,size);
}
EXPORT void GetPokerusImage_INTERNAL(int strain, int days,byte ** picdata, int * size)
{
	std::ostringstream o;
	if(strain != 0)
	{
		if(days > 0)
		{
			o << "select image from misc where identifier = \"pokerus_infected\"";
		}
		else
		{
			o << "select image from misc where identifier = \"pokerus_cured\"";
		}
	}
	getapic(o,picdata,size);
}
EXPORT void GetRibbonImage_INTERNAL(string ribbon, bool hoenn,byte ** picdata, int * size)
{
	std::ostringstream o;
	o << getribbonsql(ribbon,hoenn);
	getapic(o,picdata,size);
}
EXPORT void FixPokemonChecksum(pokemon_obj * pkm)
{
	calcchecksum(pkm);
}
EXPORT void FixSaveChecksums(bw2sav_obj * sav)
{
	bool isbw2 = savisbw2(sav);
	pokemon_obj * pkm = new pokemon_obj();
	party_pkm * ppkm = new party_pkm();
	for(int partyslot = 0; partyslot < sav->cur.party.size; partyslot++)
	{
		ppkm = &(sav->cur.party.pokemon[partyslot]);
		if(ppkm->ispartydatadecrypted)
		{
			calcchecksum(ppkm);
			encryptpkm(ppkm);
		}
		else if(ppkm->isboxdatadecrypted)
		{
			pkm = ppkm;
			calcchecksum(pkm);
			encryptpkm(pkm);
		}
		else
		{
			decryptpkm(pkm);
			calcchecksum(pkm);
			encryptpkm(pkm);
		}
	}
	calcpartychecksum(&(sav->cur),isbw2);
	for(int box = 0; box < 24; box++)
	{
		for(int slot = 0; slot < 30; slot++)
		{
			pkm = &(sav->cur.boxes[box].pokemon[slot]);
			if(pkm->isboxdatadecrypted)
			{
				calcchecksum(pkm);
				encryptpkm(pkm);
			}
			else
			{
				decryptpkm(pkm);
				calcchecksum(pkm);
				encryptpkm(pkm);
			}
		}
		calcboxchecksum(&(sav->cur),box,isbw2);
	}
	//sav->cur.block1checksum = getchecksum(&(sav->cur),0x0,0x3e0);
	//calcchecksum(&(sav->cur),0x19400,0xB0,0x194B2);
	fixtrainerdatachecksum(&(sav->cur));
	fixsavchecksum(sav,isbw2);
}
EXPORT void WritePokemonFile(pokemon_obj * pkm, const char * filename, bool encrypt = false)
{
	if(pkm->isboxdatadecrypted)
	{
		calcchecksum(pkm);
	}
	else
	{
		decryptpkm(pkm);
		calcchecksum(pkm);
	}
	if(encrypt)
	{
		encryptpkm(pkm);
	}
	write(filename,pkm);
}
EXPORT void WriteSaveFile(bw2sav_obj * sav, const char * filename)
{
	cout << "Eat my heart out!\n";
	FixSaveChecksums(sav);
	write(filename,sav);
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
