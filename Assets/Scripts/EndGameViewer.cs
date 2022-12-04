using TMPro;
using UnityEngine;

public class EndGameViewer : MonoBehaviour
{
    [SerializeField] private GameObject _endWindow;
    private TMP_Text _endGameText;

    private void Start()
    {
        _endGameText = _endWindow.GetComponentInChildren<TMP_Text>();
    }

    public void End(string endMessage)
    {
        _endWindow.SetActive(true);
        _endGameText.text = endMessage;
    }
}