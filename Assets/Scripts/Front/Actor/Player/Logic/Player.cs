﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	[System.Serializable]
	public class Player : ActorBase {

		//--------------------------
		//UnityComponent
		//--------------------------
		
		//RigidBody
		public Rigidbody2D m_rigidbody { get; private set; }
		
		//Collider
		public BoxCollider2D m_collider { get; private set; }

		//--------------------------
		//パラメータ
		//--------------------------

		//自身の状態（Stateパターンでの実装）
		public IPlayerState m_currentState { get; private set; }
		//自身の状態（並行している状態）
		public IPlayerState m_subState { get; private set; }

		//地面に接しているか
		public bool m_isGrounded { get; private set; }

		private PlayerViewer m_viewer { get; set; }

		public void Initialize() {
			m_currentState = new PlayerIdleState();
			m_currentState.OnEnter(this);
			m_rigidbody = GetComponent<Rigidbody2D>();
			m_collider = GetComponent<BoxCollider2D>();

			m_viewer = GetComponentInChildren<PlayerViewer>();
			m_viewer.Initialize(this);
		}

		public void UpdateByFrame() {

			Debug.Log(m_currentState);

			m_isGrounded = IsGrounded();
			m_currentState.OnUpdate(this);

			m_viewer.UpdateByFrame(this);
		}
		
		/// <summary>
		/// 地面に着いているかを調べる
		/// </summary>
		/// <returns>着地しているか</returns>
		public bool IsGrounded() {
			return Physics2D.BoxCast(transform.position , m_collider.bounds.size , 0f , Vector2.down , 0.1f , 1 << LayerMask.NameToLayer("Ground"));
		}

		/// <summary>
		/// ステートを遷移させる
		/// </summary>
		/// <param name="arg_nextState">次の状態</param>
		public void StateTransition(IPlayerState arg_nextState) {
			m_currentState.OnExit(this);
			m_currentState = arg_nextState;
			m_currentState.OnEnter(this);
		}
	}
}