using System;
using System.Collections.Generic;

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
            Width = width;
            Height = height;
            LeftPos = leftPos;
            TopPos = topPos;
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
