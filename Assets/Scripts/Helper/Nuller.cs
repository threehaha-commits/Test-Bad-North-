using UnityEngine;

public static class Helper
{
    public static bool IsNull(Object target)
    {
        return target == null;
    }

    public static bool IsNotNull(Object target)
    {
        return target != null;
    }
    
    /// <summary>
    /// Return distance between transforms
    /// </summary>
    /// <param name="t1">Current transform</param>
    /// <param name="t2">Target transform</param>
    /// <returns></returns>
    public static float GetDistance(Transform t1, Transform t2)
    {
        return (t2.position - t1.position).sqrMagnitude;
    }
}