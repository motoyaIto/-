﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using XboxCtrlrInput;
using TMPro;



public class PlaySceneManager : MonoBehaviour
{
    //プレイヤーのデータを管理する
    [System.Serializable]
    private class Player_data
    {
        private GameObject m_Player;
        private GameObject m_HPgage;

        [SerializeField]
        private string m_name;          //プレイヤー名
        [SerializeField]
        private Color m_nameColor;      //HPバーに表示される名前の色

        [SerializeField]
        private Sprite m_playerFace;//プレイヤーの顔文字

        [SerializeField]
        private Vector3 m_initialPos;   //初期ポップ位置


        private Slider m_hpgage_slider; //HPスライダー
        private XboxController m_controller;

        //コンストラクタ
        public Player_data(string name, Color col, Sprite player_face, Vector3 initialPos, XboxController controller)
        {
            m_Player = (GameObject)Resources.Load("prefab/Player");
            m_HPgage = (GameObject)Resources.Load("prefab/UI/HPgage");
            m_name = name;
            m_nameColor = col;
            m_playerFace = player_face;
            m_initialPos = initialPos;
            m_hpgage_slider = null;
            m_controller = controller;
        }
        
        //getter:seter
        public GameObject Player_obj
        {
            get
            {
                return m_Player;
            }
            set
            {
                if(m_Player == null)
                {
                    m_Player = value;
                }
            }
        }

        public GameObject HPgage_obj
        {
            get
            {
                return m_HPgage;
            }
            set
            {
                if(m_HPgage == null)
                {
                    m_HPgage = value;
                }
            }
        }
        public string Name_Data
        {
            get
            {
                return m_name;
            }
        }

        public Color Color_Data
        {
            get
            {
                return m_nameColor;
            }
        }

        public Sprite PlayerFace_Data
        {
            get
            {
                return m_playerFace;
            }
        }

        public Vector3 InitialPos_Data
        {
            get
            {
                return m_initialPos;
            }
        }

        public Slider Hpgage_slider_Data
        {
            set
            {
                if(m_hpgage_slider == null)
                {
                    m_hpgage_slider = value;
                }
            }
        }

        public XboxController Controller_Data
        {
            get
            {
                return m_controller;
            }
        }

    }


    


    [SerializeField]
    private GameObject UICanvases;      //UI用キャンバス


    //[SerializeField]
    //Player_data P1 = new Player_data("P1", new Color(0.000f, 0.000f, 0.000f), Sprite.Create((Texture2D)Resources.Load("textures/use/Player1"), new Rect(0, 0, 584, 385), new Vector2(0.5f, 0.5f)), new Vector3(5.0f, 50.0f, 0.0f));
    //[SerializeField]
    //Player_data P2 = new Player_data("P2", new Color(0.000f, 0.000f, 0.000f), Sprite.Create((Texture2D)Resources.Load("textures/use/Player1"), new Rect(0, 0, 584, 385), new Vector2(0.5f, 0.5f)), new Vector3(10.0f, 50.0f, 0.0f));
    //[SerializeField]
    //Player_data P3 = new Player_data("P3", new Color(0.000f, 0.000f, 0.000f), Sprite.Create((Texture2D)Resources.Load("textures/use/Player1"), new Rect(0, 0, 584, 385), new Vector2(0.5f, 0.5f)), new Vector3(15.0f, 50.0f, 0.0f));
    //[SerializeField]
    //Player_data P4 = new Player_data("P4", new Color(0.000f, 0.000f, 0.000f), Sprite.Create((Texture2D)Resources.Load("textures/use/Player1"), new Rect(0, 0, 584, 385), new Vector2(0.5f, 0.5f)), new Vector3(20.0f, 50.0f, 0.0f));

    [SerializeField]
    Player_data P1;
    [SerializeField]
    Player_data P2;
    [SerializeField]
    Player_data P3;
    [SerializeField]
    Player_data P4 ;

    [SerializeField, Header("プレイヤーの復帰時の場所指定")]
    private Vector3 RevivalPos = new Vector3(2.5f, 50f, 0f);

