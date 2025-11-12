using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Delivery deliveryScript;  // Drag player object with Delivery script attached
    [SerializeField] float moveDistance = 0.5f;
    [SerializeField] float moveSpeed = 2f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (deliveryScript == null || player == null) return;

        if (deliveryScript.hasPackage)
        {
            // Enable arrow if not already active
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            // Animate left and right (like Vice City style)
            float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
            transform.localPosition = startPos + new Vector3(offset, 0f, 0f);
        }
        else
        {
            // Hide arrow if package not picked up
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }
}
