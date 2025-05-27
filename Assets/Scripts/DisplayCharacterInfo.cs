using UnityEngine;

public class DisplayCharacterInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject characterInfoPanelPolititan;
    [SerializeField] GameObject characterInfoPanelCelebrity;
    [SerializeField] GameObject characterInfoPanelAthlete;
    [SerializeField] GameObject characterInfoPanelScientist;
    void OnEnable()
    {
        characterInfoPanelAthlete.SetActive(false);
        characterInfoPanelCelebrity.SetActive(false);
        characterInfoPanelPolititan.SetActive(false);
        characterInfoPanelScientist.SetActive(false);
        switch (CharacterManager.instance.characterType)
        {
            case CharacterType.Politician:
                characterInfoPanelPolititan.SetActive(true);
                break;
            case CharacterType.Celebrity:
                characterInfoPanelCelebrity.SetActive(true);
                break;
            case CharacterType.Athlete:
                characterInfoPanelAthlete.SetActive(true);
                break;
            case CharacterType.Scientist:
                characterInfoPanelScientist.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
