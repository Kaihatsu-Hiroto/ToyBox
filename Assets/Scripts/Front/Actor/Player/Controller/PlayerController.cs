﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class PlayerController : ObjectBase ,IPlayable {

		public Player m_player { get; private set; }

		public Arm m_arm { get; private set; }

		public Hand m_hand { get; private set; }

		public void Initialize() {
			m_player = FindObjectOfType<Player>();
			if (!m_player) { PlayerGenerate(); }
		}

		public void UpdateByFrame() {

		}

		private void PlayerGenerate() {
			Instantiate(Resources.Load<Player>("Actor/Player/Player") , m_transform);
		}

		public void OnLeftButton() {

		}

		public void OnRightButton() {

		}

		public void OnJumpButton() {

		}

		public void OnItemTap(Item arg_item) {

		}
	}
}