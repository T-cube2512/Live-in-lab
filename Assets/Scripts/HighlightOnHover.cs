using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    public Color hoverColor = Color.yellow;
    public float hoverScaleFactor = 1.1f;
    public float hoverZOffset = 0.1f; // Adjust this value to determine how much the object moves forward when hovered
    public float animationDuration = 0.2f;

    private Color startColor;
    private Vector3 startScale;
    private Vector3 startPosition;
    private bool isHovering = false;

    void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
        startScale = transform.localScale;
        startPosition = transform.localPosition;
    }

    void Update()
    {
        if (isHovering)
        {
            // Scale up, change color, and move forward
            transform.localScale = Vector3.Lerp(transform.localScale, startScale * hoverScaleFactor, Time.deltaTime / animationDuration);
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, hoverColor, Time.deltaTime / animationDuration);
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(startPosition.x, startPosition.y, startPosition.z + hoverZOffset), Time.deltaTime / animationDuration);
        }
        else
        {
            // Return to original scale, color, and position
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, Time.deltaTime / animationDuration);
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, startColor, Time.deltaTime / animationDuration);
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime / animationDuration);
        }
    }

    void OnMouseEnter()
    {
        isHovering = true;
    }

    void OnMouseExit()
    {
        isHovering = false;
    }
}
