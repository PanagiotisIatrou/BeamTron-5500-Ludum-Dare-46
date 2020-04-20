using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip HoverClip;
    public AudioClip ClickClip;

    public void OnPointerEnter(PointerEventData ped)
    {
        AudioSource.PlayClipAtPoint(HoverClip, Camera.main.transform.position);
    }

    public void OnPointerClick(PointerEventData ped)
    {
        AudioSource.PlayClipAtPoint(ClickClip, Camera.main.transform.position, 0.7f);
    }
}
