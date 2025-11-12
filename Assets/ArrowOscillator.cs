using UnityEngine;

public class ArrowOscillator : MonoBehaviour
{
    [SerializeField] float moveDistance = 0.5f;  // how far left/right
    [SerializeField] float moveSpeed = 2f;       // how fast to move

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;  // store starting world position
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0f, 0f);
    }
}
