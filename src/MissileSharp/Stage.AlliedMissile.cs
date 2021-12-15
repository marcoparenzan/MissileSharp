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
        static Pen alliedMissileSpriteTravelPen = new Pen(Color.Blue, 3);
        static Brush alliedMissileSpriteExplodeBrush = Brushes.Cyan;
        static Brush alliedMissileSpriteImplodeBrush = Brushes.Gray;


        private void Initialize(int i, ref AlliedMissileSprite that)
        {
        }

        private void Render(int i, ref AlliedMissileSprite that, Graphics g)
        {
            if (that.Next.HasValue) return;

            switch (that.state)
            {
                case AlliedMissileSprite.StateId.Implosion: // implosion
                    g.FillEllipse(alliedMissileSpriteImplodeBrush, that.Pos.x - that.r, that.Pos.y - that.r, 2 * that.r + 1, 2 * that.r + 1);
                    break;
                case AlliedMissileSprite.StateId.Explosion: // explosion
                    g.FillEllipse(alliedMissileSpriteExplodeBrush, that.Pos.x - that.r, that.Pos.y - that.r, 2 * that.r + 1, 2 * that.r + 1);
                    break;
                case AlliedMissileSprite.StateId.Travel:
                    g.DrawLine(alliedMissileSpriteTravelPen, that.Pos.x, that.Pos.y, that.source.x, that.source.y);
                    break;
                default: // no state...delete!
                    break;
            }
        }

        private void Update(int ms, int i, ref AlliedMissileSprite that)
        {
            if (that.Next.HasValue) return;

            switch (that.state)
            {
                case AlliedMissileSprite.StateId.Implosion: // implosion
                    if (CollisionOf(ref that))
                    {
                        score_count += 10;
                        that.state = AlliedMissileSprite.StateId.Dead;
                        break;
                    }

                    that.r--;
                    that.state = that.r <= 0 ? AlliedMissileSprite.StateId.Dead : AlliedMissileSprite.StateId.Implosion; // evaluate new state
                    // what happens next is not important
                    break;
                case AlliedMissileSprite.StateId.Explosion: // explosion
                    if (CollisionOf(ref that))
                    {
                        score_count += 10;
                        that.state = AlliedMissileSprite.StateId.Dead;
                        break;
                    }

                    that.r++;
                    that.state = that.r >= 20 ? AlliedMissileSprite.StateId.Implosion : AlliedMissileSprite.StateId.Explosion; // evaluate new state
                    if (that.state == AlliedMissileSprite.StateId.Implosion)
                    {
                        // nothing to do
                    }
                    break;
                case AlliedMissileSprite.StateId.Travel:
                    that.Pos += that.Speed;
                    //if (that.state0.g > that.state0.l) that.source += that.Speed;
                    that.g += that.a;
                    that.state = that.g >= that.d ? AlliedMissileSprite.StateId.Explosion : AlliedMissileSprite.StateId.Travel; // evaluate new state
                    if (that.state == AlliedMissileSprite.StateId.Explosion)
                    {
                        that.Speed = (0, 0); // stop!
                        that.r = 1;
                    }
                    break;
                default: // no state...delete!
                    // read to the linked list
                    that.Next = nextFreeAlliedMissile;
                    nextFreeAlliedMissile = i;
                    break;
            }
        }

        bool CollisionOf(ref AlliedMissileSprite that)
        {
            for (var i = 0; i < enemyMissiles.Length; i++)
            {
                if (enemyMissiles[i].Next.HasValue) continue;
                if (enemyMissiles[i].state != EnemyMissileSprite.StateId.Travel) continue; // can collide if yet traveling

                var dx = enemyMissiles[i].Pos.x-that.Pos.x;
                var dy = enemyMissiles[i].Pos.y-that.Pos.y;
                var d = Math.Sqrt(dx*dx+dy*dy);
                if (d<=that.r) // state1...but 2??!?!?!
                {
                    enemyMissiles[i].state = EnemyMissileSprite.StateId.Explosion;
                    enemyMissiles[i].Speed = 0;
                    return true;
                }
            }
            return false;
        }
    }
}
