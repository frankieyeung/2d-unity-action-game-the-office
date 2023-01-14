using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject player;
    GameObject finish;
    GameObject distanceui;
    GameObject timeui;
    GameObject moneyui;
    GameObject hpBar;

    int money = 0;
    float hp = 3;
    float time = 60.0f;
    // Start is called before the first frame update

    public void getCoin() {
        this.money += 100;
    }

    public void getIcecream() {
        if (hp < 3) {
            this.hp += 1;
            this.hpBar.GetComponent<Image>().fillAmount += (float)1 / (float)3;
        }
    }

    public void getPoop() {
        this.hp -= 1;
        this.hpBar.GetComponent<Image>().fillAmount -= (float)1 / (float)3;
    }

    public void getBamboo() {
        this.hp -= 1;
        this.hpBar.GetComponent<Image>().fillAmount -= (float)1 / (float)3;

    }





    void Start()
    {
        this.player = GameObject.Find("office_worker");
        this.finish = GameObject.Find("finish");
        this.distanceui = GameObject.Find("distanceui");
        this.timeui = GameObject.Find("timeui");
        this.moneyui = GameObject.Find("moneyui");
        this.hpBar = GameObject.Find("hpBar");
    }

    // Update is called once per frame
    void Update()
    {
        // distance left
        float length = this.finish.transform.position.x - this.player.transform.position.x;
        this.distanceui.GetComponent<TMPro.TextMeshProUGUI>().text = "Distance to your office:" + length.ToString("0") + "M";


        //time left
        this.time -= Time.deltaTime;
        this.timeui.GetComponent<TMPro.TextMeshProUGUI>().text = "Time left: " + this.time.ToString("F1");

        if (this.time <= 0) {
        SceneManager.LoadScene("loseScene");
        }

        this.moneyui.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + this.money.ToString();

        if (this.hp <= 0) {
            SceneManager.LoadScene("deadScene");
        }

        if (this.money >= 3000) {
            SceneManager.LoadScene("richScene");
        }


    }

    
}
