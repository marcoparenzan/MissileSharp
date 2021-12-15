using System.Drawing;

namespace GameConsole.Core
{
    public interface IStage
    {
        void Render(Graphics g);
        void Update(int ms);
    }
}