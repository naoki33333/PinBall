using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;
    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("scoreText");
        this.scoreText.GetComponent<Text>().text = "Score: " + this.score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 各オブジェクトに対して異なる点数を加算する処理をここに追加
        // 例えば、衝突したオブジェクトのタグに基づいて点数を加算する場合：
        if (collision.gameObject.CompareTag("SmallStarTag"))
        {
            this.score += 10;
        }
        else if (collision.gameObject.CompareTag("LargeStarTag"))
        {
            this.score += 50;
        }
        else if (collision.gameObject.CompareTag("SmallCloudTag"))
        {
            this.score += 50;
        }
        else if (collision.gameObject.CompareTag("LargeCloudTag"))
        {
            this.score += 100;
        }
    }
}