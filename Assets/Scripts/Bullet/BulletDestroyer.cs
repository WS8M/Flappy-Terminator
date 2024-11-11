using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.Deactivate();
        }
    }
}