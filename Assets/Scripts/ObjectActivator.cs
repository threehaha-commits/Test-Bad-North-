using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public void Activate(bool active)
    {
        gameObject.SetActive(active);
    }
}