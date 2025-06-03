using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVariables : MonoBehaviour
{

    private static SaveVariables instance;

    public int lealtadTomasso;
    public int lealtadMiss;
    public int lealtadMr;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager");
        }
        instance = this;
        
    }

    public static SaveVariables GetInstance()
    {

        return instance;
    }
    private void Start()
    {
        lealtadTomasso = ((IntValue)DialogManager.GetInstance().GetVariableState("Tomasso_Loyalty")).value;
        lealtadMiss = ((IntValue)DialogManager.GetInstance().GetVariableState("MissDisfortune_Loyalty")).value;
        lealtadMr = ((IntValue)DialogManager.GetInstance().GetVariableState("MrDisfortune_Loyalty")).value;
        DontDestroyOnLoad(gameObject);
    }
}
