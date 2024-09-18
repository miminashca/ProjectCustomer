using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Transform handTransform; // The VR hand or controller
    public float dragForce = 10f;   // How strong the drag should be
    public float distanceThreshold = 0.1f;  // Max distance from hand to "snap" the bed

    private Rigidbody rb;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isDragging)
        {
            DragObjectWithForce();
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

    public void StopDragging()
    {
        isDragging = false;
        rb.velocity = Vector3.zero;  // Stop movement when dragging stops
    }

    private void DragObjectWithForce()
    {
        Vector3 direction = (handTransform.position - transform.position).normalized;
        float distance = Vector3.Distance(handTransform.position, transform.position);

        if (distance > distanceThreshold)
        {
            rb.AddForce(direction * dragForce * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}
