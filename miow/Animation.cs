using System.Numerics;
using Raylib_cs;

namespace miow
{
    public class Animation
    {
        public Animation(int frameWidth, int frameHeight, Texture2D texture)
        {
            Texture = texture;
            TextureParts = new List<Rectangle>();

            MaxFrames = texture.width / frameWidth;
            CurrentFrame = 0;

            for (int i = 0; i < MaxFrames; i++)
            {
                var x = i * frameWidth;
                var y = frameHeight;

                TextureParts.Add(new Rectangle(x, y, frameWidth, frameHeight));
            }
        }

        public List<Rectangle> TextureParts { get; set; }
        public int MaxFrames { get; private set; }
        public int CurrentFrame { get; set; }
        public Texture2D Texture { get; }

        private float currentAnimationTime = 0;
        private readonly float maxAnimationTime = .08f;

        public void Update(float dt)
        {
            currentAnimationTime += dt;

            if (currentAnimationTime >= maxAnimationTime)
            {
                CurrentFrame++;
                if (CurrentFrame == MaxFrames)
                {
                    CurrentFrame = 0;
                }
                currentAnimationTime = 0;
            }

        }

        public void Draw(Rectangle position){
            Raylib.DrawTexturePro(this.Texture, this.TextureParts[CurrentFrame], position, Vector2.Zero, 0, Color.WHITE );
        }

    }
}