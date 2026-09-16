using UnityEngine;

    interface IInteractable
    {
        public void Interact();
    }
public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                IInteractable interactObj = hitInfo.collider.GetComponentInParent<IInteractable>();

                if (interactObj != null)
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
