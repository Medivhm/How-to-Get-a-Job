using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform UIArea;
    public RectTransform Bg;



    void Update()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Vector2 pos;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(Bg, eventData.position, eventData.enterEventCamera, out pos);
        //UIArea.localPosition = pos - diff;
        float multi = Bg.rect.width / Screen.width;
        UIArea.localPosition += new Vector3(eventData.delta.x * multi, eventData.delta.y * multi, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}