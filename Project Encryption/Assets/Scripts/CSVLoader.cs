using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    //Variables
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surroundWord = '"';
    private string[] fieldSeperator = {"\",\""};

    // Start is called before the first frame update
    //void Start() { }

    //Load Translations
    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localization");
    }

    //Translation Dictionary
    public Dictionary<string, string> GetDictionaryValues(string attributeID)
    {
        //Set-Up Dictionary
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        //Variables
        string[] lines = csvFile.text.Split(lineSeperator);
        int attributeIndex = -1;
        string[] headers = lines[0].Split(fieldSeperator, StringSplitOptions.None);

        //Get Translation Index
        for(int i = 0; i < headers.Length; i++)
        {
            if(headers[i].Contains(attributeID))
            {
                attributeIndex = i;
                break;
            }
        }

        //Parse File
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for(int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);

            for(int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surroundWord);
                fields[f] = fields[f].Replace(surroundWord.ToString(), "");
            }

            if (fields.Length > attributeIndex)
            {
                var key = fields[0];

                if (dictionary.ContainsKey(key)) { continue; }

                var value = fields[attributeIndex];
                dictionary.Add(key, value);
            }
        }

        //Return Translation
        return dictionary;
    }

    // Update is called once per frame
    //void Update() { }
}
