using Ink.Runtime;
using TMPro;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [SerializeField] private TextMeshProUGUI finaltext;

    [SerializeField] GameObject goodship;
    [SerializeField] GameObject badshipp;

    private DialogueVariables dialogueVariables;

    private int loyaltyT;
    private int loyaltyMiss;
    private int loyaltyMr;
    private int finalLoyalty;

    private void Awake()
    {
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }
    private void Update()
    {
        loyaltyT = SaveVariables.GetInstance().lealtadTomasso;
        loyaltyMiss = SaveVariables.GetInstance().lealtadMiss;
        loyaltyMr = SaveVariables.GetInstance().lealtadMr;
        finalLoyalty = loyaltyMiss + loyaltyMr + loyaltyT;
        if ( finalLoyalty >= 150)
        {
            goodship.SetActive(true);
            badshipp.SetActive(false);
            finaltext.text = "¡¡Has Encontrado el tesoro!!";
            finaltext.color = Color.yellow;
            
        }
        else
        {
            goodship.SetActive(false);
            badshipp.SetActive(true);
            finaltext.text = "¡¡Te Han traicionado!!";
            finaltext.color = Color.red;
        }
    }
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("A" + variableName);
        }
        return variableValue;
    }
}
