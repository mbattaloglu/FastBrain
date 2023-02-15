using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Grimanda.Common
{
    public class CoreGameScreen : Grimanda.Common.GrimandaWindow
    {
        public TextMeshProUGUI TMPScore;
        public void UpdateScoreText()
        {
            TMPScore.text = gameController.coreGame.GetScore().ToString();
        }


        public void UpdateCoinCountText()
        {
            // Dont erase this
        }

        public void PauseOnClick()
        {
            gameController.soundManager.PlaySoundClip(SoundNames.ButtonClick1);
            gameController.coreGame.PlayerPaused();
        }

    }
}
