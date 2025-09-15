using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    float destroyTime = 3.0f;
    float currentTime = 0;
    void Start()
    {
        Vector3 direction = Random.insideUnitSphere; // 크기가 1이고 방향만 존재함
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>(); //rb의 velocity값을 가져옴
        rb.velocity = direction * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime =  currentTime + Time.deltaTime;
        if(currentTime > destroyTime) //시간이 초과
        {
             // 복셀이 자기자신을 비활성화 함
             gameObject.SetActive(false);
             //Destroy(gameObject);
             VoxelMaker.voxelPool.Add(gameObject); // VoxelMaker의 오브젝트 풀을 자기자신의 추가
        }
    }
}
