using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class BezierDisplay : UserControl
    {
        public decimal incr = 0.01m;
        public bool helperlines = false;
        public float thickness = 2f;

        private Point p0 = Point.Empty;
        private Point p1 = Point.Empty;
        private Point p2 = Point.Empty;

        public BezierDisplay()
        {
            InitializeComponent();
        }

        private PointF QuadraticBezier(decimal t)
        {
            decimal inv = 1 - t;
            double t1 = Math.Pow((double)inv, 2);
            PointF e1 = new PointF((float)(p0.X * t1), (float)(p0.Y * t1));

            decimal t2 = (inv * 2) * t;
            e1.X += (float)(p1.X * t2);
            e1.Y += (float)(p1.Y * t2);

            double t3 = Math.Pow((double)t, 2);
            e1.X += (float)(p2.X * t3);
            e1.Y += (float)(p2.Y * t3);
            return e1;
        }

        private void BezierDisplay_MouseMove(object sender, MouseEventArgs e)
        {
                Cursor.Hide();
                this.Update();
                this.Refresh();
        }
        private void BezierDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (p0 == Point.Empty)
            {
                p0 = this.PointToClient(Cursor.Position);
                return;
            }

            if (p2 == Point.Empty)
            {
                p2 = this.PointToClient(Cursor.Position);
                return;
            }

            if (p1 == Point.Empty)
            {
                p1 = this.PointToClient(Cursor.Position);
                this.Refresh();
                return;
            }

            p1 = this.PointToClient(Cursor.Position);

        }
        private void BezierDisplay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(p0, new Size(5, 5)));
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(p1, new Size(5, 5)));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(p2, new Size(5, 5)));

            PointF highest = Point.Empty;
            PointF lowest = Point.Empty;

            if (p0 == Point.Empty || p1 == Point.Empty || p2 == Point.Empty)
            {
                e.Graphics.DrawEllipse(Pens.Black, new RectangleF(this.PointToClient(Cursor.Position).X, this.PointToClient(Cursor.Position).Y, 5f, 5f));
            }
            else
            {
                Pen pen = new Pen(Color.Black,thickness);

                p1 = this.PointToClient(Cursor.Position);
                PointF last = p0;
                decimal t = 0m;
                while (t < 1m)
                {
                    PointF p = QuadraticBezier(t);
                    e.Graphics.DrawLine(pen, last, p);
                    last = p;

                    if (helperlines&&(highest == Point.Empty || p.Y > highest.Y))
                    {
                        highest = p;
                    }
                    if (helperlines&&(lowest == Point.Empty || p.Y < lowest.Y))
                    {
                        lowest = p;
                    }

                    t += incr;
                }
                e.Graphics.DrawLine(pen, last, p2);
            }

            if (helperlines)
            {
                e.Graphics.DrawLine(Pens.Green, p0, p1);
                e.Graphics.DrawLine(Pens.Green, p1, p2);

                //e.Graphics.DrawLine(Pens.Red, p0, p2);
                Pen dashPen = new Pen(Color.Blue, 1);
                dashPen.DashPattern = new float[] { 5, 3 };

                e.Graphics.DrawLine(dashPen, p0, new PointF(p0.X, p1.Y));
                e.Graphics.DrawLine(dashPen, new PointF(p0.X, p1.Y), p1);
                e.Graphics.DrawLine(dashPen, p2, new PointF(p0.X, p1.Y));

                e.Graphics.DrawLine(dashPen, p2, new PointF(p2.X, p1.Y));
                e.Graphics.DrawLine(dashPen, new PointF(p2.X, p1.Y), p1);
               // e.Graphics.DrawLine(dashPen, new PointF(p2.X, p1.Y), p0);
               //TODO: FILL THE GAP CREATED SOMEWHERE HEERE

                dashPen.Color = Color.Red;
                e.Graphics.DrawLine(dashPen, new PointF(p0.X,highest.Y), new PointF(p2.X, highest.Y));
                e.Graphics.DrawLine(dashPen, new PointF(p2.X, highest.Y), p2);

                e.Graphics.DrawLine(dashPen, new PointF(p0.X,lowest.Y), new PointF(p2.X, lowest.Y));
                e.Graphics.DrawLine(dashPen, p0, new PointF(p2.X, lowest.Y));

                dashPen.Color = Color.Pink;
                if (highest.Y > p0.Y)
                {
                    e.Graphics.DrawLine(dashPen, highest, new PointF(highest.X, lowest.Y));
                }
                else
                {
                    e.Graphics.DrawLine(dashPen, lowest, new PointF(lowest.X, highest.Y));
                }
            }
        }
    }
}
