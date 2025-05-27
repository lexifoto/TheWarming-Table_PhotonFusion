using UnityEngine;

public class CharacterSetter : MonoBehaviour
{
    public CharacterType characterType;
    public void SetCharacter()
    {
        CharacterManager.instance.SetCharacterType(characterType);
    }
}
