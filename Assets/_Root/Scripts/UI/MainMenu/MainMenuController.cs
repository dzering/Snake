using SnakeGame.Base;
using SnakeGame.UI;
using SnakeGame.Tools.ResourceManager;
using UnityEngine;
using Object = UnityEngine.Object;
using SnakeGame.Profile;

public class MainMenuController : BaseController
{
    private readonly MainMenuView mainMenuView;
    private readonly ResourcePath path = new ResourcePath { Path = "Prefabs/MainMenu" };
    private readonly Transform placeForUI;
    private readonly ProfilePlayer profilePlayer;

    public MainMenuController(ProfilePlayer profilePlayer, Transform placeForUI)
    {
        this.placeForUI = placeForUI;
        mainMenuView = LoadView();
        mainMenuView.Init(StartGame);
        this.profilePlayer = profilePlayer;


    }

    private void StartGame()
    {
        profilePlayer.CurrentState.Value = GameState.Game;
    }

    private MainMenuView LoadView()
    {
        GameObject pref = ResourceLoader.LoadPrefab(path);
        GameObject mainMenu = Object.Instantiate(pref, placeForUI);
        AddGameObject(mainMenu);

        return mainMenu.GetComponent<MainMenuView>();
    }
}
