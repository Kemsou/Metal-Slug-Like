using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour {
    
    public MultiDimensionalString[] ennemisArray;


    private const int SIZE_ELEMENT = 3;

    // Use this for initialization
    void Start () {
        ennemisArray = new MultiDimensionalString[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnValidate()
    {
        foreach (MultiDimensionalString ennemi in ennemisArray)
        {
            if (ennemi.StringArray.Length != 3)
            {
                Debug.LogWarning("Don't change the 'Element' field's array size!");
                //Array.Resize(ennemi.StringArray, 3);
                
            }
        }
    }
}


