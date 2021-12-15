using GameConsole.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameConsole.WindowsFormsHost
{
    public partial class DoubleBufferForm : Form
    {
        public DoubleBufferForm()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Font = new Font("Consolas", 12);
            this.StartPosition = FormStartPosition.CenterScreen;
            Cursor.Hide();
        }

        BufferedGraphics bufferedGraphics;

        bool Suspended { get;  set; } = true;

        public Graphics g => bufferedGraphics.Graphics;

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            if (this.bufferedGraphics != null)
            {
                this.Suspended = true;
                this.bufferedGraphics.Dispose();
                this.bufferedGraphics = null;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.bufferedGraphics == null)
            {
                this.bufferedGraphics = BufferedGraphicsManager.Current.Allocate(e.Graphics,
                    this.ClientRectangle
                );

                this.Suspended = false;
            }
            else
            {
                this.bufferedGraphics.Render(e.Graphics);
            }
        }
    }
}
