using UnityEngine;

public class SawOnRope : MonoBehaviour
{
    [SerializeField] float angle = 30f;
    [SerializeField] float speed = 2f;

    private float startZ;

    void Start()
    {
        startZ = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float zRotation = startZ + Mathf.Sin(Time.time * speed) * angle;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
