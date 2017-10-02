﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

namespace ToyBox.Kuno{
	public class Button : MonoBehaviour {

		//このボタンで開くシャッター
		[SerializeField]
		GameObject m_obj_shutter;

		//通常時と押されている時、それぞれのスプライト
		[SerializeField]
		Sprite m_spr_newtoral;
		[SerializeField]
		Sprite m_spr_pushed;

		//自身の必要なコンポーネント
		SpriteRenderer m_sRend_;


		// Use this for initialization
		void Start () {
			m_sRend_ = GetComponent<SpriteRenderer> ();
		}
		
		// Update is called once per frame
		void Update () {
		}

		void OnTriggerEnter2D(Collider2D arg_col){
			m_sRend_.sprite = m_spr_pushed;
		}
		void OnTriggerExit2D(Collider2D arg_col){
			m_sRend_.sprite = m_spr_newtoral;
		}



	}

}