using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour
{
    public delegate void CloseHandle();
    public event CloseHandle OnClose;

    private void Start()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public virtual void Init()
    {

    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        if (OnClose != null)
        {
            OnClose.Invoke();
        }
    }


}