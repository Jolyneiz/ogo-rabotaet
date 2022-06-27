namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
            
        }

        private bool UpMove, LeftMove;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((LeftMove == true))
            {
                p.Left += 10;
            }
            if ((LeftMove == false))
            {
                p.Left -= 10;
            }
            if ((UpMove == true))
            {
                p.Top += 10;
            }
            if ((UpMove == false))
            {
                p.Top -= 10;
            }
            if ((p.Left <= ClientRectangle.Left))
            {
                LeftMove = true;
            }
            if ((p.Right >= ClientRectangle.Right))
            {
                LeftMove = false;
            }
            if ((p.Top <= ClientRectangle.Top))
            {
                UpMove = true;
            }
            if ((p.Bottom >= ClientRectangle.Bottom))
            {
                UpMove = false;
            }
        }

        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;
            public ArrayPoints(int size)
            {
                if (size <= 0) { size = 2; }
                points = new Point[size];
            }
            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }
            public void ResetPoints()
            {
                index = 0;
            }
            public int GetCountPoint()
            {
                return index;
            }
            public Point[] GetPoints()
            {
                return points;
            }
        }
        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);
        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void p_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
        }
        private void p_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }
        private void p_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoint() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                p.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }
    }
}
