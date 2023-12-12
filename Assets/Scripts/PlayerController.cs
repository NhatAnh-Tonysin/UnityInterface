using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEnum
{
    TopLeft, TopRight, BotLeft, BotRight
}
public class PlayerController : MonoBehaviour
{
    public Camera CameraFollow;
    public float Speed;
    public Transform topLeftTrans;
    public Transform topRightTrans;
    public Transform botLeftTrans;
    public Transform botRightTrans;

    private TargetEnum nextTarget = TargetEnum.TopLeft;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = botLeftTrans;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 targetPos = currentTarget.position;
        Vector3 dir = targetPos - curPos;


        float distance = dir.magnitude;
       if(distance>0.1f)
        {
            transform.position = Vector3.MoveTowards(curPos, targetPos, Speed * Time.deltaTime);
        }
        else
        {
            SetNextTarget(nextTarget);
        }

        // thay đổi hướng quay của đối tượng
        Quaternion targetRotate = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = targetRotate;
    }

    void SetNextTarget(TargetEnum target)
    {
        switch (target)
        {
            case TargetEnum.BotLeft:
                currentTarget = botLeftTrans;
                nextTarget = TargetEnum.TopLeft;
                break;

            case TargetEnum.TopLeft:
                currentTarget = topLeftTrans;
                nextTarget = TargetEnum.TopRight;
                break;

            case TargetEnum.TopRight:
                currentTarget = topRightTrans;
                nextTarget = TargetEnum.BotRight;
                break;

            case TargetEnum.BotRight:
                currentTarget = botRightTrans;
                nextTarget = TargetEnum.BotLeft;
                break;
        }
    }

}
