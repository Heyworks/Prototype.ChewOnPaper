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

    [SerializeField]
    private InputField guessInputField;
    [SerializeField]
    private Text messagesText;
    [SerializeField]
    private Button guessButton;

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
        chat.Guess(guessInputField.text);
        guessInputField.text = string.Empty;
    }

    private void Chat_NewGuessArrived(Guess guess)
    {
        messagesText.text += CreateNewGuessText(guess);
    }

    private string CreateNewGuessText(Guess guess)
    {
        return guess.Word + '\n';
    }
}
