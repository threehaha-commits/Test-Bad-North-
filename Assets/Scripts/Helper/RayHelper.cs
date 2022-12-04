using UnityEngine;

public static class RayHelper
{
    private static Camera _camera;
    private static Camera camera
    {
        get
        {
            if (_camera == null)
                _camera = Camera.main;
            return _camera;
        }
    }
    private static Vector3 _mousePosition => Input.mousePosition;
    
    public static bool GetRay(out RaycastHit hit)
    {
        var ray = camera.ScreenPointToRay(_mousePosition);
        return Physics.Raycast(ray, out hit, Mathf.Infinity);
    }
}