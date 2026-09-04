using UnityEngine;
using TMPro;

public class FPSViewer : MonoBehaviour
{
    public TMP_Text fpsText;

    private float deltaTime;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float fps = 1f / deltaTime;

        fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
    }
}