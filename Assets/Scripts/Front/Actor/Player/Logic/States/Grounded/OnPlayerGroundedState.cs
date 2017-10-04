﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class OnPlayerGroundedState : IPlayerState {

		/// <summary>
		/// ステート開始時
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnEnter(PlayerComponent arg_player) {

		}

		/// <summary>
		/// ステート中の更新
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnUpdate(PlayerComponent arg_player) {
			
		}

		/// <summary>
		/// ステート終了時
		/// </summary>
		/// <param name="arg_player"></param>
		public virtual void OnExit(PlayerComponent arg_player) {

		}

		public virtual IPlayerState GetNextState(PlayerComponent arg_player) {
			return new PlayerGroundedIdleState();
		}

	}
}