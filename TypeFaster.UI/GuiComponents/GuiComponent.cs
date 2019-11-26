using System;
using System.Collections.Generic;
using System.Linq;

namespace TypeFaster.UI.GuiComponents
{
    public abstract class GuiComponent
    {
        public int LeftPos { get; set; }
        public int TopPos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public GuiComponent(int leftPos, int topPos, int width, int height)
        {
            LeftPos = leftPos;
            TopPos = topPos;
            Width = width;
            Height = height;
        }

        public abstract void Render(string data);

        protected IEnumerable<string> GetDataForDrawing(string data)
        {
            do
            {
                string dataItem;
                if (data.Length < Width)
                {
                    dataItem = data;
                    data = "";
                }
                else
                {
                    var indexOfNearestSpace = data.LastIndexOf(' ', Width - 3);
                    dataItem = data.Substring(0, indexOfNearestSpace + 1);
                    data = data.Substring(indexOfNearestSpace + 1);
                }
                yield return dataItem;

            } while (data.Length != 0);
        }

        protected void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void ClearComponent()
        {
            for (int i = TopPos; i <= TopPos + Height; i++)
            {
                ClearCurrentConsoleLine(LeftPos, i, Width);
            }
        }

        protected void ClearCurrentConsoleLine(int cursorLeft, int cursorTop, int width)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(new string(' ', width));
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
    }
}
