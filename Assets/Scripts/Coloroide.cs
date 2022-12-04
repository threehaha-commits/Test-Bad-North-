using UnityEngine;

public static class Coloroid
{
    private static SpriteRenderer _renderer;
    
    public static void ActiveChooseEffect(Transform unit)
    {
        _renderer = unit.GetComponentInChildren<SpriteRenderer>(true);
        EffectActive(true);
    }

    public static void Clear()
    {
        EffectActive(false);
    }

    private static void EffectActive(bool active)
    {
        _renderer.gameObject.SetActive(active);
    }
}