    private Player playerCS;

    private int death_player;

    // Use this for initialization
    void Start()
    {
        playerCS = GetComponent<Player>();
        death_player = -1;

        //プレイヤーデータの生成
        switch(PlayData.Instance.playerNum)
        {
            case 1:
                P1 = new Player_data(PlayData.Instance.PlayersName[0], P1.Color_Data, PlayData.Instance.PlayersFace[0], new Vector3(10.0f, 50.0f, 0.0f), XboxController.First);
                break;
            case 2:
                P1 = new Player_data(PlayData.Instance.PlayersName[0], P1.Color_Data, PlayData.Instance.PlayersFace[0], new Vector3(10.0f, 50.0f, 0.0f), XboxController.First);
                P2 = new Player_data(PlayData.Instance.PlayersName[1], P2.Color_Data, PlayData.Instance.PlayersFace[1], new Vector3(20.0f, 50.0f, 0.0f), XboxController.Second);
                break;
            case 3:
                P1 = new Player_data(PlayData.Instance.PlayersName[0], P1.Color_Data, PlayData.Instance.PlayersFace[0], new Vector3(10.0f, 50.0f, 0.0f), XboxController.First);
                P2 = new Player_data(PlayData.Instance.PlayersName[1], P2.Color_Data, PlayData.Instance.PlayersFace[1], new Vector3(20.0f, 50.0f, 0.0f), XboxController.Second);
                P3 = new Player_data(PlayData.Instance.PlayersName[2], P3.Color_Data, PlayData.Instance.PlayersFace[2], new Vector3(30.0f, 50.0f, 0.0f), XboxController.Third);
                break;
            case 4:
                P1 = new Player_data(PlayData.Instance.PlayersName[0], P1.Color_Data, PlayData.Instance.PlayersFace[0], new Vector3(10.0f, 50.0f, 0.0f), XboxController.First);
                P2 = new Player_data(PlayData.Instance.PlayersName[1], P2.Color_Data, PlayData.Instance.PlayersFace[1], new Vector3(20.0f, 50.0f, 0.0f), XboxController.Second);
                P3 = new Player_data(PlayData.Instance.PlayersName[2], P3.Color_Data, PlayData.Instance.PlayersFace[2], new Vector3(30.0f, 50.0f, 0.0f), XboxController.Third);
                P4 = new Player_data(PlayData.Instance.PlayersName[3], P4.Color_Data, PlayData.Instance.PlayersFace[3], new Vector3(40.0f, 50.0f, 0.0f), XboxController.Fourth);
                break;
        }


        RectTransform HPgage_size = P1.HPgage_obj.GetComponent<RectTransform>();

        //プレイヤーとHPを生成
        for (int i = 0; i < PlayData.Instance.playerNum; i++)
        {
            //プレイヤーとHPバーを生成
            switch (i)
            {
                case 0:
                    P1.Player_obj = this.CreatePlayer(P1);
                    P1.HPgage_obj = this.CreateHPgage(P1, new Vector3(HPgage_size.sizeDelta.x / 2, Screen.height - 10, 0f));
                    break;

                case 1:
                    P2.Player_obj = this.CreatePlayer(P2);
                    P2.HPgage_obj = this.CreateHPgage(P2, new Vector3(Screen.width - HPgage_size.sizeDelta.x / 2, Screen.height - 10, 0));
                    break;

                case 2:
                    P3.Player_obj = this.CreatePlayer(P3);
                    P3.HPgage_obj = this.CreateHPgage(P3, new Vector3(HPgage_size.sizeDelta.x / 2, 10, 0));
                    break;

                case 3:
                    P4.Player_obj = this.CreatePlayer(P4);
                    P4.HPgage_obj = this.CreateHPgage(P4, new Vector3(Screen.width - HPgage_size.sizeDelta.x / 2, 10, 0));
                    break;
            }
        
            // HPを管理する
           // HPgage.GetComponent<Slider>().maxValue = player.transform.gameObject.GetComponent<Player>().HP;
            //SHPgage.GetComponent<Slider>().value = HPgage[i].GetComponent<Slider>().maxValue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが死んだ
        if (death_player >= 0)
        {
            // 死んだプレイヤーの生成
            //players[death_player] = (GameObject)Resources.Load("prefab/Player");
            //GameObject P = Instantiate(players[death_player], RevivalPos, Quaternion.identity);

            //switch (death_player)
            //{
            //    case 0:
            //        this.SetPlayerStatus(P, XboxController.First, P1.Name_Data, PlayData.Instance.PlayersFace[death_player]);
            //        break;
            //    case 1:
            //        this.SetPlayerStatus(P, XboxController.Second, P2.Name_Data, PlayData.Instance.PlayersFace[death_player]);
            //        break;
            //    case 2:
            //        this.SetPlayerStatus(P, XboxController.Third, P3.Name_Data, PlayData.Instance.PlayersFace[death_player]);
            //        break;
            //    case 3:
            //        this.SetPlayerStatus(P, XboxController.Fourth, P4.Name_Data, PlayData.Instance.PlayersFace[death_player]);
            //        break;
            //    default:
            //        break;
            //}
            //hpgage_slider[death_player].value = players[death_player].transform.gameObject.GetComponent<Player>().Damage(players[death_player].transform.gameObject.GetComponent<Player>().HP / 10f);
            death_player = -1;
        }
    }

    /// <summary>
    /// プレイヤーを生成
    /// </summary>
    /// <param name="player">プレイヤーオブジェクトデータ</param>
    /// <param name="i">何番目のプレイヤーか</param>
    private GameObject CreatePlayer(Player_data player_data)
    {
        //プレイヤーを生成
        GameObject player = Instantiate(player_data.Player_obj, player_data.InitialPos_Data, Quaternion.identity);
        //プレイヤーの設定
        this.SetPlayerStatus(player, player_data.Controller_Data, player_data.Name_Data, player_data.PlayerFace_Data);

        return player;

       
    } 
    /// <summary>
    /// プレイヤーのステータスを設定する
    /// </summary>
    /// <param name="player">プレイヤー</param>
    /// <param name="controllerNamber">コントローラー番号</param>
    private void SetPlayerStatus(GameObject player, XboxController controllerNamber, string name, Sprite FaceTextures)
    {
        //キャラの顔をセット
        SpriteRenderer playerFace = player.GetComponent<SpriteRenderer>();
        playerFace.sprite = FaceTextures;

        //名前
        player.name = name;

        //コントローラーをセット
        Player playerScript = player.GetComponent<Player>();
        playerScript.GetControllerNamber = controllerNamber;

        //カメラのターゲット用ダミーを取得する
        name += "_dummy";

        foreach(Transform child in this.transform)
        {
            if(child.name == name)
            {
                child.transform.parent = null;

                child.transform.parent = player.gameObject.transform;

                child.transform.position = player.transform.position;
                break;
            }
        }
    }

    /// <summary>
    /// HPゲージの生成
    /// </summary>
    /// <param name="HPgage">HPゲージ</param>
    /// <param name="i">何番目か</param>
    private GameObject CreateHPgage(Player_data player_data, Vector3 pos)
    {
        //プレイヤーを生成
        GameObject HPgage = Instantiate(player_data.HPgage_obj, pos, Quaternion.identity, UICanvases.transform);

        HPgage.name = player_data.Name_Data + "_HPgage";

        //名前の設定
        TextMeshProUGUI name = HPgage.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        name.text = player_data.Name_Data;
        name.color = player_data.Color_Data;

        return HPgage;
    }


    /// <summary>
    /// 各プレイヤーの画像
    /// </summary>
    //public GameObject[] Player_textuer
    //{
    //    set
    //    {
    //        player_textuer = new GameObject[value.Length];
    //        player_textuer = value;
    //    }
    //}

    public int destroy_p
    {
        set
        {
            death_player = value;
        }
    }

}
