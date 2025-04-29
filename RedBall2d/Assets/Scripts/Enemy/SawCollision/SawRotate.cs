using UnityEngine;

public class SawRotate : MonoBehaviour, IContact
{
    [SerializeField] float rotationSpeed = 180f;
    [SerializeField] int damage = 1;
 
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    public void ApplyContact(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.TakeDamage(damage);
    }
}
