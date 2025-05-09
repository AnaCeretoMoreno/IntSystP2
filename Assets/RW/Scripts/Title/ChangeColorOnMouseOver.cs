using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model; 
    public Color normalColor; 
    public Color hoverColor; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model.material.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        model.material.color = normalColor;
    }

}
