using System;

namespace TypeFaster.UI.GuiComponents
{
    public class UserInputBox : TextBox
    {
        public string PreErrorInput { get; set; }
        public string UserInput { get; set; }
        public ConsoleColor MatchingInputColor { get; set; }
        public ConsoleColor ErrorColor { get; set; }

        public UserInputBox(
            int leftPos, 
            int topPos, 
            int maxWidth, 
            int maxHeight = 0)
            : base(leftPos, topPos, maxWidth, maxHeight)
        {
            MatchingInputColor = ConsoleColor.DarkGreen;
        }

        public void UpdateUserInput(string userInput, string preErrorInput)
        {
            UserInput = userInput;
            PreErrorInput = preErrorInput;
        }

        protected override void DrawData(string[] data)
        {
            var inputSplitPoint = UserInput.Length;
            var preErrorSplitPoint = PreErrorInput.Length;
            
            for (int i = 0; i < data.Length; i++)
            {
                var nextInputSplitPoint = GetNextSplitPoint(inputSplitPoint, 0, data[i]);
                inputSplitPoint = GetCurrentSplitPoint(inputSplitPoint, data[i]);

                var nextPreErrorSplitPoint = GetNextSplitPoint(preErrorSplitPoint, 0, data[i]);
                preErrorSplitPoint = GetCurrentSplitPoint(preErrorSplitPoint, data[i]);

                WriteAtWithColor(data[i].Substring(0, preErrorSplitPoint), LeftPos, TopPos, 1, i + 1,
                    ConsoleColor.Black, MatchingInputColor);

                WriteAtWithColor(data[i].Substring(preErrorSplitPoint, inputSplitPoint - preErrorSplitPoint),
                    LeftPos + preErrorSplitPoint, TopPos, 1, i + 1, ConsoleColor.Black, ErrorColor);

                WriteAtWithColor(data[i].Substring(inputSplitPoint), LeftPos + inputSplitPoint, TopPos, 1, i + 1,
                    ConsoleColor.White, ConsoleColor.Black);

                inputSplitPoint = nextInputSplitPoint;
                preErrorSplitPoint = nextPreErrorSplitPoint;
            }
        }

        private int GetCurrentSplitPoint(int splitPoint, string data)
        {
            return splitPoint > data.Length ? data.Length : splitPoint;
        }

        private int GetNextSplitPoint(int splitPoint, int nextSplitPoint, string data)
        {
            return splitPoint > data.Length ? splitPoint - data.Length : nextSplitPoint;
        }
    }
}
