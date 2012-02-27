using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LightingDown.Download.Core;

namespace LightingDown.Download.Core
{
    public class ClipBoardManager
    {
        public static string GetText()
        {
            string result = string.Empty;

            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (Checker.IsvalidURL(text))
                {
                    result = text;
                }
            }

            return result;
        }
    }
}
