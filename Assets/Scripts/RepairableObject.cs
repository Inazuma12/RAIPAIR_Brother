using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : PickableObject
{
    [SerializeField] private RepairRecipe baseRecipe;
    private List<int> _recipeToDo;

    public List<int> RecipeToDo => _recipeToDo;

    // Start is called before the first frame update
    void Start()
    {
        _recipeToDo = new List<int>() { 0,0,0};
        if (Random.value > 0.5)
        {
            _recipeToDo[0] = (int)baseRecipe.Item1;
            _recipeToDo[1] = (int)baseRecipe.Item2;
            _recipeToDo[2] = (int)baseRecipe.Item3;
        }
        else
        {
            float random;
            for (int i = 0; i < 3; i++)
            {
                random = Random.value;
                if (random < baseRecipe.Item1Probability) _recipeToDo[i] = (int)baseRecipe.Item1;
                else if (random < baseRecipe.Item2Probability) _recipeToDo[i] = (int)baseRecipe.Item2;
                else if (random < baseRecipe.Item3Probability) _recipeToDo[i] = (int)baseRecipe.Item3;
            }
        }

        Debug.Log(RecipeToDo[0]);
        Debug.Log(RecipeToDo[1]);
        Debug.Log(RecipeToDo[2]);
    }
    

}
