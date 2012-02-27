using System.Collections.Generic;
using LightingDown.Download.Core.Properties;

namespace LightingDown.Download.Core
{
    public class Calculator
    {
        public CalculatedSegment[] GetSegments(int segmentCount, long fileSize)
        {
            long minSize = Settings.Default.MinSegmentSize;
            long segmentSize = fileSize / (long)segmentCount;

            while (segmentCount > 1 && segmentSize < minSize)
            {
                segmentCount--;
                segmentSize = fileSize / (long)segmentCount;
            }

            long startPosition = 0;

            List<CalculatedSegment> segments = new List<CalculatedSegment>();

            for (int i = 0; i < segmentCount; i++)
            {
                if (segmentCount - 1 == i)
                {
                    segments.Add(new CalculatedSegment(startPosition, fileSize));
                }
                else
                {
                    segments.Add(new CalculatedSegment(startPosition, startPosition + (int)segmentSize));
                }

                startPosition = segments[segments.Count - 1].EndPosition;
            }

            return segments.ToArray();
        }
    }
}
