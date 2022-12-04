using UnityEngine;

public class WorldObjectRotation : MonoBehaviour
{
    private enum WatchAxis
    {
        ToCameraDirection,
        ToCameraY
    }
    
    [SerializeField] private WatchAxis _watchAxis = WatchAxis.ToCameraDirection;
    private Camera _camera;
    private Transform _transform;
    private Vector3 _cameraPosition => _camera.transform.position;
    private Vector3 _myPosition => _transform.position;
    
    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        var dir =  _cameraPosition - _myPosition;
        switch (_watchAxis)
        {
            case WatchAxis.ToCameraDirection:
                var lookRotation = Quaternion.LookRotation(dir, Vector3.up);
                var rotationSpeed = 300 * Time.fixedDeltaTime;
                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, rotationSpeed);
                break;
            case WatchAxis.ToCameraY:
                _transform.rotation = Quaternion.LookRotation(new Vector3(0,-1,0), _cameraPosition);
                break;
        }
    }
}