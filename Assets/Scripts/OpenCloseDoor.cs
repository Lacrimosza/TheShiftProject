using UnityEngine;

public class OpenCloseDoor : MonoBehaviour , IInteractable
{
    private Inventory inv;
    private bool isOpen;
    private void Start()
    {
        inv = FindFirstObjectByType<Inventory>();
    }
    public void Interact()
    {
        if (isOpen == false)
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
