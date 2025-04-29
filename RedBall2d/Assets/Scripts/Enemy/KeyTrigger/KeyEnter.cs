using UnityEngine;

public class KeyEnter : MonoBehaviour, IContactTrigger
{
    [SerializeField] ParticleSystem particleEnter;
    [SerializeField] private float movementRange = 0.5f; 
    [SerializeField] private float movementSpeed = 2f;
    int count = 1;

    Vector3 initialPosition;

     void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * movementSpeed) * movementRange;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);
    }

    public void ApplyContact(GameObject player)
    {
        Keys keys = player.GetComponent<Keys>();
        keys.AddBag(count);
        particleEnter.Play();
        Destroy(gameObject, 0.5f);
    }
}
