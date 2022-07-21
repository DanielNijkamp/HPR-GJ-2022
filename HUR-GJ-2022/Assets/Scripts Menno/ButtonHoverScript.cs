using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;



public class ButtonHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    SoundManagerScript soundmanager;
    private void Start()
    {
        soundmanager = FindObjectOfType<SoundManagerScript>();
    }
    public void OnPointerEnter(PointerEventData ped)
    {
        soundmanager.MouseOverButton();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        soundmanager.ButtonPressed();
    }
}