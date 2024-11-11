using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy)) 
            enemy.Deactivate();
    }
}
