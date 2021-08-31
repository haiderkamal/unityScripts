using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public static UIScript Instance { get; private set; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    [SerializeField]
    //private Text pointsTxt;

    public void GetPoint()
    {
       // managerscript.Instance.IncrementCounter();
    }

    public void Restart()
    {
       // managerscript.Instance.RestartGame();
    }

    public void Increment()
    {
     
        
      //menucars.incrementAchievement(GPGSIds.achievement_achievement_outfit_unlocked, 100);
    }

    public void Unlock()
    {
     //   menucars.incrementAchievement(GPGSIds.achievement_achievement_outfit_unlocked);
    }

    public void ShowAchievements()
    {
      //  menucars.shoeachievement();
    }

    public void ShowLeaderboards()
    {
      //  menucars.showleaderboard();
    }

    public void UpdatePointsText()
    {
       // pointsTxt.text = managerscript.Counter.ToString();
    }
}