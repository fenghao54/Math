using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour {

    RaycastHit floorHit;
    public Rigidbody rigid;
    public int floorMask;
    public float speed=20f;
    Vector3 _playerToMouse;
    Vector3 offset;
    Vector3 offset2;
    void Start ()
    {
        floorMask = LayerMask.GetMask("Floor");
    }
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetPos();
            turn();
        }
       Move();
       // rigid.velocity = offset2 * speed * Time.deltaTime;
    }
    void GetPos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(camRay, out floorHit, 100, floorMask))
        {
            _playerToMouse = floorHit.point;
            _playerToMouse.y = transform.position.y;
        }
    }

  
    void Move()
    {
        offset = _playerToMouse - transform.position;
        if (offset.magnitude > 0.1f)
        {
            var offset_no = offset.normalized;
            transform.position += offset_no * speed * Time.deltaTime;
        }
        
    }

    void turn()
    {
        float value_new= Vector3.Dot(transform.forward, _playerToMouse-transform.position);
        float value_new2 = Vector3.Dot(transform.right, _playerToMouse - transform.position);
        Vector3 valuer_new2 = Vector3.Cross(new Vector3(0, 0, 1), _playerToMouse - transform.position);
        var value2 = _playerToMouse - transform.position;
        var value6 = valuer_new2.magnitude / value2.magnitude; //sin值
        var value3 = value_new /value2.magnitude; //cos值
        var value8 = value_new2 / value2.magnitude;//cos2值
        if (value8>0)
        {
            var value4 = Mathf.Rad2Deg * Mathf.Acos(value3);
            
            Debug.Log(value4);
            transform.Rotate(transform.up, -value4);
        }
        else
        {
            var value4 = Mathf.Rad2Deg * Mathf.Acos(value3);
            Debug.Log(1);
            transform.Rotate(transform.up, -value4);
        }

    }

 

}
