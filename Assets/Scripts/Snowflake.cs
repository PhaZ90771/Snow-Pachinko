using UnityEngine;

public class Snowflake : MonoBehaviour
{
    public GameObject ParticlePrefab;
    [Range(1, 100)]
    public uint NumberOfParticles = 8;
    public Sprite[] SpriteVariations;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var index = Random.Range(0, SpriteVariations.Length - 1);
        spriteRenderer.sprite = SpriteVariations[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Igloo>() != null)
        {
            var contact = collision.contacts[0];
            SpawnParticles(contact.point);
            Destroy(this.gameObject);
        }
    }

    private void SpawnParticles(Vector2 point)
    {
        for (int i = 0; i < NumberOfParticles; i++)
        {
            Instantiate(ParticlePrefab, point, new Quaternion(), null);
        }
    }
}
