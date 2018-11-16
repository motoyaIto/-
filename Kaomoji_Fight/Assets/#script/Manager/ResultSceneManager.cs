﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using XboxCtrlrInput;
using TMPro;
using Cinemachine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{

    // UIキャンバス
    private GameObject canvas;

    // プレイヤーデータ
    private List<ResultData> players = new List<ResultData>();

    // プレイタイム
    private float time;
    private int min;
    private int second;

    // 鳴らすかもしれない音
    private AudioSource As;
    private AudioClip se;


    private void Awake()
    {
        // 音を鳴らす準備
        As = this.GetComponent<AudioSource>();
        As.volume = .1f;
        se = (AudioClip)Resources.Load("Sound/SE/Select/crrect");
    }

    void Start()
    {
        // UIオブジェクトを設定
        canvas = GameObject.Find("ResultUI").transform.gameObject;

        // 遊んだ時間の取得


        // リストの管理
        for(int i = 0; i < PlayData.Instance.playerNum; i++)
        {
            players.Add(null);
        }

        // リザルトの表示
        ResultRender();
        DataRender();
    }

    void Update()
    {
        // タイトルシーンへ戻る
        if (XCI.GetButton(XboxButton.B, XboxController.First))
        {
            As.PlayOneShot(se);
            //SceneManager.LoadScene("Title");
        }
    }

    private void ResultRender()
    {
        for (int i = 0; i < PlayData.Instance.playerNum; i++)
        {
            // 順位表示
            canvas.transform.GetChild(1).transform.GetChild(i).transform.gameObject.SetActive(true);
            TextMeshProUGUI playerName = canvas.transform.GetChild(1).transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            playerName.text = players[i].PlayersName.ToString();

            // プレイヤーの顔表示
            PlayerSpriteRender(i);
        }
    }

    private void DataRender()
    {
        // プレイ時間の計測
        if (time <= 60.0f)
        {
            min = (int)(time / 60.0f);
            second = (int)(time - 60 * min);
        }
        else
        {
            min = 0;
            second = (int)time;
        }

        // 時間表示
        TextMeshProUGUI timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timer.text = min + ":";
        if (second < 10) { timer.text += "0" + second; } else { timer.text += second; }

        // ダメージを一番与えたプレイヤーの表示
        TextMeshProUGUI player = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        player.text = "しょぼん";
    }

    private void PlayerSpriteRender(int num)
    {
        GameObject playerFace;
        switch (num)
        {
            case 0:
                playerFace = GameObject.Find("FirstPlayerFace").transform.gameObject;
                break;
            case 1:
                playerFace = GameObject.Find("SecondPlayerFace").transform.gameObject;
                break;
            case 2:
                playerFace = GameObject.Find("ThirdPlayerFace").transform.gameObject;
                break;
            case 3:
                playerFace = GameObject.Find("ForthPlayerFace").transform.gameObject;
                break;
            default:
                break;
        }
    }
}
