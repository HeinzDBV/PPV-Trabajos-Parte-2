using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonNPC : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color charmanderColor = Color.red;
    [SerializeField] private Color bulbasaurColor = Color.green;
    [SerializeField] private Color squirtleColor = Color.blue;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtenemos el valor de la VariableGlobal PokemonName
        string pokemonName = (
            (Ink.Runtime.StringValue) DialogueManager
            .Instance
            .GetVariableState("pokemon_name")
            ).value;

        switch (pokemonName)
        {
            case "Charmander":
                spriteRenderer.color = charmanderColor;
                break;
            case "Bulbasaur":
                spriteRenderer.color = bulbasaurColor;
                break;
            case "Squirtle":
                spriteRenderer.color = squirtleColor;
                break;
            case "":
                spriteRenderer.color = defaultColor;
                break;
            default:
                Debug.Log("El valor de la Varible es uno No esperado");
                break;

        }
    }
}
