using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2ButtonText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        if(Player.Instance.Rule == MoveRule.Fly)
        {
            Player.Instance.Rule = MoveRule.Walk;
            text.text = "二维行走";
        }
        else if (Player.Instance.Rule == MoveRule.Walk)
        {
            Player.Instance.Rule = MoveRule.Fly;
            text.text = "一维行走";
        }
    }
}
