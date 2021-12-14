using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private Player selectedPlayer;

    public List<Player> playersList;

    [SerializeField]
    public Image selectedPlayerImage;

    [SerializeField]
    public Button previousButton;

    [SerializeField]
    public Button nextButton;

    [SerializeField]
    public Button selectButton;

    private int currenIndexPosition;

    private int indexPosition
    {
        get { return this.currenIndexPosition; }
        set
        {
            currenIndexPosition = value;

            if (currenIndexPosition < 0)
            {
                currenIndexPosition = playersList.Count - 1;
            }
            else if (currenIndexPosition > playersList.Count - 1)
            {
                currenIndexPosition = 0;
            }

            updateUIElements();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        indexPosition = 0;
    }

    public void OnClickPreviousButton()
    {
        this.indexPosition -= 1;
    }

    public void OnClickNextButton()
    {
        this.indexPosition += 1;
    }

    public void OnClickSelectButton()
    {
        Player player = playersList[currenIndexPosition];
        selectedPlayer.Init(player.speed, player.name, player.selectionSprite, player.animatorController);

        SceneManager.LoadScene("BasementMain");
    }

    private void updateUIElements()
    {
        Player currentCharacter = this.playersList[this.currenIndexPosition]; // Reference to the current viewed character.
        selectedPlayerImage.sprite = currentCharacter.selectionSprite;
    }
}
