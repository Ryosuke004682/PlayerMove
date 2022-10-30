using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("移動用パラメーター")]
    public float _moveSpeed;
    public float groundDragPower;

    //[Header("ジャンプ用パラメーター")]
    //public float _jumpPower;
    //public float _CoolDownTime;
    //public float _aerialManipulation; //空中移動
    //bool jump;
    //public KeyCode jumpKey = KeyCode.Space;

    [Header("地面検知用パラメーター")]
    public float _player_CenterHight;//playerの約中心から地面の高さ
    public LayerMask isGround;
    bool grounded;


    public Transform _direction;

    float _horizontal;
    float _vertical;

    Vector3 moveDirection;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        //地面を検知する
        //検知するには少なからず地面にレイが埋まってなきゃ安定した判定が取れない。
        //なのでPlayerのCenterから、下方向に0.5の長さのレイに0.2を足す。
      
        grounded = Physics.Raycast(transform.position , Vector3.down ,
            _player_CenterHight * 0.5f + 0.2f , isGround);

        //もし地面に接地していたい引力を考えたい（摩擦を考えるため）
 
        if(grounded)
        {
            _rb.drag = groundDragPower;
        }
        else
        {
            _rb.drag = 0;
        }


        MoveInput();
        SpeedController();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MoveInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical   = Input.GetAxisRaw("Vertical");

        //if(Input.GetKey(jumpKey) && jump && grounded)
        //{
        //    jump = false;
            
        //    Jump();

        //    //遅延させると連続してジャンプしなくなる。
        //    Invoke(nameof(ResetJump) , _CoolDownTime);
        //}

    }


    /// <summary>
    /// プレイヤーの移動方向の計算をする。
    /// </summary>
    private void MovePlayer()
    {
        
        moveDirection = _direction.forward * _vertical 
                                + _direction.right * _horizontal;

            _rb.AddForce(moveDirection.normalized * _moveSpeed * 10, ForceMode.Force);

        //接地していなく、空中にいるとき
        //else if (!grounded)
        //    _rb.AddForce(moveDirection.normalized * _moveSpeed * 10  * _aerialManipulation, ForceMode.Force);
    }

    /// <summary>
    ///  設定したスピードよりも大きくなっているから制御。
    /// </summary>
    private void SpeedController()
    {
        Vector3 limitSpeed = new (_rb.velocity.x , 0.0f , _rb.velocity.z);

        //速度のリミットを設定する
        if (limitSpeed.magnitude > _moveSpeed)
        {
           
            Vector3 limited = limitSpeed.normalized * _moveSpeed;
            _rb.velocity = new Vector3(limited.x , _rb.velocity.y ,limited.z);
        }
    }


    /// <summary>
    /// ジャンプと空中操作について
    /// </summary>
    //private void Jump()
    //{
    //    _rb.velocity = new Vector3(_rb.velocity.x , 0.0f , _rb.velocity.z);

    //    _rb.AddForce(transform.up * _jumpPower , ForceMode.Impulse);
    //}

    /// <summary>
    /// ジャンプの準備
    /// </summary>
    //private void ResetJump()
    //{
    //    jump = true;
    //}
}
