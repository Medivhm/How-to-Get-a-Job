using System.Collections;
using UnityEngine;


public class UIBag : UIBase
{
    public GameObject BagItemPrefab;
    public Transform slotsRoot;

    override public void Init()
    {
        // Test
        for (int i = 0; i < 15; i++)
        {
            GameObject item = GameObject.Instantiate(BagItemPrefab, slotsRoot);
            item.GetComponent<UIBagItem>().Init();
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
