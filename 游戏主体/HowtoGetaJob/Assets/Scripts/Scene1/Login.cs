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
    public GameObject sealGo;
    string date;
    string curAcc;
    string curPsw;


    bool helpAccBtnClicked;
    bool helpPwdBtnClicked;
    bool checkBoxBtnClicked;

    GraphicRaycaster gr;

    void Start()
    {
        // 账号密码正确答案设置
        date = DateTime.Today.ToString("yyyyMMdd");
        curAcc = date;
        curPsw = Revert(date.ToCharArray());

        //初始化
        helpAccBtnClicked = false;
        helpPwdBtnClicked = false;
        checkBoxBtnClicked = false;

        gr = this.transform.parent.gameObject.GetComponent<GraphicRaycaster>();
    }

    string Revert(char[] charArray)
    {
        char[] arr = charArray;
        for (int i = 0,j = arr.Length - 1; i < j; i++, j--)
        {
            char temp;
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        return new string(arr);
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

    void ChangeInteraction(bool state)
    {
        gr.enabled = state;
    }

    public void CheckBoxBtnOnClick()
    {
        ChangeInteraction(false);
        checkBoxBtnClicked = !checkBoxBtnClicked;
        Sprite sprite;
        Texture2D texture;
        if (checkBoxBtnClicked)
        {
            texture = Resources.Load("arts/smallIcon/checkYes1") as Texture2D;
        }
        else
        {
            texture = Resources.Load("arts/smallIcon/checkNo1") as Texture2D;
        }
        sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        checkBoxGo.GetComponent<Image>().sprite = sprite;
        if (checkBoxBtnClicked)
        {
            StartCoroutine(SealMoveOut());
        }
        else
        {
            StartCoroutine(SealMoveBack());
        }
    }

    IEnumerator SealMoveOut()
    {
        //封条出来
        Transform trans = sealGo.transform;
        while(trans.localPosition.x > -338)
        {
            sealGo.transform.Translate(Vector3.left * 800 * Time.deltaTime);
            yield return null;
        }
        trans.localPosition = new Vector3(-338, trans.localPosition.y, 0);
        ChangeInteraction(true);
    }

    IEnumerator SealMoveBack()
    {
        //封条回去
        Transform trans = sealGo.transform;
        while (trans.localPosition.x < 812)
        {
            sealGo.transform.Translate(Vector3.right * 800 * Time.deltaTime);
            yield return null;
        }
        trans.localPosition = new Vector3(812, trans.localPosition.y, 0);
        ChangeInteraction(true);
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
