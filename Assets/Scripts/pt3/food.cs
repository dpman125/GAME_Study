using System.Collections;
using UnityEngine;

public class food : MonoBehaviour
{

    public int sugar;
    public int speedBoost;
    public float speedDurration;
    public bool doubleJump;
    public float doupleJumpDurration;
    public float MoveTime;
    public int VmoveSpeed;
    public int HmoveSpeed;
    public bool ready = true;
    private void Start()
    {
        if (MoveTime != 0)
        {
            StartCoroutine(foodMove());
        }

    }
    private void Update()
    {
        transform.Translate(new Vector2(HmoveSpeed, VmoveSpeed) * Time.deltaTime);
    }
    IEnumerator foodMove()
    {
        yield return new WaitForSeconds(MoveTime);
        HmoveSpeed *= -1;
        VmoveSpeed *= -1;
        StartCoroutine(foodMove());
    }


}
