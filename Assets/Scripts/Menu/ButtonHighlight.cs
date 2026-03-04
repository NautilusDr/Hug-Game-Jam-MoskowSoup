using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    Button ThisButton;
    Sprite HighLight;

    private void Start()
    {
        ThisButton = GetComponent<Button>();
        SpriteState spriteState;
        spriteState.highlightedSprite = HighLight;
    }

}
