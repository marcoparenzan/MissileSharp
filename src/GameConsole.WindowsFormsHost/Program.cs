using MissileSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameConsole.WindowsFormsHost
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var stage = new Stage();
            stage.Initialize();

            var form = new DoubleBufferForm();
            form.Text = Stage.Title;
            form.ClientSize = Stage.ClientSize;
            form.KeyDown += (s, e) => {

                switch (e.KeyCode)
                {
                    case Keys.D1:
                        stage.SetFireTrigger(0);
                        break;
                    case Keys.D2:
                        stage.SetFireTrigger(1);
                        break;
                    case Keys.D3:
                        stage.SetFireTrigger(2);
                        break;
                    default:
                        break;
                }
            
            };
            form.KeyUp += (s, e) => {

                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        form.Close();
                        break;
                    case Keys.D1:
                        stage.ResetFireTrigger(0);
                        break;
                    case Keys.D2:
                        stage.ResetFireTrigger(1);
                        break;
                    case Keys.D3:
                        stage.ResetFireTrigger(2);
                        break;
                    default:
                        break;
                }

            };
            form.MouseMove += (s, e) => {

                stage.SetMouseTrigger((e.X, e.Y));

            };
            form.MouseLeave += (s, e) => {

                stage.ResetMouseTrigger();

            };
            form.Show();

            var refrate = 50;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)Math.Round(1000.0 / refrate, 0);
            timer.Tick += (s, e) =>
            {
                var start = DateTime.Now;

                stage.Render(form.g);
                form.Invalidate();

                stage.Update(timer.Interval);

                var stop = DateTime.Now;
                var frameRate = (int)Math.Round(1000.0 / (stop - start).TotalMilliseconds, 0);
            };
            timer.Start();

            Application.Run(form);
        }
    }
}
