using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Therd_Parson_Move : MonoBehaviour
{
    //�J�����������Ă�����Ƀv���C���[��������
    //�v���C���[�I�u�W�F�N�g����͂̕����ɉ�]������

    [Header("�I�u�W�F�N�g��Transform���擾")]

    public Transform _orientation;
    public Transform _player;
    public Transform _playerObject;
    public Rigidbody _rb;

    public float _rotationSpeed;


    /// <summary>
    /// �J���������Player�̑O���������ǂ��ɂ��邩�𒲂ׂ�
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 viewDraw = _player.position - new Vector3(transform.position.x,_player.position.y , transform.position.z);

        _orientation.

    }


}
