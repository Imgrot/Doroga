using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class iconAnchor : MonoBehaviour
{
    [Range(0f, 1f)] public float anchorX = 0.5f;
    [Range(0f, 1f)] public float anchorY = 0.5f;
    public bool updateEveryFrame = false;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SetPosition();
    }
    void Update()
    {
        if (updateEveryFrame)
            SetPosition();
    }
    void SetPosition()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 anchoredPos = new Vector2(anchorX * screenSize.x, anchorY * screenSize.y);

        Vector2 canvasPos;
        RectTransform canvasRect = rectTransform.root.GetComponent<RectTransform>();

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            anchoredPos,
            null,
            out canvasPos))
        {
            rectTransform.anchoredPosition = canvasPos;
        }
    }
}
