using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCam : MonoBehaviour
{
    //�J�����������Ă����������
    //�v���C���[�I�u�W�F�N�g����͂̕����ɉ�]������

    [Header("�v���C���[�̃p�����[�^�[�ݒ�")]
    public Transform _direction;
    public Transform _player;
    public Transform _playerObject;
    public Rigidbody _rb;

    public float _rotationSpeed;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    /// <summary>
    /// �J�������v���C���[�̑O�����ǂ��ɂ���̂��𒲂ׂ�
    /// </summary>
    private void FixedUpdate()
    {
        //���[�e�[�V������K��������B
        Vector3 direction = _player.position - new Vector3(transform.position.x , _player.position.y , transform.position.z);

        _direction.forward = direction.normalized;�@//���͕������v�Z


        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 newDirection = _direction.forward * vertical +
                                                    _direction.right * horizontal;


        //���͕������قȂ�ꍇ�́A���������̓��͂�_orientation.forward���|����
        //���������̓��͂�_orientation.right���|����

        if (newDirection != Vector3.zero)
        {
            _playerObject.forward = Vector3.Slerp(_playerObject.forward , newDirection.normalized , Time.deltaTime * _rotationSpeed);
        }

    }

}
