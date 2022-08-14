using System.Numerics;
using HexMapCommands;

namespace HexMap
{
    public partial class MapGenerator : Form
    {
        private bool _isPictureSet => PictureBox.Image != null;

        private MapConsole.Console _console;

        private Bitmap _map;
        private Graphics _g;
        private Brush _color;

        public MapGenerator()
        {
            InitializeComponent();
            _console = new MapConsole.Console();

            //_console.AddModule(typeof(TestCommands));
            _console.AddModule(typeof(MapCommands));
            _console.AddModule(typeof(ConsoleCommands));

            ConsoleInput.KeyDown += ConsoleInput_KeyDown;

            _color = Brushes.Red;
        }

        private void ConsoleInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void Send()
        {
            string input = ConsoleInput.Text;

            if (input.Length == 0)
                return;

            ConsoleInput.Clear();

            ConsolePrint(input);

            var outputs = _console.ParseInput(input);
            foreach(string output in outputs)
            {
                if (output.StartsWith("SYS:"))
                    SystemCommand(output);
                else
                    ConsolePrint(output);
            }
        }

        private void ConsolePrint(string text)
        {
            text = text.Replace("\n", Environment.NewLine);
            ConsoleOutput.AppendText($"{_console.OutputPrefix}{text}{Environment.NewLine}");
        }

        private void SystemCommand(string query)
        {
            string[] queryStruct = query.Split(':').Skip(1).ToArray();
            string[] args = queryStruct.Skip(1).ToArray();

            switch (queryStruct[0])
            {
                case "CONSOLE":
                    switch (queryStruct[1])
                    {
                        case "CLEAR":
                            ConsoleOutput.Clear();
                            break;

                        default:
                            break;
                    }
                    break;

                case "DRAW":
                    float r = 0;
                    (uint width, uint height) = (0, 0);
                    MapMarkup markup = MapMarkup.FourQuadrants;
                    Direction dir = Direction.NE;

                    foreach (string arg in args)
                    {
                        string key = arg.Split('/')[0];
                        string value = arg.Split('/')[1];

                        switch(key)
                        {
                            case "R":
                                r = float.Parse(value.Replace(',', '.'));
                                break;

                            case "W":
                                width = uint.Parse(value);
                                break;

                            case "H":
                                height = uint.Parse(value);
                                break;

                            case "M":
                                markup = (MapMarkup)Enum.Parse(typeof(MapMarkup), value);
                                break;

                            case "D":
                                dir = (Direction)Enum.Parse(typeof(Direction), value);
                                break;
                        }
                    }
                    Draw(r, width, height, markup, dir);
                    break;

                case "SAVE":
                    _map.Save(args[0]);
                    break;

                default:
                    break;
            }
        }

        private void Draw(float radius, uint width, uint height, MapMarkup markup, Direction direction)
        {
            int gap = 10;

            int pixelWidth = (int)Math.Round(Math.Floor(width / 2.0) * 3 * radius + (width % 2 == 1 ? 2 * radius : 0)) + gap;
            int pixelHeight = (int)Math.Round(Math.Sqrt(3) * radius * (height + 0.5)) + gap;
            _map = new Bitmap(pixelWidth, pixelHeight);

            _g = Graphics.FromImage(_map);

            Vector2 startCenter = new Vector2(gap / 2 + radius, gap / 2 + (float)Math.Sqrt(3) / 2 * radius);

            for (uint x = 0; x < width; x += 2)
            {
                Vector2 centerOffset = new Vector2(x * 3.0f / 2 * radius, 0);
                for (uint y = 0; y < height; ++y)
                {
                    Vector2 offset = centerOffset + new Vector2(0, y * (float)Math.Sqrt(3) * radius);
                    DrawRPattern(startCenter + offset, radius, y == height - 1);
                    DrawYPattern(startCenter + offset, radius, x != width - 1);
                }
            }    
            

            PictureBox.Image = _map;
        }

        private void DrawRPattern(Vector2 hexCenter, float r, bool complete)
        {
            PointF[] pattern = new PointF[4 + (complete ? 1 : 0)];

            Vector2 startPoint = new Vector2(r, 0).Rotate(-Math.PI / 3);

            for (int i = 0; i < pattern.Length; ++i)
            {
                var newCorner = hexCenter + startPoint.Rotate(-i * Math.PI / 3);
                pattern[i] = new PointF(newCorner.X, newCorner.Y);
            }

            _g.DrawLines(new Pen(_color, 1), pattern);
        }

        private void DrawYPattern(Vector2 hexCenter, float r, bool complete)
        {
            PointF[] pattern = new PointF[3];

            Vector2 startPoint = new Vector2(r, 0).Rotate(Math.PI / 3);

            for (int i = 0; i < 3; ++i)
            {
                var newCorner = hexCenter + startPoint.Rotate(-i * Math.PI / 3);
                pattern[i] = new PointF(newCorner.X, newCorner.Y);
            }

            _g.DrawLines(new Pen(_color, 1), pattern);

            if (complete)
            {
                var from = (hexCenter + startPoint.Rotate(-Math.PI / 3)).ToPointF();
                var to = new PointF(from.X + r, from.Y);
                _g.DrawLines(new Pen(_color, 1), new[] { from, to });
            }
        }
    }

    public static class Vector2Extensions
    {
        public static Vector2 Rotate(this Vector2 vector, double phiRad)
        {
            double newX = Math.Cos(phiRad) * vector.X - Math.Sin(phiRad) * vector.Y;
            double newY = Math.Sin(phiRad) * vector.X + Math.Cos(phiRad) * vector.Y;

            return new Vector2((float)newX, (float)newY);
        }

        public static PointF ToPointF(this Vector2 vector)
        {
            return new PointF(vector.X, vector.Y);
        }
    }
}