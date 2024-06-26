using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;
    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;
    private GameObject scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");
        //�V�[������scoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("scoreText");
        this.scoreText.GetComponent<Text>().text = "Score: " + this.score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // �e�I�u�W�F�N�g�ɑ΂��ĈقȂ�_�������Z���鏈���������ɒǉ�
        // �Ⴆ�΁A�Փ˂����I�u�W�F�N�g�̃^�O�Ɋ�Â��ē_�������Z����ꍇ�F
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