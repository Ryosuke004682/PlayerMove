using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Therd_Parson_Move : MonoBehaviour
{
    //カメラが向いてる方向にプレイヤーを向ける
    //プレイヤーオブジェクトを入力の方向に回転させる

    [Header("オブジェクトのTransformを取得")]

    public Transform _orientation;
    public Transform _player;
    public Transform _playerObject;
    public Rigidbody _rb;

    public float _rotationSpeed;


    /// <summary>
    /// カメラからのPlayerの前方方向がどこにあるかを調べる
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 viewDraw = _player.position - new Vector3(transform.position.x,_player.position.y , transform.position.z);

        _orientation.

    }


}
