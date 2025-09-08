using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle;
    // 백터3라는 설계도로 앵글이라는 객체를 만듬
    public float sensitivity = 200;
    // Start is called before the first frame update
    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        // 메인 카메라의 정보를 가져옴 (.enlerAngles=각도정보보)
        angle.x = angle.x * -1;
        // 카메라 앵글을 반전 시킴
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 정보 입력
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        // 방향 확인
        angle.x = angle.x  + x * sensitivity * Time.deltaTime;
        angle.y = angle.y  + y * sensitivity * Time.deltaTime;
        angle.z = transform.eulerAngles.z;

        angle.x = Mathf.Clamp(angle.x, -90, 90);
        // Mathf.Clamp(angle.x, -90, 90)은 카메라가 과하게 움직이지 않도록 하는 코드
        // 회전
        transform.eulerAngles = new Vector3(-angle.x, angle.y, angle.z);
    }
}
