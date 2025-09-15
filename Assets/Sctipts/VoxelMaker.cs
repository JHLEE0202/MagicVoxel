using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory; // 생성할 대상 목록 (Voxel은 GameObject)

    //오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    // 오브젝트 풀 (배열개념)
    public static List<GameObject> voxelPool = new List<GameObject>();//static은 class에서 1개 (전체에서 1개)

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < voxelPoolSize; i++)
        {
        GameObject voxel = Instantiate(voxelFactory);
        //복셀 비활성화
        voxel.SetActive(false);
        //복셀을 오브젝트 풀에 추가
        voxelPool.Add(voxel);
        }
    }

    // Update is called once per frame
    void Update()
        { 
         if (Input.GetButtonDown("Fire1"))
        {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hitInfo = new RaycastHit();

             if (Physics.Raycast(ray, out hitInfo))
             {
                 if(voxelPool.Count > 0) //오브젝트 풀 안에 voxel이 있는지 확인
                 {
                 GameObject voxel = voxelPool[0]; //GameObject voxel = Instantiate(voxelFactory); 이 코드가 오브젝트 풀의 의해서 대체됨 / 오브젝트 풀 최상단의 값을 가져옴
                 voxel.SetActive(true);//객체를 활성화함
                 voxel.transform.position = hitInfo.point; // RayCast를 통해 얻은 충돌지점의 위치로 객체 이동
                 voxelPool.RemoveAt(0); // 오브젝트 풀에서 voxel 1개 제거
                 }
             }

        }
        }
}

