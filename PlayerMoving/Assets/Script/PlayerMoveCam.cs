using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCam : MonoBehaviour
{
    //カメラが向いてる方向を見る
    //プレイヤーオブジェクトを入力の方向に回転させる

    [Header("プレイヤーのパラメーター設定")]
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
    /// カメラがプレイヤーの前方がどこにあるのかを調べる
    /// </summary>
    private void FixedUpdate()
    {
        //ローテーションを適応させる。
        Vector3 direction = _player.position - new Vector3(transform.position.x , _player.position.y , transform.position.z);

        _direction.forward = direction.normalized;　//入力方向を計算


        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 newDirection = _direction.forward * vertical +
                                                    _direction.right * horizontal;


        //入力方向が異なる場合は、垂直方向の入力に_orientation.forwardを掛ける
        //水平方向の入力に_orientation.rightを掛ける

        if (newDirection != Vector3.zero)
        {
            _playerObject.forward = Vector3.Slerp(_playerObject.forward , newDirection.normalized , Time.deltaTime * _rotationSpeed);
        }

    }

}
