using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    private Vector3 vector;

    public float runspeed;
    private float applyRunSpeed;
    private bool applyRunFlag=false;

    public int walkCount;//speed * walkCount=방향키 한번의 이동거리
    private int currentWalkCount;//반복문을 빠져나갈때 사용

    private bool canMove=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator MoveCoroutine(){
        if(Input.GetKey(KeyCode.LeftShift))
                {
                    applyRunSpeed=runspeed;
                    applyRunFlag=true;
                }
                else
                {
                    applyRunSpeed=0;
                    applyRunFlag=false;   
                }
            
            vector.Set(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),transform.position.z);

            while (currentWalkCount<walkCount)
            {
                if(vector.x !=0){
                transform.Translate(vector.x*(speed+applyRunSpeed),0,0);
                }
                else if(vector.y != 0){
                transform.Translate(0,vector.y*(speed+applyRunSpeed),0);
                }
                if(applyRunFlag)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount=0;
        canMove=true;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if(Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0)
                {
                    canMove=false;
                    StartCoroutine(MoveCoroutine());
            }    
        }

    }
}
