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
                var nextInputSplitPoint = 0;
                if (inputSplitPoint > data[i].Length)
                {
                    nextInputSplitPoint = inputSplitPoint - data[i].Length;
                    inputSplitPoint = data[i].Length;
                }

                var nextPreErrorSplitPoint = 0;
                if (preErrorSplitPoint > data[i].Length)
                {
                    nextPreErrorSplitPoint = preErrorSplitPoint - data[i].Length;
                    preErrorSplitPoint = data[i].Length;
                }

                Console.BackgroundColor = MatchingInputColor;
                Console.ForegroundColor = ConsoleColor.Black;
                WriteAt(data[i].Substring(0, preErrorSplitPoint), LeftPos, TopPos, 1, i + 1);

                Console.BackgroundColor = ErrorColor;
                Console.ForegroundColor = ConsoleColor.White;
                WriteAt(data[i].Substring(preErrorSplitPoint, inputSplitPoint - preErrorSplitPoint),
                    LeftPos + preErrorSplitPoint, TopPos, 1, i + 1);

                Console.BackgroundColor = ConsoleColor.Black;
                WriteAt(data[i].Substring(inputSplitPoint), LeftPos + inputSplitPoint, TopPos, 1, i + 1);

                inputSplitPoint = nextInputSplitPoint;
                preErrorSplitPoint = nextPreErrorSplitPoint;
            }
        }
    }
}
