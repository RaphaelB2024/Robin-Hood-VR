using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public pointManager pointsManager;
    public int pointValue;
    public bool shootable = true;
    private bool claimed = false;

    private void Update()
    {
        if(!shootable && !claimed)
        {
            pointsManager.points += pointValue;
            shootable = false;
            claimed = true;
        }
    }
}
