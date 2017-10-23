using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiDimensionalString
{
    private string[] stringArray;
    public string name;

    public MultiDimensionalString()
    {
        StringArray = new string[3];
    }

    public string[] StringArray
    {
        get
        {
            return stringArray;
        }

        set
        {
            stringArray = value;
        }
    }
}
