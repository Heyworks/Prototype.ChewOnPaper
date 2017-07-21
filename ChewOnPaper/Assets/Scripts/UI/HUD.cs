using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText;
    [SerializeField]
    private Text stateText;
    [SerializeField]
    private Text secretWordText;
    [SerializeField]
    private GameObject secretWordRoot;
    [SerializeField]
    private Text winnerText;

    private float secondsLeft;
    private string currentChewerName;

    /// <summary>
    /// Shows the pending state.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    public void Initialize(string playerName)
    {
        playerNameText.text = playerName;
        stateText.text = "Pending...";
        secretWordRoot.SetActive(false);
    }

    /// <summary>
    /// Shows the secret word.
    /// </summary>
    /// <param name="word">The word.</param>
    public void ShowSecretWord(string word)
    {
        secretWordRoot.SetActive(true);
        secretWordText.text = word;
    }

    /// <summary>
    /// Hides the secret word.
    /// </summary>
    public void HideSecretWord()
    {
        secretWordRoot.SetActive(false);
    }

    /// <summary>
    /// Shows the chewing.
    /// </summary>
    /// <param name="chewerName">Name of the chewer.</param>
    /// <param name="turnTime">The turn time.</param>
    public void ShowChewing(string chewerName, int turnTime)
    {
        secondsLeft = turnTime;
        currentChewerName = chewerName;
    }

    private void Update()
    {
        if (secondsLeft > 0)
        {
            secondsLeft -= Time.deltaTime;
            stateText.text = string.Format("{0} chews {1} seconds.", currentChewerName, (int)secondsLeft);
        }
    }

    /// <summary>
    /// Shows the finish.
    /// </summary>
    /// <param name="winnerName">Name of the winner.</param>
    /// <param name="word">The word.</param>
    public void ShowFinish(string winnerName, string word)
    {
        secondsLeft = 0;
        stateText.text = "Finish";
        StartCoroutine(WinnerCoroutine(winnerName, word));
    }

    private IEnumerator WinnerCoroutine(string winnerName, string word)
    {
        winnerText.gameObject.SetActive(true);
        winnerText.text = string.Format("FINISH!!! The winner is {0}. Word: {1}", winnerName, word);

        yield return new WaitForSeconds(9);
        
        winnerText.gameObject.SetActive(false);
    }
}
