
public enum GameUIState {
    MAINMENU,
    OPTIONS,
    INGAME,
    PAUSED,
    GAMEOVER
}

public static class GameMaster {
    
    public static GameUIState UIState = GameUIState.MAINMENU;
    public static bool IsSinglePlayerMode = true;
    public static int PlayerWinId = 0;

    public static void CheckGameStatus(bool end) {
        UIState = end ? GameUIState.GAMEOVER : GameUIState.INGAME;
    }

    public static bool IsGameOver() {
        return UIState == GameUIState.GAMEOVER;
    }
}
