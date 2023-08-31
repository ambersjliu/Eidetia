using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
   
    public ButtonType buttonType;

    Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.StartGame:
                CanvasManager.instance.SwitchCanvas(CanvasType.GameUI);
                GameManager.Instance.UpdateGameState(GameState.exploringMaze);
                break;
            case ButtonType.EndGame:
                Application.Quit();
                break;
            case ButtonType.PlayAgain:
                SceneManager.LoadScene("Maze");
                CanvasManager.instance.SwitchCanvas(CanvasType.GameUI);
                GameManager.Instance.UpdateGameState(GameState.exploringMaze);
                break;
            
        }
    }
}


public enum ButtonType{
    StartGame,
    PlayAgain,
    EndGame,
}