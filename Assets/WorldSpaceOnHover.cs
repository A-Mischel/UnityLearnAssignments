using UnityEngine;
using UnityEngine.EventSystems;

public class WorldSpaceOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    // Create an event based on the delegate

    // Called when the pointer enters the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered " + gameObject.name);
        // Add custom hover behavior here, e.g., change color
        GetComponent<Renderer>().material.color = Color.green;
    }

    // Called when the pointer exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exited " + gameObject.name);
        // Reset behavior here
        GetComponent<Renderer>().material.color = Color.white;
    }
}