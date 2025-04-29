using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5f;

    public Collider2D leftBoundary;
    public Collider2D rightBoundary;
    public Collider2D topBoundary;
    public Collider2D bottomBoundary;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        float targetX = player.position.x;
        float targetY = player.position.y;

        float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float cameraHalfHeight = Camera.main.orthographicSize;

        if (leftBoundary != null)
        {
            targetX = Mathf.Clamp(targetX, leftBoundary.bounds.max.x + cameraHalfWidth, rightBoundary.bounds.min.x - cameraHalfWidth);
        }

        if (rightBoundary != null)
        {
            targetX = Mathf.Clamp(targetX, leftBoundary.bounds.max.x + cameraHalfWidth, rightBoundary.bounds.min.x - cameraHalfWidth);
        }

        if (topBoundary != null)
        {
            targetY = Mathf.Clamp(targetY, bottomBoundary.bounds.max.y + cameraHalfHeight, topBoundary.bounds.min.y - cameraHalfHeight);
        }

        if (bottomBoundary != null)
        {
            targetY = Mathf.Clamp(targetY, bottomBoundary.bounds.max.y + cameraHalfHeight, topBoundary.bounds.min.y - cameraHalfHeight);
        }

        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing * Time.deltaTime);
    }
}
