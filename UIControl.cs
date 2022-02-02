using Godot;
using System;

public class UIControl : Control
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PlayerObserver po = new UIPlayerObserver();
        //player's observer get
        //add this po to the player
    }

    private class UIPlayerObserver : PlayerObserver {
        protected ProgressBar healthProgress;

        void PlayerObserver.PlayerHealthUpdate(float health){
            healthProgress.Value = health;
        }
        void PlayerObserver.PlayerDied(){

        }
    }
    
}
