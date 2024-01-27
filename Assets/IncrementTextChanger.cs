using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IncrementTextChanger : MonoBehaviour
{
    public List<string> textList = new List<string>();
    public TMP_Text text;
    public int index = 0;
    public void IncrementList()
    {
        index++;
        if (index < textList.Count)
        {         
            text.text = textList[index];
        }
        else
        {
            index = 0;
            text.text = textList[index];
        }
    }
}
