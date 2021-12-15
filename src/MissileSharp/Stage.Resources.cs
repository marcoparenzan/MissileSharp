using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileSharp
{
    public partial class Stage
    {
        public static Font f = new Font("Consolas", 10);
        public static string Title = "Missile#";
        public static Size ClientSize = new Size(960, 640);

        private Bitmap background;
        private Bitmap spriteSheet;
        private Rectangle[] frames = new Rectangle[(int)FrameId.End];

        enum FrameId
        {
            City = 0,
            AlliedMissileSprite,
            CrossHair,
            End
        }

        public void Resources()
        {
            var backgroundStream = typeof(Stage).Assembly.GetManifestResourceStream(typeof(Stage), $"Background.png");
            this.background = (Bitmap)Image.FromStream(backgroundStream);

            var spriteSheetStream = typeof(Stage).Assembly.GetManifestResourceStream(typeof(Stage), $"Spritesheet.png");
            this.spriteSheet = (Bitmap)Image.FromStream(spriteSheetStream);
            frames[(int)FrameId.City] = new Rectangle(12, 0, 60, 30);
            frames[(int)FrameId.AlliedMissileSprite] = new Rectangle(0, 0, 12, 18);
            frames[(int)FrameId.CrossHair] = new Rectangle(72, 0, 27, 27);
        }
    }
}
