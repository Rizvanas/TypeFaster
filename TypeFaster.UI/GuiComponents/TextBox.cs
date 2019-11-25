using System;
using System.Linq;
using TypeFaster.UI.Enums;

namespace TypeFaster.UI.GuiComponents
{
    public class TextBox : GuiComponent
    {
        public string Title { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor InfoColor { get; set; }
        protected string previousData = null;

        public TextBox(string title, int leftPos, int topPos, int maxWidth, int maxHeight = 0)
            : base(leftPos, topPos, maxWidth, maxHeight)
        {
            Title = title;
            BorderColor = ConsoleColor.White;
            InfoColor = ConsoleColor.White;
        }

        public override void Render(string data)
        {
            if (previousData != null && data != previousData)
            {
                previousData = data;
                var previousConsoleColor = Console.ForegroundColor;
                Console.SetCursorPosition(LeftPos, TopPos);
                DrawData(data);
                DrawTopAndBottom();
                DrawSides();
            }
        }

        protected virtual void WriteAt(string s, int left, int top, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(left + x, top + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected virtual void DrawTopAndBottom()
        {
            for (int i = 0; i < Width; i++)
            {
                if (i == 0)
                {
                    WriteAt(UISymbol.TOP_LEFT_CORNER, LeftPos, TopPos, i, 0);
                    WriteAt(UISymbol.BOTTOM_LEFT_CORNER, LeftPos, TopPos, i, Height);
                }
                else if (i == Width - 1)
                {
                    WriteAt(UISymbol.TOP_RIGHT_CORNER, LeftPos, TopPos, i, 0);
                    WriteAt(UISymbol.BOTTOM_RIGHT_CORNER, LeftPos, TopPos, i, Height);
                }
                else
                {
                    WriteAt(UISymbol.HORIZONTAL_LINE, LeftPos, TopPos, i, 0);
                    WriteAt(UISymbol.HORIZONTAL_LINE, LeftPos, TopPos, i, Height);
                }
            }
        }

        protected virtual void DrawSides()
        {
            for (int i = 1; i < Height; i++)
            {
                WriteAt(UISymbol.VERTICAL_LINE, LeftPos, TopPos, 0, i);
                WriteAt(UISymbol.VERTICAL_LINE, LeftPos, TopPos, Width - 1, i);
            }
        }

        protected virtual void DrawData(string data)
        {
            var topOffset = 1;
            var dataForDrawing = GetDataForDrawing(data).ToArray();
            Height = dataForDrawing.Length;

            foreach (var dataItem in dataForDrawing)
            {
                WriteAt(dataItem, LeftPos, TopPos, 1, topOffset++);
            }
        }
    }
}
