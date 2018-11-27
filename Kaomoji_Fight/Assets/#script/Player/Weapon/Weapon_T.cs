﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_T : WeaponBlocController {

    protected override void Awake()
    {
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
            case "た":
            case "タ":
                this.Attack_TA(shot);
                return true;

            case "ち":
            case "チ":
                this.Attack_TI(shot);
                return true;

            case "つ":
            case "ツ":
                this.Attack_TU(shot);
                return true;

            case "て":
            case "テ":
                this.Attack_TE(shot);
                return true;

            case "と":
            case "ト":
                this.Attack_TO(shot);
                return true;
        }

        return false;
    }

    /// <summary>
    /// 『た・タ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_TA(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『ち・チ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_TI(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『つ・ツ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_TU(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『て・テ』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_TE(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// 『と・ト』で攻撃
    /// </summary>
    /// <param name="shot">使用した座標</param>
    private void Attack_TO(Vector3 shot)
    {
        //仮//////////////////////////////////////////////////////////////////
        base.SpecifiedOperation_NoneWeapon(shot);
        //仮//////////////////////////////////////////////////////////////////
    }
}