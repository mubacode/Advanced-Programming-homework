// Dragon.cs
using System;

namespace DragonHunt.Library
{
    public class Dragon : Character
    {
        public int ExperienceReward { get; set; }

        // Event for breathing fire
        public delegate void FireBreathHandler(int fireIntensity);
        public event FireBreathHandler OnFireBreath;

        public int BreatheFire()
        {
            int fireIntensity = CalculateFireIntensity();

            // Invoke the event if handlers are attached
            OnFireBreath?.Invoke(fireIntensity);

            return fireIntensity;
        }

        private int CalculateFireIntensity()
        {
            // Calculate fire intensity based on level, strength, and intelligence
            return (Level * 5) + (Strength / 2) + Intelligence;
        }
    }
}