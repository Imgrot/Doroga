using UnityEngine;

public class handleCamera : MonoBehaviour
{
    // private float targetAspect = 1366f / 768f;
    void Start()
    {
        // AjustarCamara();
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    // void AjustarCamara()
    // {
    //     float windowAspect = (float)Screen.width / (float)Screen.height;
    //     float scaleHeight = windowAspect / targetAspect;

    //     Camera cam = GetComponent<Camera>();

    //     if (scaleHeight < 1.0f)
    //     {
    //         Rect rect = cam.rect;
    //         rect.width = 1.0f;
    //         rect.height = scaleHeight;
    //         rect.x = 0;
    //         rect.y = (1.0f - scaleHeight) / 2.0f;
    //         cam.rect = rect;
    //     }
    //     else
    //     {
    //         float scaleWidth = 1.0f / scaleHeight;
    //         Rect rect = cam.rect;
    //         rect.width = scaleWidth;
    //         rect.height = 1.0f;
    //         rect.x = (1.0f - scaleWidth) / 2.0f;
    //         rect.y = 0;
    //         cam.rect = rect;
    //     }
    // }
}
