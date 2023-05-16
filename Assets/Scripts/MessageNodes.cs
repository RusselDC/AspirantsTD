using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageNodes : MonoBehaviour
{   

    public Text text;
    public void DisplayText(string mess, Color color)
    {
        text.text = mess;
        text.color = color;
        Invoke("removeText",3f);
    }

    private void removeText()
    {
        text.text = "";
    }
}
