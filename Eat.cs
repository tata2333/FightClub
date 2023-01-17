using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    
    public int healing = 20;
  
   
    
    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") )
        {

            other.GetComponent<PlayerHealth>().IncreaseHealth(healing);

           
           
                
            Destroy(this.gameObject);
           

            
            
            
           
           
        }
    }

   
}
