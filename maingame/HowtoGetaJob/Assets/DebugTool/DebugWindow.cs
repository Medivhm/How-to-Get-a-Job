using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DebugWindow : MonoBehaviour
{
    public static DebugWindow LogTool;
    private Text text;

    private void Start()
    {
        text = this.transform.GetChild(0).GetComponent<Text>();
        LogTool = this;
    }

    public void Log(string debugMsg)
    {
        text.text += text.text + "\n" + debugMsg;
    }
}
