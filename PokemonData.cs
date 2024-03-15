using UnityEngine;

public class PokemonData : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string pokemonName = "";
    [SerializeField] int pokemonBaseHP = 0;
    private int pokemonCurrentHP = 0;
    [SerializeField] int pokemonAttack = 0;
    [SerializeField] int pokemonDefense = 0;
    private int pokemonSP = 0;
    [SerializeField] float pokemonWeight = 0f;
    [SerializeField]
    enum Types
    {
        fire,
        water,
        grass,
        steel,
        normal,
        flying,
        poison,
        insect,
        dark,
        fairy,
        dragon,
        ghost,
        bug,
        ice,
        psychic,
        rock,
        ground
    }

    [SerializeField] Types types = Types.fire;

    [SerializeField] string[] pokemonWeaknesses = { "", "" };
    [SerializeField] string[] pokemonStrenghts = { "", "" };

    private void Awake()
    {
        InitCurrentLife();
        InitStatsPoints();
    }

    void Start()
    {
        DisplayName();
        DisplayBaseHP();
        DisplayTypes();
        DisplayWeaknesses();
        DisplayStrenghts();
        DisplayAttack();
        DisplayDefense();
        DisplayWeight();
        DisplaySP();
        DisplayCurrentHP();

        TakeDamage(35, "poison");

        CheckIfPokemonAlive();  
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* The Function Display is used to show the Pokemon's stat in the Console*/
    private void DisplayName()
    {
        string debugName = pokemonName;
        Debug.Log("Pokemon' name: " + debugName);
    }

    private void DisplayBaseHP()
    {
        int debugBaseHP = pokemonBaseHP;
        Debug.Log("Pokemon's Base HP: " + debugBaseHP);
    }

    private void DisplayCurrentHP()
    {
        int debugCurrentHP = pokemonCurrentHP;
        Debug.Log("Pokemon's current HP: " + debugCurrentHP);
    }

    private void DisplayAttack()
    {
        int debugAttack = pokemonAttack;
        Debug.Log("Pokemon's attack: " + debugAttack);
    }

    private void DisplayDefense()
    {
        int debugDefense = pokemonDefense;
        Debug.Log("Pokemon's defense: " + debugDefense);
    }

    private void DisplaySP()
    {
        int debugSP = pokemonSP;
        Debug.Log("Pokemon's stats points: " + debugSP);
    }

    private void DisplayWeight()
    {
        float debugWeight = pokemonWeight;
        Debug.Log("Pokemon's weight: " + debugWeight);
    }

    private void DisplayTypes()
    {
        Types debugType = types;
        Debug.Log("Pokemon's type: " + debugType);
    }

    private void DisplayWeaknesses()
    {
        for (int i = 0; i < pokemonWeaknesses.Length; i++)

        {
            string debugWeaknesses = pokemonWeaknesses[i];
            Debug.Log("Pokemon's weaknesses: " + debugWeaknesses);
        }

    }

    private void DisplayStrenghts()
    {
        for (int i = 0; i < pokemonStrenghts.Length; i++)

        {
            string debugStrenghts = pokemonStrenghts[i];
            Debug.Log("Pokemon's strenghts: " + debugStrenghts);
        }

    }

  /*The function InitCurrentLife is used to initiate the Pokemon's current HP to the base HP*/
    private void InitCurrentLife()
    {
        pokemonCurrentHP = pokemonBaseHP;
        Debug.Log("Pokemon's current HP is " + pokemonCurrentHP);
    }
    
    /*The function InitStatsPoints is used to initiate the Pokemon's stats points*/
    
    private void InitStatsPoints()
    {
        pokemonSP += pokemonBaseHP + pokemonAttack + pokemonDefense;
        Debug.Log("Pokemon's current stats points is " + pokemonSP);
    }

    /*The function GetAttackDamage is used to return the Pokemon attack value*/

    private int GetAttackDamage()
    {
        return pokemonAttack;
    }
    /*The function TakeDamage is used to calculate the damage inflicted to the Pokemon*/

    private void TakeDamage(int damage, string ennemyTypes)
    {
        

        for (int i = 0; i < pokemonWeaknesses.Length; i++)
        {
            if (ennemyTypes == pokemonWeaknesses[i])
            {
                damage *= 2;
                continue;
            }
        }
        
        for (int i = 0; i < pokemonStrenghts.Length ; i++)
        {
            if (ennemyTypes == pokemonStrenghts[i])
            {
                damage /= 2; 
                continue;
            }
        }
        
        if (damage <= 0) 
        {
            Debug.Log("The attack didn't do damage");
            return;
        }
        
        pokemonCurrentHP -= damage;
        Debug.Log("This Pokemon has " + pokemonCurrentHP + " hps");       
    
    }

    /*The function CheckIfPokemonAlice is used to check if our Pokemon is either alive or KO using an if statement*/

    private void CheckIfPokemonAlive()
    {
        if (pokemonCurrentHP > 0)
        {
            Debug.Log("The Pokemon is still alive");
        } else
        {
            Debug.Log("The Pokemon is KO");
        }
    }
}
