using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider bloodSugar;

    public platformerController playerScript;

    private void FixedUpdate()
    {
        bloodSugar.value = playerScript.bloodSugar;
    }
}
