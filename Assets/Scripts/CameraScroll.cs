using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private bool _inverse;
    [SerializeField] private float _scrollSpeed;
    private Camera _camera;
    private float _minFieldOfView = 35f;
    private float _maxFieldOfView = 60f;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            _camera.fieldOfView =
                Mathf.Clamp(_camera.fieldOfView + scroll * _scrollSpeed, _minFieldOfView, _maxFieldOfView);
        }
    }
}