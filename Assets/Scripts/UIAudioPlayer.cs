using UnityEngine;

public class UIAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_clip);
    }
}