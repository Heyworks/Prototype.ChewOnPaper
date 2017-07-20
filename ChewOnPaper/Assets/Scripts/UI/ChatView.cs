using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Represents view for guesses chat.
/// </summary>
public class ChatView : MonoBehaviour
{
    [Inject]
    private GuessChat chat;
    [Inject]
    private GameStateController gameStateController;
    [Inject]
    private Game game;

    [SerializeField]
    private InputField guessInputField;
    [SerializeField]
    private Text messagesText;
    [SerializeField]
    private Button guessButton;
    [SerializeField]
    private ScrollRect scrollRect;

    private void Start()
    {
        chat.NewGuessArrived += Chat_NewGuessArrived;
    }

    /// <summary>
    /// Sets if chat available for interactactions.
    /// </summary>
    public void SetInteractable(bool isInteractable)
    {
        guessInputField.gameObject.SetActive(isInteractable);
        guessButton.gameObject.SetActive(isInteractable);
    }

    /// <summary>
    /// Guesses the button clicked.
    /// </summary>
    public void GuessButtonClicked()
    {
        gameStateController.GetCurrentState<GuessState>().Guess(guessInputField.text);
        guessInputField.text = string.Empty;
    }

    private void Chat_NewGuessArrived(Guess guess)
    {
        messagesText.text = CreateNewGuessText(guess) + messagesText.text;
        Canvas.ForceUpdateCanvases();

        scrollRect.verticalNormalizedPosition = 1f;

        Canvas.ForceUpdateCanvases();
    }

    private string CreateNewGuessText(Guess guess)
    {
        var playerName = game.GetPlayer(guess.PlayerId).Name;
        return string.Format("{0} : {1}\n", playerName, guess.Word);
    }
}
