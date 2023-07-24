using System.Numerics;
using Raylib_cs;

namespace miow
{
    public class Mob
    {
        public Mob(string name, Animation Idle)
        {
            this.Name = name;
            this.Idle = Idle;
            this.Position = new Rectangle(0,0,512,512);

        }

        public string Name { get; }
        public Animation Idle { get; }
        public Rectangle Position { get; set; }

        public void Update(float dt)
        {
            Idle.Update(dt);
        }

        public void Draw()
        {
            Idle.Draw(this.Position);
        }

    }

    public enum MobState
    {
        idling,
        running,
        playing,
        sleeping
    }
}