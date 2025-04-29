using UnityEngine;
using System.Collections;
public class Health : MonoBehaviour
{
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] GameObject healthIconPrefab; 
    [SerializeField] Transform[] healthSpawnPoints; 
    [SerializeField] int maxHealth = 3;
    int currentHealth;

    GameObject[] healthIcons;

    void Start()
    {
        currentHealth = maxHealth;
        healthIcons = new GameObject[maxHealth];

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject health = Instantiate(healthIconPrefab, healthSpawnPoints[i].position, Quaternion.identity);
            health.transform.SetParent(healthSpawnPoints[i].parent);
            health.SetActive(false);
            healthIcons[i] = health;
        }
        
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        FlashDamage();
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth == 0)
        {
            gameOverManager?.ShowGameOverPanel();
        }
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                healthIcons[i].SetActive(true);
            }
            else
            {
                healthIcons[i].SetActive(false);
            }
        }
    }

    void FlashDamage()
    {
        StartCoroutine(FlashColor());
    }

    IEnumerator FlashColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = new Color(0.5f, 0f, 0f);
            yield return new WaitForSeconds(1f); 
            renderer.material.color = Color.white;
        }
    }
}
