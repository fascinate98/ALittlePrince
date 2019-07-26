using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (inst == null) inst = FindObjectOfType<GameManager>();
            return inst;
        }
    }
    private static GameManager inst;

    public CircleCotroller circleController;
}

