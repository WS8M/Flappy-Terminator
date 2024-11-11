using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        var position = transform.position;
        position.x = playerMover.transform.position.x + _offsetX;
        transform.position = position;
    }
}
