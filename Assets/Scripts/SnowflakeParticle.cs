using UnityEngine;

public class SnowflakeParticle : MonoBehaviour
{
    [Range(1f, 5f)]
    public ulong ParticleLife = 1;
    public Sprite[] SpriteVariations;

    private SpriteRenderer spriteRenderer;
    private float life = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var index = Random.Range(0, SpriteVariations.Length - 1);
        spriteRenderer.sprite = SpriteVariations[index];
    }

    private void Update()
    {
        life -= Time.deltaTime / ParticleLife;
        if (life <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
