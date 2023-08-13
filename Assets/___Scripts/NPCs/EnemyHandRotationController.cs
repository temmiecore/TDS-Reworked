using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandRotationController : MonoBehaviour
{
    private BTreeController enemyTree;

    private void Start()
    {
        enemyTree = GetComponent<BTreeController>();
    }

    private void Update()
    {
        if (enemyTree.isAlerted)
        {
            Vector2 direction = enemyTree.target.position - enemyTree.enemyTransform.position;
            enemyTree.enemyHand.position = new Vector3(enemyTree.enemyTransform.position.x + 0.08f * direction.normalized.x,
                                            enemyTree.enemyTransform.position.y + 0.08f * direction.normalized.y - 0.08f, 0);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion handRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            enemyTree.enemyHand.rotation = handRotation;

            if (angle > 90f || angle < -90f)
            { enemyTree.enemyHand.localScale = new Vector3(1, -1, 1); enemyTree.spriteRenderer.flipX = true; }
            else
            { enemyTree.enemyHand.localScale = new Vector3(1, 1, 1); enemyTree.spriteRenderer.flipX = false; }
        }
    }
}
