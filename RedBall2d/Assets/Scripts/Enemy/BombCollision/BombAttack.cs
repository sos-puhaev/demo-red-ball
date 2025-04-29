using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour, IContact
{
    [SerializeField] float speed = 4f;
    [SerializeField] int damage = 1;
    [SerializeField] Transform LeftBorder;
    [SerializeField] Transform RightBorder;

    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.left * direction * speed * Time.deltaTime);

        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;

        if (transform.position.x >= RightBorder.position.x / 2 )
        {
            direction = 1;
        }
        else if (transform.position.x <= LeftBorder.position.x + 2)
        {
            direction = -1;
        }
    }

    public void ApplyContact(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.TakeDamage(damage);;
    }
}
