using System.Collections.Generic;
using System.Linq;

namespace TypeFaster.UI.GuiComponents
{
    public abstract class GuiComponent
    {
        protected List<string> _info;
        public int LeftPos { get; set; }
        public int TopPos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public GuiComponent(string info, int leftPos, int topPos, int width, int height)
        {
            LeftPos = leftPos;
            TopPos = topPos;
            Width = width;
            _info = GetInfoForDrawing(info).ToList();
            Height = height == 0 ? _info.Count + 2 : height;
        }

        public abstract void Render();

        protected IEnumerable<string> GetInfoForDrawing(string info)
        {
            do
            {
                string infoItem;
                if (info.Length < Width)
                {
                    infoItem = info;
                    info = "";
                }
                else
                {
                    var indexOfNearestSpace = info.LastIndexOf(' ', Width - 3);
                    infoItem = info.Substring(0, indexOfNearestSpace + 1);
                    info = info.Substring(indexOfNearestSpace + 1);
                }
                yield return infoItem;

            } while (info.Length != 0);
        }
    }
}
