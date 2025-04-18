using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        SFXManager.Instance.PlaySFX("UI_Click");
    }
}
