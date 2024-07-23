using System;
using RDR2;
using RDR2.Math;
using RDR2.Native;

namespace moonwalk
{
    public class MoonwalkingMod : Script
    {
        public MoonwalkingMod()
        {
            Tick += OnTick;
            Interval = 1;
        }

        private void OnTick(object sender, EventArgs evt)
        {
            if (!isPlayerWalking() && !isPlayerStopped()) { applyForceToPlayer(); }
        }

        private bool isPlayerWalking()
        {
            return Function.Call<bool>(Hash.IS_PED_RUNNING, Game.Player.Character.Handle);
        }

        private bool isPlayerStopped()
        {
            return Function.Call<bool>(Hash.IS_PED_STOPPED, Game.Player.Character.Handle);
        }

        private void applyForceToPlayer()
        {
            float forceMagnitude = 1.5f;
            Vector3 forceDirection = Game.Player.Character.ForwardVector * forceMagnitude;

            Function.Call(Hash.APPLY_FORCE_TO_ENTITY, Game.Player.Character.Handle, 1, forceDirection.X, forceDirection.Y, forceDirection.Z, 0.0f, 0.0f, 0.0f, 1, false, true, true, false, true);
        }
    }
}
