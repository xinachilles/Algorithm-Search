using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class Serarch
    {

        public int BinarySearch(int[] data, int item)
        {

            int min = 0;
            int N = data.Length;
            int max = N - 1;
            do
            {
                int mid = (min + max) / 2;

                if (item > data[mid])
                    min = mid + 1;
                else
                    max = mid - 1;
                if (data[mid] == item)
                    return mid;

            } while (min <= max);
            return -1;
        }

        #region 9.3

        //A magic index in an array A[l.. .n-l] is defined to be an index such that A[i] =i. Given a sorted array of

        public int BinarySearchMagicIndex(int[] data)
        {
            int min = 0;
            int max = data.Length - 1;
            int mid = 0;
            while (min <= max)
            {

                mid = (min + max) / 2;
                if (data[mid] == mid)
                {
                    return mid;

                }
                else if (data[mid] > mid)
                {
                    mid = (min + (mid - 1)) / 2;


                }
                else
                {

                    mid = ((mid + 1) + max) / 2;
                }



            }

            return -1;
        }


        public int BinarySearchMagicIndexRecursion(int[] data, int end, int start)
        {
            if (end < start || start < 0 || end >= data.Length) { return -1; }
            int mid = (end + start) / 2;
            if (data[mid] == mid) { return mid; }
            else if (data[mid] < mid) { return BinarySearchMagicIndexRecursion(data, mid - 1, start); }
            else
            {
                return BinarySearchMagicIndexRecursion(data, end, start + 1);

            }

        }

        #endregion

        #region 11.3
        //Given a sorted array of n integers that has been rotated an unknown number of
        //times, write code to find an element in the array. You may assume that the array was
        //originally sorted in increasing order.


        public int RotatedBinarySearch(int[] data, int x, int left, int right)
        {
            int mid = (left + right) / 2;
            if (data[mid] == x)
            {
                return x;
            }

            if (data[left] < data[mid])
            {
                // left is normal order
                if (x < data[mid] && x >= data[left])
                {
                    return RotatedBinarySearch(data, x, left, mid - 1);

                }
                else
                {
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }

            } // end left noraml 

            else if (data[left] > data[mid])
            {
                // right is normal order
                if (x > data[mid] && x <= data[right])
                {
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }
                else
                {
                    return RotatedBinarySearch(data, x, left, mid - 1);
                }

            } // end right normal

            else if (data[left] == data[mid])
            {
                // left half is repeat 

                if (data[right] != data[mid])
                {
                    // search the right part 
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }
                else
                {
                    // search the both part 

                    int result = RotatedBinarySearch(data, x, left, mid - 1);
                    if (result == -1) { return RotatedBinarySearch(data, x, mid + 1, right); }
                    else { return result; }

                }
            }


            return -1;
        }
        #endregion

        #region 11.5
        //11.5 Given a sorted array of strings which is interspersed with empty strings, write a
        //method to find the location of a given string.

        public int StringR(string[] strings, string str, int first, int last)
        {
            if (first > last)
            {
                return -1;

            }

            int mid = (first + last) / 2;
            if (strings[mid] == null)
            {

                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {

                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && strings[right] != null)
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && strings[left] != null)
                    {
                        mid = left;
                        break;
                    }

                    left = left - 1;
                    right = right + 1;

                }
            }

            if (strings[mid].Equals(str))
            {
                return mid;
            }
            else if (strings[mid].CompareTo(str) < 0)
            {// go to right 
                return StringR(strings, str, mid + 1, last);
            }
            else
            {
                return StringR(strings, str, first, mid - 1);
            }






        }// end class




        #endregion

        #region 11.6
        //Given an MX N matrix in which each row and each column is sorted in ascending
        //order, write a method to find an element.
        //start with [0, n]
        public bool FindFlement(int[][] matrix, int elem)
        {
            int row = 0;
            int col = matrix[0].Length - 1;
            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == elem)
                {
                    return true;
                }
                else if (matrix[row][col] > elem)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }

        #endregion
    }
}
