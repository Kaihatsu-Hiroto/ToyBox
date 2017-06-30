﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class SceneManager : MonoBehaviour {
		
		public Scene m_currentScene { get; private set; }

		private enum Phase {
			ENTER,
			UPDATE,
			EXIT
		}

		private Phase m_currentPhase;
		private Scene m_nextScene;

		private Fade m_fade { get; set; }

		public void Initialize() {
			m_fade = Instantiate(Resources.Load<GameObject>("Effect/FadeCanvas")).GetComponentInChildren<Fade>();
			m_fade.Initialize();
			m_fade.Fill(Color.black);
			m_currentScene = new Title.TitleScene();
			m_nextScene = null;
			m_currentPhase = Phase.ENTER;
		}

		public void UpdateByFrame() {
			if (m_fade.isActive) {	m_fade.UpdateByFrame(); return; }

			switch (m_currentPhase) {
				case Phase.ENTER:
				m_currentScene.OnEnter();
				m_fade.StartFade(new FadeIn() , Color.black , 3.0f);
				m_currentPhase = Phase.UPDATE;
				break;
				case Phase.UPDATE:
				if (Input.GetKeyDown(KeyCode.Space)) {
					SceneTransition(new Main.MainScene());
				}
				m_currentScene.OnUpdate();
				break;
				case Phase.EXIT:
				m_currentScene.OnExit();
				m_currentScene = m_nextScene;
				m_nextScene = null;
				m_currentPhase = Phase.ENTER;
				break;
			}
		}

		public void SceneTransition(Scene arg_nextScene) {
			m_nextScene = arg_nextScene;
			m_currentPhase = Phase.EXIT;
			m_fade.StartFade(new FadeOut() , Color.black , 3.0f);
		}

		public void SceneTransition(Scene arg_nextScene,Color arg_fadeColor) {
			m_nextScene = arg_nextScene;
			m_currentPhase = Phase.EXIT;
			m_fade.StartFade(new FadeOut() , arg_fadeColor , 3.0f);
		}
	}
}