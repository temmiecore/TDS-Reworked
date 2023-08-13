using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandRotationController : MonoBehaviour
{
    private BTreeController tree;

    private void Start()
    {
        tree = GetComponent<BTreeController>();
    }

    private void Update()
    {
        if (tree.isAlerted)
        {
            try
            {
                Vector2 direction = tree.target.position - tree.npcTransform.position;
                tree.enemyHand.position = new Vector3(tree.npcTransform.position.x + 0.08f * direction.normalized.x,
                                                tree.npcTransform.position.y + 0.08f * direction.normalized.y - 0.08f, 0);

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion handRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                tree.enemyHand.rotation = handRotation;

                if (angle > 90f || angle < -90f)
                { tree.enemyHand.localScale = new Vector3(1, -1, 1); tree.spriteRenderer.flipX = true; }
                else
                { tree.enemyHand.localScale = new Vector3(1, 1, 1); tree.spriteRenderer.flipX = false; }
            }
            catch { }
        }
    }
}
