﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Weapon_Z : WeaponBlocController
{
    private GameObject self_destruct_effect;// 自爆エフェクト

    protected override void Awake()
    {
        self_destruct_effect = Resources.Load<GameObject>("prefab/Effect/Explosion");

        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// 攻撃文字
    /// </summary>
    /// <param name="shot">使用した座標</param>
    /// <returns>文字攻撃をしたら(true)していなかったら(fasle)</returns>
    protected override bool AttackMozi(Vector3 shot)
    {
        switch (mozi)
        {
            case "ざ":
            case "ザ":
                this.Attack_ZA(shot);
                return true;

            case "じ":
            case "ジ":
                this.Attack_ZI(shot);
                return true;

            case "ず":
            case "ズ":
                this.Attack_ZU(shot);
                return true;

            case "ぜ":
            case "ゼ":
                this.Attack_ZE(shot);
                return true;

            case "ぞ":
            case "ゾ":
                this.Attack_ZO(shot);
                return  true;
        }

        return false;
    }

    /// <summary>
    /// 『ざ・ザ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_ZA(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『じ・ジ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_ZI(Vector3 shot)
    {
        var hitobj = Instantiate(self_destruct_effect, this.transform.position + transform.forward, Quaternion.identity) as GameObject;
        DamageValue = 50;
        PSManager_cs.Player_ReceiveDamage(this.transform.parent.gameObject, this.gameObject, this.transform.parent.GetComponent<Player>().PlayerNumber_data);
    }

    /// <summary>
    /// 『ず・ズ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_ZU(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『ぜ・ゼ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_ZE(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『ぞ・ゾ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_ZO(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }
}
