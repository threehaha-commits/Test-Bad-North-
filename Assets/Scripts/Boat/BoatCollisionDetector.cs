using UnityEngine;

public class BoatCollisionDetector : MonoBehaviour
{
    private EnemyInBoatHandler _enemyInBoatHandler;
    private float _contactOffset = 1.5f;
    private Vector3 _placeOutTheBoat => transform.position + (Vector3.forward * _contactOffset);
    
    private void Start()
    {
        _enemyInBoatHandler = GetComponent<EnemyInBoatHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Island"))
            _enemyInBoatHandler.CollisionWasDetected(_placeOutTheBoat);
    }
}