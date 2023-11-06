using UnityEngine;
using UnityEngine.UI;

public class ButtonWriter : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        //_button.onClick?.RemoveAllListeners();
        _button.onClick.AddListener(ClickEvent);
    }

    protected virtual void ClickEvent()
    {

    }
}
