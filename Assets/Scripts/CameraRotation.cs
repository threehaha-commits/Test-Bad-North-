using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private bool _inverse;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _island;
    private Transform _transform;
    
    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var horizontal = Input.GetAxis("Mouse X");
            horizontal = _inverse ? horizontal : -horizontal;
            var dir = new Vector3(0, horizontal, 0);
            _transform.RotateAround(_island.position, dir,90f * _rotateSpeed * Time.deltaTime);
        }
    }
}