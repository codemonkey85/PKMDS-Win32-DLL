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
EXPORT BSTR GetItemName_INTERNAL(int itemid, int generation, int langid)
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
EXPORT int GetBoxWallpaper(bw2sav_obj * sav, int box)
{
	return int(sav->cur.boxwallpapers[box]);
}
EXPORT void SetBoxWallpaper(bw2sav_obj * sav, int box, int wallpaper)
{
	sav->cur.boxwallpapers[box] = Wallpapers::wallpapers(wallpaper);
}
EXPORT uint16 GetTrainerTID_FromSav(bw2sav_obj * sav)
{
	return sav->cur.tid;
}
EXPORT void SetTrainerTID_FromSav(bw2sav_obj * sav, int tid)
{
	sav->cur.tid = tid;
}
EXPORT void SetTrainerSID_FromSav(bw2sav_obj * sav, int sid)
{
	sav->cur.sid = sid;
}
EXPORT uint16 GetTrainerSID_FromSav(bw2sav_obj * sav)
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
EXPORT void GetTypePic_INTERNAL(int type, byte ** picdata, int * size)
{
	std::ostringstream o;
	gettypesql(o,type);
	getapic(o,picdata,size);
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
EXPORT void FixSaveChecksums(bw2sav_obj * sav)
{
	bool isbw2 = savisbw2(sav);
	pokemon_obj * pkm = new pokemon_obj();
	party_pkm * ppkm = new party_pkm();
	for(int partyslot = 0; partyslot < sav->cur.party.size; partyslot++)
	{
		ppkm = &(sav->cur.party.pokemon[partyslot]);
		if(ppkm->isboxdatadecrypted)
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
	sav->cur.block1checksum = getchecksum(&(sav->cur),0x0,0x3e0);
	fixtrainerdatachecksum(&(sav->cur));
	fixbagchecksum(&(sav->cur));
	fixsavchecksum(sav,isbw2);
}
EXPORT void WriteSaveFile(bw2sav_obj * sav, const char * filename)
{
	cout << "Eat my heart out!\n";
	FixSaveChecksums(sav);
	write(filename,sav);
}
EXPORT int GetCurrentBox(bw2sav_obj * sav)
{
	return sav->cur.curbox;
}
EXPORT void SetCurrentBox(bw2sav_obj * sav, int box)
{
	sav->cur.curbox = box;
}
EXPORT int GetPartySize(bw2sav_obj * sav)
{
	return sav->cur.party.size;
}
EXPORT void SetPartySize(bw2sav_obj * sav, int size)
{
	sav->cur.party.size = size;
}
EXPORT void SetBoxName(bw2sav_obj * sav, int box, wchar_t * name, int namelength)
{
	setsaveboxname(sav,box,name,namelength);
}
EXPORT BSTR GetPKMName(int speciesid, int langid)
{
	std::string ret = lookuppkmname(speciesid,langid).c_str();
	return ANSItoBSTR(ret.c_str());
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
EXPORT void GetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	*pokemon = *pkm;
};
EXPORT void GetPartyPKMData_INTERNAL(party_pkm * pokemon, bw2sav_obj * sav, int slot)
{
	party_pkm * pkm = &(sav->cur.party.pokemon[slot]);
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	*pokemon = *pkm;
};
EXPORT void SetPartyPKMData_INTERNAL(party_pkm * pokemon, bw2sav_obj * sav, int slot)
{
	if(!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	calcchecksum(pokemon);
	sav->cur.party.pokemon[slot] = *pokemon;
};
EXPORT void GetPKMDataFromFile_INTERNAL(pokemon_obj * pokemon, const char * filename)
{
	read(filename,pokemon);
};
EXPORT void SetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	if(!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	calcchecksum(pokemon);
	sav->cur.boxes[box].pokemon[slot] = *pokemon;
};
EXPORT BSTR GetPKMName_FromObj(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::string ret = lookuppkmname(pkm);
	return ANSItoBSTR(ret.c_str());
}
EXPORT uint16 GetPKMMoveID(pokemon_obj * pokemon, int moveid)
{
	if(!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	return pokemon->move_ints[moveid];
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
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::ostringstream o;
	getspritesql(o,pkm,generation);
	getapic(o,picdata,size);
}
EXPORT void GetPKMIcon_INTERNAL(pokemon_obj * pkm, byte ** picdata, int * size, int generation)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::ostringstream o;
	geticonsql(o,pkm,generation);
	getapic(o,picdata,size);
}
EXPORT int GetPKMLevel(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return getpkmlevel(pkm);
}
EXPORT void SetPKMLevel(pokemon_obj * pkm, int level)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->exp = getpkmexpatlevel(pkm->species,level);
}
EXPORT uint16 GetPKMSpeciesID(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->species_int;
}
EXPORT void SetPKMSpeciesID(pokemon_obj * pkm, int speciesid)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->species_int = speciesid;
}
EXPORT uint32 GetPKMPID(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pid;
}
EXPORT void SetPKMPID(pokemon_obj * pkm, int pid)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pid = pid;
}
EXPORT uint16 GetPKMItemIndex(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->item_int;
}
EXPORT void SetPKMItemIndex(pokemon_obj * pkm, int item)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->item_int = item;
}
EXPORT uint16 GetPKMTID(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->tid;
}
EXPORT void SetPKMTID(pokemon_obj * pkm, int tid)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = tid;
}
EXPORT uint16 GetPKMSID(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->sid;
}
EXPORT void SetPKMSID(pokemon_obj * pkm, int sid)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = sid;
}
EXPORT uint32 GetPKMEXP(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->exp;
}
EXPORT void SetPKMEXP(pokemon_obj * pkm, int exp)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = exp;
}
EXPORT int GetPKMTameness(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->tameness;
}
EXPORT void SetPKMTameness(pokemon_obj * pkm, int tameness)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = tameness;
}
EXPORT int GetPKMAbilityIndex(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ability_int;
}
EXPORT void SetPKMAbilityIndex(pokemon_obj * pkm, int ability)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ability_int = ability;
}
EXPORT bool GetPKMMarking(pokemon_obj * pkm, int marking)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}

	switch(Markings::markings(marking))
	{
	case Markings::circle:
		return (pkm->markings.circle == true);
		break;
	case Markings::diamond:
		return (pkm->markings.diamond == true);
		break;
	case Markings::heart:
		return (pkm->markings.heart == true);
		break;
	case Markings::square:
		return (pkm->markings.square == true);
		break;
	case Markings::star:
		return (pkm->markings.star == true);
		break;
	case Markings::triangle:
		return (pkm->markings.triangle == true);
		break;
	default:
		return false;
		break;
	}
}
EXPORT void SetPKMMarking(pokemon_obj * pkm, int marking, bool marked)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(Markings::markings(marking))
	{
	case Markings::circle:
		pkm->markings.circle = (marked == true);
		break;
	case Markings::diamond:
		pkm->markings.diamond = (marked == true);
		break;
	case Markings::heart:
		pkm->markings.heart = (marked == true);
		break;
	case Markings::square:
		pkm->markings.square = (marked == true);
		break;
	case Markings::star:
		pkm->markings.star = (marked == true);
		break;
	case Markings::triangle:
		pkm->markings.triangle = (marked == true);
		break;
	}
}
EXPORT int GetPKMLanguage(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->country_int;
}
EXPORT void SetPKMLanguage(pokemon_obj * pkm, int language)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->country_int = language;
}
EXPORT int GetPKMEV(pokemon_obj * pkm, int evindex)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(Stats::stats(evindex))
	{
	case Stats::attack:
		return pkm->evs.attack;
		break;
	case Stats::defense:
		return pkm->evs.defense;
		break;
	case Stats::hp:
		return pkm->evs.hp;
		break;
	case Stats::spatk:
		return pkm->evs.spatk;
		break;
	case Stats::spdef:
		return pkm->evs.spdef;
		break;
	case Stats::speed:
		return pkm->evs.speed;
		break;
	}
}
EXPORT void SetPKMEV(pokemon_obj * pkm, int evindex, int ev)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(Stats::stats(evindex))
	{
	case Stats::attack:
		pkm->evs.attack = ev;
		break;
	case Stats::defense:
		pkm->evs.defense = ev;
		break;
	case Stats::hp:
		pkm->evs.hp = ev;
		break;
	case Stats::spatk:
		pkm->evs.spatk = ev;
		break;
	case Stats::spdef:
		pkm->evs.spdef = ev;
		break;
	case Stats::speed:
		pkm->evs.speed = ev;
		break;
	}
}
EXPORT int GetPKMIV(pokemon_obj * pkm, int ivindex)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(Stats::stats(ivindex))
	{
	case Stats::attack:
		return pkm->ivs.attack;
		break;
	case Stats::defense:
		return pkm->ivs.defense;
		break;
	case Stats::hp:
		return pkm->ivs.hp;
		break;
	case Stats::spatk:
		return pkm->ivs.spatk;
		break;
	case Stats::spdef:
		return pkm->ivs.spdef;
		break;
	case Stats::speed:
		return pkm->ivs.speed;
		break;
	}
}
EXPORT void SetPKMIV(pokemon_obj * pkm, int ivindex, int iv)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(Stats::stats(ivindex))
	{
	case Stats::attack:
		pkm->ivs.attack = iv;
		break;
	case Stats::defense:
		pkm->ivs.defense = iv;
		break;
	case Stats::hp:
		pkm->ivs.hp = iv;
		break;
	case Stats::spatk:
		pkm->ivs.spatk = iv;
		break;
	case Stats::spdef:
		pkm->ivs.spdef = iv;
		break;
	case Stats::speed:
		pkm->ivs.speed = iv;
		break;
	}
}
EXPORT int GetPKMContest(pokemon_obj * pkm, int contestindex)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(ContestStats::conteststats(contestindex))
	{
	case ContestStats::beauty:
		return pkm->contest.beauty;
		break;
	case ContestStats::cool:
		return pkm->contest.cool;
		break;
	case ContestStats::cute:
		return pkm->contest.cute;
		break;
	case ContestStats::sheen:
		return pkm->contest.sheen;
		break;
	case ContestStats::smart:
		return pkm->contest.smart;
		break;
	case ContestStats::tough:
		return pkm->contest.tough;
		break;
	}
}
EXPORT void SetPKMContest(pokemon_obj * pkm, int contestindex, int contest)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch(ContestStats::conteststats(contestindex))
	{
	case ContestStats::beauty:
		pkm->contest.beauty = contest;
		break;
	case ContestStats::cool:
		pkm->contest.cool = contest;
		break;
	case ContestStats::cute:
		pkm->contest.cute = contest;
		break;
	case ContestStats::sheen:
		pkm->contest.sheen = contest;
		break;
	case ContestStats::smart:
		pkm->contest.smart = contest;
		break;
	case ContestStats::tough:
		pkm->contest.tough = contest;
		break;
	}
}
EXPORT int GetPKMMovePP(pokemon_obj * pkm, int move)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pp[move];
}
EXPORT void SetPKMMovePP(pokemon_obj * pkm, int move, int pp)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pp[move] = pp;
}
EXPORT int GetPKMMovePPUp(pokemon_obj * pkm, int move)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ppup[move];
}
EXPORT void SetPKMMovePPUp(pokemon_obj * pkm, int move, int ppup)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ppup[move] = ppup;
}
EXPORT bool GetPKMIsEgg(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->isegg == true;
}
EXPORT void SetPKMIsEgg(pokemon_obj * pkm, bool isegg)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->isegg = isegg;
}
EXPORT bool GetPKMIsNicknamed(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->isnicknamed == true;
}
EXPORT void SetPKMIsNicknamed(pokemon_obj * pkm, bool isnicknamed)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->isnicknamed = isnicknamed;
}
EXPORT bool GetPKMFateful(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->fencounter == true;
}
EXPORT void SetPKMFateful(pokemon_obj * pkm, bool isfateful)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->fencounter = isfateful;
}
EXPORT int GetPKMGender(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return int(calcpkmgender(pkm));
}
EXPORT void SetPKMGender(pokemon_obj * pkm, int gender)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmgender(pkm,gender);
}
EXPORT int GetPKMForm(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->form_int;
}
EXPORT void SetPKMForm(pokemon_obj * pkm, int form)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->form_int = form;
}
EXPORT int GetPKMNature(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->nature_int;
}
EXPORT void SetPKMNature(pokemon_obj * pkm, int nature)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->nature_int = nature;
}
EXPORT bool GetPKMDWAbility(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->hasdwability == true;
}
EXPORT void SetPKMDWAbility(pokemon_obj * pkm, bool hasdwability)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->hasdwability = hasdwability;
}
EXPORT bool GetPKMNsPokemon(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->n_pkm == true;
}
EXPORT void SetPKMNsPokemon(pokemon_obj * pkm, bool isnspokemon)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->n_pkm = isnspokemon;
}
EXPORT BSTR GetPKMNickname(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::wstring nickname = getwstring(pkm->nickname,NICKLENGTH);
	std::string nicknamestr = std::string(nickname.begin(),nickname.end());
	return ANSItoBSTR(nicknamestr.c_str());
}
EXPORT void SetPKMNickname(pokemon_obj * pkm, wchar_t * nickname, int nicknamelength)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmnickname(pkm,nickname,nicknamelength);
}
EXPORT int GetPKMHometown(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->hometown_int;
}
EXPORT void SetPKMHometown(pokemon_obj * pkm, int hometown)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->hometown_int = hometown;
}
EXPORT BSTR GetPKMOTName(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::wstring otname = getwstring(pkm->otname,OTLENGTH);
	std::string otnamestr = std::string(otname.begin(),otname.end());
	return ANSItoBSTR(otnamestr.c_str());
}
EXPORT void SetPKMOTName(pokemon_obj * pkm, wchar_t * otname, int otnamelength)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmotname(pkm,otname,otnamelength);
}
EXPORT int GetPKMEggYear(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.year;
}
EXPORT void SetPKMEggYear(pokemon_obj * pkm, int year)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.year = year;
}
EXPORT int GetPKMEggMonth(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.month;
}
EXPORT void SetPKMEggMonth(pokemon_obj * pkm, int month)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.month = month;
}
EXPORT int GetPKMEggDay(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.day;
}
EXPORT void SetPKMEggDay(pokemon_obj * pkm, int day)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.day = day;
}
EXPORT int GetPKMMetYear(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.year;
}
EXPORT void SetPKMMetYear(pokemon_obj * pkm, int year)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.year = year;
}
EXPORT int GetPKMMetMonth(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.month;
}
EXPORT void SetPKMMetMonth(pokemon_obj * pkm, int month)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.month = month;
}
EXPORT int GetPKMMetDay(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.day;
}
EXPORT void SetPKMMetDay(pokemon_obj * pkm, int day)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.day = day;
}
EXPORT uint16 GetPKMEggLocation(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggmet_int;
}
EXPORT void SetPKMEggLocation(pokemon_obj * pkm, int location)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggmet_int = location;
}
EXPORT uint16 GetPKMMetLocation(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->met_int;
}
EXPORT void SetPKMMetLocation(pokemon_obj * pkm, int location)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->met_int = location;
}
EXPORT int GetPKMPokerusStrain(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pkrs.strain;
}
EXPORT void SetPKMPokerusStrain(pokemon_obj * pkm, int strain)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pkrs.strain = strain;
}
EXPORT int GetPKMPokerusDays(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pkrs.days;
}
EXPORT void SetPKMPokerusDays(pokemon_obj * pkm, int days)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pkrs.days = days;
}
EXPORT int GetPKMBall(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ball_int;
}
EXPORT void SetPKMBall(pokemon_obj * pkm, int ball)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ball_int = ball;
}
EXPORT int GetPKMMetLevel(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metlevel;
}
EXPORT void SetPKMMetLevel(pokemon_obj * pkm, int level)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metlevel = level;
}
EXPORT int GetPKMOTGender(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return int(pkm->otgender);
}
EXPORT void SetPKMOTGender(pokemon_obj * pkm, int gender)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->otgender = Genders::genders(gender);
}
EXPORT int GetPKMEncounter(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->encounter_int;
}
EXPORT void SetPKMEncounter(pokemon_obj * pkm, int encounter)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->encounter_int = encounter;
}
EXPORT bool IsPKMModified(pokemon_obj * pkm)
{
	uint16 chk = pkm->checksum;
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (chk != getchecksum(pkm));
}
EXPORT void FixPokemonChecksum(pokemon_obj * pkm)
{
	if(!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	calcchecksum(pkm);
}
EXPORT bool IsPKMShiny(pokemon_obj * pkm)
{
	return getpkmshiny(pkm) == true;
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
