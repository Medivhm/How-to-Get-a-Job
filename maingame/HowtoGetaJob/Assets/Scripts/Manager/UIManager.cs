using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public struct UIInfo
    {
        public string prefabPath;
        public GameObject Instance;
    }

    Dictionary<Type, UIInfo> UIResources = new Dictionary<Type, UIInfo>();

    void Start()
    {
        Instance = this;
        UIResources.Add(typeof(UIBag), new UIInfo() { prefabPath = "Prefabs/UI/Bag" });
        UIResources.Add(typeof(UICharacter), new UIInfo() { prefabPath = "Prefabs/UI/Character" });
    }

    public T Show<T>()
    {
        if (UIResources.TryGetValue(typeof(T), out UIInfo ui))
        {
            if (ui.Instance != null)
            {
                ui.Instance.gameObject.SetActive(true);
            }
            else
            {
                GameObject go = (GameObject)Resources.Load(ui.prefabPath);
                if (go == null)
                {
                    return default(T);
                }
                ui.Instance = GameObject.Instantiate(go);
                UIResources[typeof(T)] = new UIInfo() { prefabPath = ui.prefabPath, Instance = ui.Instance };
            }
            T uiLogic = ui.Instance.GetComponent<T>();
            return uiLogic;
        }
        return default(T);
    }
}