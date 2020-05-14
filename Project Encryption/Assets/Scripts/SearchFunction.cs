using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchFunction : MonoBehaviour
{
    //Variables
    public string accountSearch;
    public string accountPassword;
    public GameObject searchInput;
    public GameObject accountDisplay;
    public GameObject passwordDisplay;

    // Start is called before the first frame update
    //void Start() { }


    //Get Password for Account
    public void AccountPassword()
    {
        //Get account user is looking for
        accountSearch = searchInput.GetComponent<Text>().text;

        //Get password to that account
        accountPassword = "tempPassTester34!";

        //Display account along with corresponding password
        accountDisplay.GetComponent<Text>().text = accountSearch;
        passwordDisplay.GetComponent<Text>().text = accountPassword;
    }

    // Update is called once per frame
    //void Update(){}
}
