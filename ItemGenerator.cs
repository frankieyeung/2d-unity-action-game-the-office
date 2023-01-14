using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject poopPrefab;
    public GameObject icecreamPrefab;
    public GameObject bambooPrefab;
    int ratio = 2;
    float span = 1.0f;
    float delta = 0;
    int playerPosX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosX = Mathf.RoundToInt(GameObject.FindGameObjectsWithTag("player")[0].transform.position.x);


        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject poop;
            GameObject coin;
            GameObject icecream;
            GameObject bamboo;

            int dice = Random.Range(1, 11);
            if(dice <= this.ratio){
                poop = Instantiate(poopPrefab);
                int px = Random.Range(playerPosX + 10, playerPosX + 20);
                poop.transform.position = new Vector3(px, 0, 0);

                bamboo = Instantiate(bambooPrefab);
                int bambooPx = Random.Range(playerPosX, playerPosX + 10);
                int bambooPy = 10;
                bamboo.transform.position = new Vector3(bambooPx, bambooPy, 0);
 


            } else {
                

                coin = Instantiate(coinPrefab);
                int px = Random.Range(playerPosX + 10, playerPosX + 20);
                int py = Random.Range(0, 7);
                coin.transform.position = new Vector3(px, py, 0);


                icecream = Instantiate(icecreamPrefab);
                int icecreamPx = Random.Range(playerPosX + 10, playerPosX + 20);
                int icecreamPy = Random.Range(0, 7);
                icecream.transform.position = new Vector3(icecreamPx, icecreamPy, 0);


            }
                    

            
          
                
        }

            


            
    }
    
}

