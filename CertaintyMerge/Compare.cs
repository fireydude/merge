using System;

namespace Certainty.Merge
{
    class Compare
    {
        public string PrefixText { get; set; }
        public string C1Title { get; set; }
        public string C1Content { get; set; }
        public string C2Title { get; set; }
        public string C2Content { get; set; }

        const string startDelimeter = "<<<<<<<";
        const string splitDelimeter = "=======";
        const string endDelimeter = ">>>>>>>";
        public static bool GetNext(string mergeText, out Compare result, out string remainingMergeText)
        {
            var hasCompare = false;
            result = null;
            remainingMergeText = null;
            var c1StartIndex = mergeText.IndexOf(startDelimeter);
            if (c1StartIndex > 0)
            {
                hasCompare = true;
                var c1TitleEndIndex = mergeText.IndexOf(Environment.NewLine, c1StartIndex);
                var compareSplitIndex = mergeText.IndexOf(splitDelimeter, c1StartIndex);
                var c2ContentEndIndex = mergeText.IndexOf(endDelimeter);
                var c2EndTitleIndex = mergeText.IndexOf(Environment.NewLine, c2ContentEndIndex);

                result = new Compare
                {
                    PrefixText = mergeText.Substring(0, c1StartIndex),
                    C1Title = mergeText.Substring(c1StartIndex + 7, c1TitleEndIndex - c1StartIndex - 7),
                    C1Content = mergeText.Substring(c1TitleEndIndex, compareSplitIndex - c1TitleEndIndex),
                    C2Content = mergeText.Substring(compareSplitIndex + 7, c2ContentEndIndex - compareSplitIndex - 7),
                    C2Title = mergeText.Substring(c2ContentEndIndex + 7, c2EndTitleIndex - c2ContentEndIndex - 7)
                };
                remainingMergeText = mergeText.Substring(c2EndTitleIndex);
            }
            return hasCompare;
        }
    }
}