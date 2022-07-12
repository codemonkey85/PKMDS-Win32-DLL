namespace PKMDS_CS;

public class Party : ObservableCollection<PartyPokemon>
{
    public Party()
    {

    }
    public void RecalculateParty()
    {
        if (Count > 0)
        {
            foreach (var ppkm in this)
            {
                try
                {
                    var appkm = new PartyPokemon();
                    appkm.PokemonData.Data = ppkm.PokemonData.Data;
                    RecalcPartyPKM(appkm);
                    ppkm.PokemonData.Data = appkm.PokemonData.Data;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
