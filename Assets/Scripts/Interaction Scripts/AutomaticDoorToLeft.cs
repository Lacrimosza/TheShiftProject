using UnityEngine;
using System.Collections;

public class AutomaticDoorToLeft : MonoBehaviour
{
    [SerializeField] Vector3 openOffset = new Vector3(-0.95f, 0f, 0f);
    [SerializeField] float openSpeed = 2f;
    [SerializeField] bool isOpen = false;

    private AutomaticDoorTrigger csADT;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;
    private Coroutine _currentCoroutine;

    void Start()
    {
        csADT = FindFirstObjectByType<AutomaticDoorTrigger>();
        _closedPosition = transform.localPosition;
        _openPosition = _closedPosition + openOffset;
        isOpen = csADT.doorOpen;
    }

    public void Update()
    {
        if (csADT.doorOpen != isOpen)
        {
            isOpen = csADT.doorOpen;
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            _currentCoroutine = StartCoroutine(ToggleDoor());
        }
    }

    private IEnumerator ToggleDoor()
    {
        Vector3 targetPosition = csADT.doorOpen ? _openPosition : _closedPosition;

        while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                targetPosition,
                Time.deltaTime * openSpeed
            );

            yield return null;
        }

        transform.localPosition = targetPosition;
    }
}