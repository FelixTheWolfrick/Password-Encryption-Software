using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    //Languages
    public enum Language
    {
        English,
        Spanish
    }

    //Default
    public static Language language = Language.English;

    //Variables
    private static Dictionary<string, string> localizedEN;
    private static Dictionary<string, string> localizedES;
    public static bool isInit;

    // Start is called before the first frame update
    //void Start() { }

    //Init
    public static void Init()
    {
        //Initialize CSV
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        //Organize Translation Options
        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedES = csvLoader.GetDictionaryValues("es");

        //Verify Values Loaded
        isInit = true;
    }

    //Get Translation
    public static string GetLocalizedTranslation(string key)
    {
        //Init if haven't
        if (!isInit) { Init(); }

        //Variables
        string value = key;

        //Get Proper Translation
        switch (language)
        {
            case Language.English:
                localizedEN.TryGetValue(key, out value);
                break;
            case Language.Spanish:
                localizedES.TryGetValue(key, out value);
                break;
        }

        //Return
        return value;
    }

    // Update is called once per frame
    //void Update() { }
}
