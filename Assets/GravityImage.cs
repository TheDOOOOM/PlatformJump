using UnityEngine;
using UnityEngine.UI;

public class GravityImage : MonoBehaviour
{
    [SerializeField] private Image _gravityViey;
    [SerializeField] private Sprite _gravityUp;
    [SerializeField] private Sprite _gravityDown;

    public void SetImage(Vector2 gravityDirection)
    {
        if (gravityDirection.y > 0)
            _gravityViey.sprite = _gravityUp;

        if (gravityDirection.y < 0)
            _gravityViey.sprite = _gravityDown;
    }
}