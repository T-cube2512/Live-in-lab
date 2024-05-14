using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question;
    public Choice[] choices;

    [System.Serializable]
    public class Choice
    {
        public string choiceString;
        public bool choiceValue;
    }
}
