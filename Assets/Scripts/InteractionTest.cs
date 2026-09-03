using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    private bool isOpen;
    public void Interact()
    {
        if(isOpen == false)
        {
            //Kapıyı Aç
            transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            isOpen = true;
        }
        else
        {
            //Kapıyı Aç
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            isOpen = false;
        }
    }
    
}
