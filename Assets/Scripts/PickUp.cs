using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    private Inventory inv;
    private void Start()
    {
        inv = FindFirstObjectByType<Inventory>();
    }
    public void Interact()
    {
        Destroy(gameObject);
        inv.doorKey_01 = true;
    }
}
