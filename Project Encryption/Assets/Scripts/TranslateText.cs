using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateText : MonoBehaviour
{
    //Variables
    public string key;
    public Text textTranslate;

    // Start is called before the first frame update
    void Start()
    {
        string value = Localization.GetLocalizedTranslation(key);
        textTranslate.text = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
