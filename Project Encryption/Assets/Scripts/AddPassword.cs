using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AddPassword : MonoBehaviour
{
    //Variables
    public List<string> accountList;
    public List<string> passwordList;
    public GameObject accountInput;
    private string[] lettersLower = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    private string[] lettersUpper = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    private string[] symbols = { "!", "?", ":", ";", "*", "#", "@", "%", "$", "^", "&", "(", ")", "+", "=", "~", "'" };
    public GameObject accountPasswordDisplay;
    private int passwordStrength = 0;
    public GameObject passwordStrengthDisplay;

    // Start is called before the first frame update
    //void Start() { }

    //Store New Account
    public void StoreNewAccount()
    {
        accountList.Add(accountInput.GetComponent<Text>().text);
    }

    //Different Password Variations
    public string Letters()
    {
        //Variables
        string letterAddOn;
        int location = 0;
        int lowerUpper = -1;

        //Get Random Values
        for (int i = 0; i < 10; i++)
        {
            location = Random.Range(0, lettersLower.Length - 1);
            lowerUpper = Random.Range(0, 1);
        }

        //Assign Value
        if (lowerUpper == 0)
        {
            letterAddOn = lettersLower[location];
        }
        else
        {
            letterAddOn = lettersUpper[location];
        }

        //Return
        passwordStrength = passwordStrength + 1;
        return letterAddOn;
    }

    public string Numbers()
    {
        //Variables
        string numberAddOn;
        int location = 0;

        //Get Random Values
        for (int i = 0; i < 10; i++)
        {
            location = Random.Range(0, numbers.Length - 1);
        }

        //Assign Value
        numberAddOn = numbers[location];

        //Return
        passwordStrength = passwordStrength + 1;
        return numberAddOn;
    }

    public string Symbols()
    {
        //Variables
        string symbolsAddOn;
        int location = 0;

        //Get Random Values
        for (int i = 0; i < 10; i++)
        {
            location = Random.Range(0, symbols.Length - 1);
        }

        //Assign Value
        symbolsAddOn = symbols[location];

        //Return
        passwordStrength = passwordStrength + 1;
        return symbolsAddOn;
    }

    //Generate Password
    public void GeneratePassword()
    {
        //Variables
        int passwordCase = -1; //1 - LNS, 2 - LN, 3 - LS, 4 - NS, 5 - L, 6 - N, 7 - S
        int randomValue = 0;
        int counter = 0;
        string tempPass = "";

        //Get Password Requirements
        if (GetComponent<PasswordVariation>().letters)
        {
            if (GetComponent<PasswordVariation>().numbers && GetComponent<PasswordVariation>().symbols)
            {
                passwordCase = 1;
            }
            else if(GetComponent<PasswordVariation>().numbers && !GetComponent<PasswordVariation>().symbols)
            {
                passwordCase = 2;
            }
            else if(!GetComponent<PasswordVariation>().numbers && GetComponent<PasswordVariation>().symbols)
            {
                passwordCase = 3;
            }
            else if(!GetComponent<PasswordVariation>().numbers && !GetComponent<PasswordVariation>().symbols)
            {
                passwordCase = 5;
            }
        }
        else if (GetComponent<PasswordVariation>().numbers)
        {
            if(GetComponent<PasswordVariation>().symbols)
            {
                passwordCase = 4;
            }
            else
            {
                passwordCase = 6;
            }
        }
        else if(GetComponent<PasswordVariation>().symbols)
        {
            passwordCase = 7;
        }

        //Generate Password
        while (counter < GetComponent<PasswordVariation>().length)
        {
            //Get Random Value
            randomValue = Random.Range(0, 100);

            //Generate Value
            switch (passwordCase)
            {
                case 1: //3
                    if(randomValue <= 34)
                    {
                        tempPass = tempPass + Letters();
                    }
                    else if(randomValue >= 35 && randomValue <= 66)
                    {
                        tempPass = tempPass + Numbers();
                    }
                    else if(randomValue >= 67)
                    {
                        tempPass = tempPass + Symbols();
                    }
                    break;
                case 2: //2
                    if(randomValue < 50)
                    {
                        tempPass = tempPass + Letters();
                    }
                    else if(randomValue >= 50)
                    {
                        tempPass = tempPass + Numbers();
                    }
                    break;
                case 3: //2
                    if (randomValue < 50)
                    {
                        tempPass = tempPass + Letters();
                    }
                    else if (randomValue >= 50)
                    {
                        tempPass = tempPass + Symbols();
                    }
                    break;
                case 4: //2
                    if (randomValue < 50)
                    {
                        tempPass = tempPass + Numbers();
                    }
                    else if (randomValue >= 50)
                    {
                        tempPass = tempPass + Symbols();
                    }
                    break;
                case 5: //1
                    tempPass = tempPass + Letters();
                    break;
                case 6: //1
                    tempPass = tempPass + Numbers();
                    break;
                case 7: //1
                    tempPass = tempPass + Symbols();
                    break;
            }
            counter++;
        }

        //Assign Password
        passwordList.Add(tempPass);
        PasswordStrength();
    }

    //Calculate Password Strength
    public void PasswordStrength()
    {
        //Reset Password Strength
        passwordStrength = 0;

        if(passwordStrength <= 8)
        {
            passwordStrengthDisplay.GetComponent<Text>().text = "Weak";
        }
        else if(passwordStrength > 8 && passwordStrength <= 18)
        {
            passwordStrengthDisplay.GetComponent<Text>().text = "Good";
        }
        else if(passwordStrength > 19)
        {
            passwordStrengthDisplay.GetComponent<Text>().text = "Strong";
        }
    }

    //Display Password
    public void DisplayPassword()
    {
        //Variables
        int passwordListLength;

        //Get List Length
        passwordListLength = passwordList.Count;

        //Functions
        StoreNewAccount();
        GeneratePassword();
        accountPasswordDisplay.GetComponent<Text>().text = passwordList.ElementAt(passwordListLength);
    }

    // Update is called once per frame
    //void Update() { }
}
