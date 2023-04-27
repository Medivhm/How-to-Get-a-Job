using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    public void OnBagClick()
    {
        UIBag bag = UIManager.Instance.Show<UIBag>();
        bag.Init();
    }

    public void OnCharacterClick()
    {
        UICharacter character = UIManager.Instance.Show<UICharacter>();
        character.Init();
    }

    public void OnGetClick()
    {
        CheckItems check = Player.Instance.gameObject.GetComponent<CheckItems>();
        check.GetItem();
    }

    public void OnThrowClick()
    {

    }
}
