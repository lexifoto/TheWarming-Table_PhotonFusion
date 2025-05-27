using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterType characterType;
    public static CharacterManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void SetCharacterType(CharacterType type)
    {
        characterType = type;
    }
}

public enum CharacterType
{
    Politician,
    Celebrity,
    Athlete,
    Scientist
}
