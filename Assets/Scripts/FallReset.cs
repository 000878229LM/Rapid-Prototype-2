using UnityEngine;

public class FallRecovery : MonoBehaviour
{
    public Transform RecoveryPoint1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = RecoveryPoint1.position;
        return;
    }
}
