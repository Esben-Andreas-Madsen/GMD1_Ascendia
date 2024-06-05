using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public int soundIndex;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySound(0);
        }
    }
}
