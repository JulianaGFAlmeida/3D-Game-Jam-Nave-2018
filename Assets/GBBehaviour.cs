using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBBehaviour : MonoBehaviour {

	private float timer;
    private float change;
    private float init;
    private bool colidindo;
    private int direcao;
    private int index=0;
    private List<Vector3> tel;
    
    void Start(){
        timer = 5;
        change = 10;
        init = timer;
        direcao = 1;
        colidindo = true;
        Physics.IgnoreCollision(this.GetComponentInChildren<BoxCollider>(), this.GetComponent<CapsuleCollider>());
        tel = new List<Vector3>();
        tel.Add(new Vector3(this.transform.position.x, 28, this.transform.position.z));
        tel.Add(new Vector3(this.transform.position.x, 28, 83));
        tel.Add(new Vector3(83,28,this.transform.position.z));
  }
	
	void Update () {
        //transform.Rotate(transform.up * direcao);
        if (colidindo){
		timer -=Time.deltaTime;
            change -= Time.deltaTime;
            
        if(change < 0){
                if(index <= tel.Count-1){
                    index++;

        }else{
                    index = 0;
        }
                this.transform.position = tel[index];
                change = 10;
    }
        if(timer < 0){
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,6000,0));
            direcao  = -direcao;
            if(init == 5){
                    timer = 8;
        print(timer);
                    init = timer;
        }else if(init == 8){
                    timer = 3;
        print(timer);
                    init = timer;
        }else if(init == 3){
                    timer = 5;
        print(timer);
                    init = timer;
        }
    }
}
	    }
    
        void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "chao"){
            print("eu p ae");
            colidindo = true;
         }
        
            }
    
        void OnCollisionExit(Collision collision){
        if(collision.gameObject.tag == "chao"){
            colidindo = false;
                }
        }

    void OnTriggerEnter(Collider col) {
        print(this.GetComponentInChildren<BoxCollider>().bounds.Contains(col.transform.position));
        print(col.tag);
        if (col.tag != "chao" && this.GetComponentInChildren<BoxCollider>().bounds.Contains(col.transform.position)) {
            print(this.GetComponentInChildren<BoxCollider>().bounds.Contains(col.transform.position));
            Destroy(col.gameObject);
        }
    }

}
