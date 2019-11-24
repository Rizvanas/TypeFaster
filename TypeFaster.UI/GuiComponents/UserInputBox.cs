using System;

namespace TypeFaster.UI.GuiComponents
{
    public class UserInputBox : TextBox
    {
        public string UserInput { get; set; }
        public ConsoleColor MatchingInputColor { get; set; }

        public UserInputBox(
            string title,
            string info,
            int leftPos, 
            int topPos, 
            int maxWidth, 
            int maxHeight = 0)
            : base(title, info, leftPos, topPos, maxWidth, maxHeight)
        {
            MatchingInputColor = ConsoleColor.DarkGreen;
        }

        protected override void WriteAt(string s, int left, int top, int x, int y)
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

        protected override void DrawInfo()
        {
            var tempTopPos = TopPos;
            var tempTopPosOffset = 1;
            
            foreach (var infoItem in _info)
            {
                var tempLeftPos = LeftPos;
                foreach (var letter in infoItem)
                {
                    if (tempLeftPos >= LeftPos && 
                        tempLeftPos < LeftPos + UserInput.Length - ((tempTopPosOffset-1) * (Width)) && 
                       tempTopPosOffset - 1 <= UserInput.Length / (Width-2))
                    {
                        Console.BackgroundColor = MatchingInputColor;
                    }

                    WriteAt(letter.ToString(), tempLeftPos, tempTopPos, 1, tempTopPosOffset);
                    Console.BackgroundColor = ConsoleColor.Black;
                    tempLeftPos++;
                }
                tempTopPosOffset++;
            }
        }
    }
}
