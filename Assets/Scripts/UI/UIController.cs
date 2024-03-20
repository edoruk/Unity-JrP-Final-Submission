using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _usageText;
    private string _usageTextBase = "Press E to ";
    
    // Start is called before the first frame update
    void Start()
    {
        _usageText.text = _usageTextBase;
        _usageText.enabled = false;
    }

    public void SetUsageText(string verb, Collider other)
    {
        _usageText.text += verb + other.gameObject.name;
        _usageText.enabled = true;
    }

    public void ResetUsageText()
    {
        _usageText.SetText(_usageTextBase);
        _usageText.enabled = false;
    }
}
