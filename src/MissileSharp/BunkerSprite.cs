using GameConsole.Core;

namespace MissileSharp
{
    public struct BunkerSprite
    {
        public Vec Pos { get; set; }
        public Vec Speed { get; set; }
        public int? Next { get; set; }
        public ButtonTrigger FireTrigger { get; set; }

        internal int missiles;

        public bool FireTriggered()
        {
            if (FireTrigger == default) return false;
            return FireTrigger.Triggered();
        }

        public BunkerSprite(Vec pos, Vec? speed = null)
        {
            this.Pos = pos;
            this.Speed = speed ?? (0, 0);
            this.Next = default;
            this.missiles = 10;
            this.FireTrigger = new ButtonTrigger();
        }
    }
}
