public class Level {
    private int _number;
    private bool _unlocked = false;
    public bool unlocked { get { return _unlocked; } }
    public int number { get { return _number; } }
    private string gameName;

    public Level(string gameName, int number, bool unlocked=false) {
        this._number = number;
        this._unlocked = unlocked;
        this.gameName = gameName;
    }

    public void Lock() {
        _unlocked = false;
    }

    public void Unlock() {
        _unlocked = true;
    }

    public void StartNext() {
        SceneRouter.OpenGameLevel(gameName, _number);
    }

    public void Start() {
        SceneRouter.OpenGameLevel(gameName, _number);
    }
}
