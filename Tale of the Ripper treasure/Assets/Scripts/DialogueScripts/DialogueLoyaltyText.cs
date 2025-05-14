using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLoyaltyText : MonoBehaviour
{
    [Header ("LoyaltyText")] 
    [SerializeField] TextMeshProUGUI LoyaltyText;

    
    void Update()
    {
        switch (tag)
        {
            case "Tomasso":
                var tomasso = DialogManager.GetInstance().GetVariableState("Tomasso_Loyalty");
                LoyaltyText.text = "Lealtad Tomasso: " + tomasso.ToString();
                break;
            case "Miss":
                var missDisfortune = DialogManager.GetInstance().GetVariableState("MissDisfortune_Loyalty");
                LoyaltyText.text = "Lealtad MissDisfortune: " + missDisfortune.ToString();
                break;
        }
    }
}
