using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    [SerializeField] private bool doorLocked = false;
    public bool doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Kapı açıldı loo");
            doorOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Kapı kapandı loo");
            doorOpen = false;
        }
    }
}
