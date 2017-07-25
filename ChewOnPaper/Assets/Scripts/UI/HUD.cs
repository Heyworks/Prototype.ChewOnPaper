using System;
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
    /// <param name="showChewButton">Indicating whether chew button is visible.</param>    
    public void ShowChewing(string chewerName, int turnTime, bool showChewButton)
    {
        secondsLeft = turnTime;
        currentChewerName = chewerName;
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

    private void Update()
    {
        if (secondsLeft > 0)
        {
            secondsLeft -= Time.deltaTime;
            stateText.text = string.Format("{0} chews {1} seconds.", currentChewerName, (int)secondsLeft);
        }
    }

    private IEnumerator WinnerCoroutine(string winnerName, string word)
    {
        winnerText.gameObject.SetActive(true);
        for (int timeLeft = 9; timeLeft > 0; timeLeft--)
        {
            winnerText.text = string.Format("FINISH!!! The winner is {0}. Word: {1}\n{2}", winnerName, word, timeLeft);
            yield return new WaitForSeconds(1);
        }

        winnerText.gameObject.SetActive(false);
    }
}
