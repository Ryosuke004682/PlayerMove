using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�ړ��p�p�����[�^�[")]
    public float _moveSpeed;
    public float groundDragPower;

    //[Header("�W�����v�p�p�����[�^�[")]
    //public float _jumpPower;
    //public float _CoolDownTime;
    //public float _aerialManipulation; //�󒆈ړ�
    //bool jump;
    //public KeyCode jumpKey = KeyCode.Space;

    [Header("�n�ʌ��m�p�p�����[�^�[")]
    public float _player_CenterHight;//player�̖񒆐S����n�ʂ̍���
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
        //�n�ʂ����m����
        //���m����ɂ͏��Ȃ��炸�n�ʂɃ��C�����܂��ĂȂ�����肵�����肪���Ȃ��B
        //�Ȃ̂�Player��Center����A��������0.5�̒����̃��C��0.2�𑫂��B
      
        grounded = Physics.Raycast(transform.position , Vector3.down ,
            _player_CenterHight * 0.5f + 0.2f , isGround);

        //�����n�ʂɐڒn���Ă��������͂��l�������i���C���l���邽�߁j
 
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

        //    //�x��������ƘA�����ăW�����v���Ȃ��Ȃ�B
        //    Invoke(nameof(ResetJump) , _CoolDownTime);
        //}

    }


    /// <summary>
    /// �v���C���[�̈ړ������̌v�Z������B
    /// </summary>
    private void MovePlayer()
    {
        
        moveDirection = _direction.forward * _vertical 
                                + _direction.right * _horizontal;

            _rb.AddForce(moveDirection.normalized * _moveSpeed * 10, ForceMode.Force);

        //�ڒn���Ă��Ȃ��A�󒆂ɂ���Ƃ�
        //else if (!grounded)
        //    _rb.AddForce(moveDirection.normalized * _moveSpeed * 10  * _aerialManipulation, ForceMode.Force);
    }

    /// <summary>
    ///  �ݒ肵���X�s�[�h�����傫���Ȃ��Ă��邩�琧��B
    /// </summary>
    private void SpeedController()
    {
        Vector3 limitSpeed = new (_rb.velocity.x , 0.0f , _rb.velocity.z);

        //���x�̃��~�b�g��ݒ肷��
        if (limitSpeed.magnitude > _moveSpeed)
        {
           
            Vector3 limited = limitSpeed.normalized * _moveSpeed;
            _rb.velocity = new Vector3(limited.x , _rb.velocity.y ,limited.z);
        }
    }


    /// <summary>
    /// �W�����v�Ƌ󒆑���ɂ���
    /// </summary>
    //private void Jump()
    //{
    //    _rb.velocity = new Vector3(_rb.velocity.x , 0.0f , _rb.velocity.z);

    //    _rb.AddForce(transform.up * _jumpPower , ForceMode.Impulse);
    //}

    /// <summary>
    /// �W�����v�̏���
    /// </summary>
    //private void ResetJump()
    //{
    //    jump = true;
    //}
}
