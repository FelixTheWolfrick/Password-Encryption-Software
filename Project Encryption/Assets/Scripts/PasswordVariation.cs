using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordVariation : MonoBehaviour
{
    //Variables
    public bool letters;
    public bool numbers;
    public bool symbols;
    public int length;
    public GameObject lengthInput;

    // Start is called before the first frame update
    //void Start() { }

    //Get Length
    public void PasswordLength()
    {
        length = System.Convert.ToInt32(lengthInput.GetComponent<Text>().text);
    }

    //Get Requirements
    public void AddLetters()
    {
        if(!letters)
        {
            letters = true;
        }
        else
        {
            letters = false;
        }
    }

    public void AddNumbers()
    {
        if (!numbers)
        {
            numbers = true;
        }
        else
        {
            numbers = false;
        }
    }

    public void AddSymbols()
    {
        if(!symbols)
        {
            symbols = true;
        }
        else
        {
            symbols = false;
        }
    }

    // Update is called once per frame
    //void Update() { }
}
