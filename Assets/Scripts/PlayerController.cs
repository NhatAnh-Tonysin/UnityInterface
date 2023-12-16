using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEnum
{
    TopLeft, TopRight, BotLeft, BotRight,
}

public enum DriveMode
{
    Auto, Manual,
}
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed = 100f;
    public Transform topLeftTrans;
    public Transform topRightTrans;
    public Transform botLeftTrans;
    public Transform botRightTrans;

    private TargetEnum nextTarget = TargetEnum.TopLeft;
    private Transform currentTarget;



    [SerializeField]
    private DriveMode mode = DriveMode.Auto;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = botLeftTrans;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == DriveMode.Auto)
        {
            AutoMode();
        }
        else if (mode == DriveMode.Manual)
        {
            ManualMode();
        }
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

    void AutoMode()
    {
        Vector3 curPos = transform.position;
        Vector3 targetPos = currentTarget.position;
        Vector3 dir = targetPos - curPos;


        float distance = dir.magnitude;
        if (distance > 0.1f)
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
    void ManualMode()
    {
        // Input GetAxis
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Tính vector di chuyển dựa theo input
        //Vector3 move = new Vector3(horizontalInput, 0f, verticalInput) * Speed * Time.deltaTime;
        Vector3 move = new Vector3(0f, 0f, verticalInput) * Speed * Time.deltaTime;
        Vector3 rota = new Vector3(0f, horizontalInput, 0f) * RotateSpeed * Time.deltaTime;

        //Áp vị trí
        transform.Translate(move);
        transform.Rotate(rota);



        Debug.Log(horizontalInput + "," + verticalInput);
    }
}
