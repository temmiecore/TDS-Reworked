using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openedSprite;

    private bool wasLooted;

    [Header("Loot table")]
    public List<GameObject> itemPrefabs;
    [Range(0, 1f)]
    public List<float> itemWeights;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        wasLooted = false;
    }

    void Update()
    {
        if (wasLooted)
            return;

        if (Vector2.Distance(GameManager.Instance.player.transform.position, transform.position) < 0.08f && Input.GetKeyDown(KeyCode.E))
            Loot();
    }

    public void Loot()
    {
        if (itemPrefabs.Count == 0 || itemWeights.Count != itemPrefabs.Count)
            return;

        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (Random.Range(0, 1f) < itemWeights[i])
                Instantiate(itemPrefabs[i], transform.position, transform.rotation);
        }

        spriteRenderer.sprite = openedSprite;
        wasLooted = true;
    }
}
