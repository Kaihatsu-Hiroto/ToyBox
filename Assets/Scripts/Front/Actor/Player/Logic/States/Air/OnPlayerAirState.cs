﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class OnPlayerAirState : IPlayerState {

		/// <summary>
		/// ステート開始時
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnEnter(Player arg_player) {

		}

		/// <summary>
		/// ステート中の更新
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnUpdate(Player arg_player) {

		}

		/// <summary>
		/// ステート終了時
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnExit(Player arg_player) {

		}

		public virtual IPlayerState GetNextState(Player arg_player) {
			
			if (arg_player.m_inputHandle.m_run) {
				return new PlayerAirRunState(arg_player.m_direction);
			}
			return new PlayerAirIdleState();
		}
	}
}