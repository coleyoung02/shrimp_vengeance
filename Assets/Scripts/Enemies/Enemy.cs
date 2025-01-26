using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage=1f)
    {
        currentHealth -= damage;
        StopAllCoroutines();
        StartCoroutine(HurtEffect());
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public SpriteRenderer GetSprite()
    {
        return spriteRenderer;
    }

    private IEnumerator HurtEffect()
    {
        float redness = .5f;
        float flashDuration = .5f;
        Color c = Color.white;
        for (float f = 0f; f < flashDuration; f += Time.deltaTime)
        {
            Debug.Log("Ahhhh");
            c.g = Mathf.Lerp(1 - redness, 1, f / flashDuration);
            c.b = Mathf.Lerp(1 - redness, 1, f / flashDuration);
            spriteRenderer.color = c;
            yield return new WaitForEndOfFrame();
        }
        spriteRenderer.color = Color.white;
    }
}
