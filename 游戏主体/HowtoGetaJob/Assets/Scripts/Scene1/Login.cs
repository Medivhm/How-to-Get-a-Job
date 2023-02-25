using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField account;
    public InputField password;
    public Button startBtn;
    public Button helpAccBtn;
    public Button helpPwdBtn;
    public GameObject accHelpInfoGo;
    public GameObject pswHelpInfoGo;
    public GameObject checkBoxGo;
    string date;
    string curAcc;
    string curPsw;


    bool helpAccBtnClicked;
    bool helpPwdBtnClicked;
    bool checkBoxBtnClicked;

    void Start()
    {
        // 账号密码正确答案设置
        date = DateTime.Today.ToString("yyyyMMdd");
        curAcc = date;
        char[] arr = date.ToCharArray();
        Array.Reverse<char>(arr);
        curPsw = arr.ToString();

        //初始化
        helpAccBtnClicked = false;
        helpPwdBtnClicked = false;
        checkBoxBtnClicked = false;
    }

    void Update()
    {

    }

    public void HelpAccBtnOnClick()
    {
        if (!helpAccBtnClicked)
        {
            helpAccBtnClicked = true;
            StartCoroutine(DoAccBtnClick());
        }
        helpAccBtnClicked = false;
    }

    public void HelpPwdBtnOnClick()
    {
        if (!helpPwdBtnClicked)
        {
            helpPwdBtnClicked = true;
            StartCoroutine(DoPwdBtnClick());
        }
        helpPwdBtnClicked = false;
    }

    public void CheckBoxBtnOnClick()
    {
        checkBoxBtnClicked = !checkBoxBtnClicked;
        Sprite sprite;
        if (checkBoxBtnClicked)
        {
            sprite = Resources.Load("arts/smallIcon/checkYes1") as Sprite;
        }
        else
        {
            sprite = Resources.Load("arts/smallIcon/checkNo1") as Sprite;
        }
        checkBoxGo.GetComponent<Image>().sprite = sprite;
        HandMove();
    }

    void HandMove()
    {

    }

    public void StartBtnOnClick()
    {
        Debug.Log(account.text + "  |  " + password.text);
        if(account.text.Equals(curAcc) && password.text.Equals(curPsw))
        {
            GotoNextScene();
            Debug.Log("Scene1 is over");
        }
    }

    public IEnumerator DoAccBtnClick()
    {
        accHelpInfoGo.SetActive(true);
        yield return new WaitForSeconds(3);
        accHelpInfoGo.SetActive(false);
    }

    public IEnumerator DoPwdBtnClick()
    {
        pswHelpInfoGo.SetActive(true);
        yield return new WaitForSeconds(3);
        pswHelpInfoGo.SetActive(false);
    }





    void GotoNextScene()
    {

    }
}
