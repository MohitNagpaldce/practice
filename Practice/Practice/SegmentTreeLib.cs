using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class SegmentTreeLib
    {
        private List<int> SegmentArray;

        private List<int> inputArray;

        public List<int> order(List<int> heights, List<int> infronts)
        {
            List<int> order = new List<int>();
            List<Node> nodes = new List<Node>();
            int n;

            if (heights == null || infronts == null)
            {
                return order;
            }

            n = heights.Count;

            Bit bit = new Bit(n);

            for (int i = 1; i <= n; i++)
            {
                bit.update(i, 1);
            }

            for (int i = 0; i < n; i++)
            {
                Node node = new Node(heights[i], infronts[i]);
                nodes.Add(node);
                order.Add(0);
            }

            nodes.Sort();


        for (int i = 0; i < n; i++)
            {
                Node node = nodes[i];
                int index = getIth(bit, node.infronts + 1, n);
                // order.set(index, node.height);
                order[index] = node.height;
            }

            return order;

        }

        public int getIth(Bit bit, int index, int n)
        {
            int start = 1;
            int end = n;
            int count = end - start + 1;
            int it;
            int res = 0;

            while (count > 0)
            {

                int mid = (start + end) / 2;
                int val = bit.query(mid);

                if (val < index)
                {
                    start = mid + 1;
                }
                else if (val > index)
                {
                    end = mid - 1;
                }
                else if (val == index)
                {
                    res = mid;
                    end = mid - 1;
                }

                count /= 2;

            }

            bit.update(res, -1);

            return res - 1;
        }

        public List<int> CreateSegementArray(List<int> input)
        {
            int n = input.Count;
            this.inputArray = input;
            SegmentArray = Enumerable.Repeat<int>(-1, this.getSegmentTreeLength(n)).ToList();
            this.SegmentArrayUtil(SegmentArray,  0, n-1, input, 0);
            return SegmentArray;
        }

        public int FindSum(int s, int e)
        {
            return this.FindSumUtil(0, inputArray.Count-1, 0, s, e);
        }

        // if s and e are in perfect range for rangestart and range end then sum is the segement
        public int FindSumUtil(int rangeStart, int rangeEnd, int si, int s , int e)
        {
            int sum = 0;
            if(rangeStart >= s && rangeEnd <= e)
            {
                sum += this.SegmentArray[si];
                return sum;
            }
            // range is outside
            else if(e < rangeStart || s > rangeEnd)
            {
                return sum;
                
            }
            else
            {

                int mid = rangeStart + (rangeEnd - rangeStart) / 2;

                // go to left tree
                sum += this.FindSumUtil(rangeStart, mid, 2 * si + 1, s, e);

                // go to right tree
                sum += this.FindSumUtil(mid+1, rangeEnd, 2 * si + 2, s, e);
            }


            return sum;

        }

        public int GetSum(int s, int e)
        {
            return 0;
        }


        private void SegmentArrayUtil(List<int> segmentArray, int startIndex, int endIndex, List<int> input, int segmentArrayIndex)
        {   
            if(startIndex < endIndex)
            {
                int mid = startIndex + ((endIndex - startIndex) / 2);
                SegmentArrayUtil(segmentArray, startIndex, mid, input, segmentArrayIndex * 2 + 1);
                SegmentArrayUtil(segmentArray, mid+1, endIndex, input, segmentArrayIndex * 2 + 2);
                segmentArray[segmentArrayIndex] = segmentArray[segmentArrayIndex * 2 + 1] + segmentArray[segmentArrayIndex * 2 + 2];

            }
            else if(startIndex == endIndex )
            {
                segmentArray[segmentArrayIndex] = input[startIndex];
            }
        }

        int getSegmentTreeLength(int totalCount)
        {
            double height = Math.Ceiling(Math.Log(totalCount, 2));
            double innerNodes = Math.Pow(2, height) - 1;
            return (int)innerNodes + totalCount;
        }
    }

    class Node :IComparable<Node>{

        public int height;
        public int infronts;

        public Node(int h, int i)
        {
            height = h;
            infronts = i;
        }


        public int CompareTo(Node other)
        {
                return this.height > other.height ? 1 : -1;
        }
    }


    class Bit
    {

        int[] bit;
        int N;

        public Bit(int N)
        {
            this.bit = new int[N + 10];
            this.N = N;
        }

        public void update(int idx, int value)
        {

            while (idx > 0 && idx <= N)
            {
                bit[idx] += value;
                idx += (idx & -idx);
            }

        }

        public int query(int idx)
        {

            int res = 0;

            while (idx > 0)
            {
                res += bit[idx];
                idx -= (idx & -idx);
            }

            return res;
        }
    }
}
