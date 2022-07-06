using RedPanda.SpriteHandler;
using UnityEngine;

public class NameAndFlag : MonoBehaviour
{
    [SerializeField] private SO_SpriteHandler sprites;
    [SerializeField] private bool _isPlayer;

    private Sprite _currentName;
    private Sprite _currentFlag;

    public Sprite CurrentName { get => _currentName; private set => _currentName = value; }
    public Sprite CurrentFlag { get => _currentFlag; private set => _currentFlag = value; }

    // Start is called before the first frame update
    private void Start()
    {
        _currentName = sprites.GetRandomName(_isPlayer);
        _currentFlag = sprites.GetRandomFlag();
    }
}