namespace Merge_sort_algorithm
{
    public class Program
    {
        static void MergeArray(int[] arr, int left, int middel, int right)
        {
            //get left and righ arrays lenths
            int leftArrayLength = middel - left + 1;
            int rightArrayLength = right - middel;

            //create new left and right temp arrays
            int[] leftTempArray = new int[leftArrayLength];
            int[] rightTempArray = new int[rightArrayLength];

            //fill left and right temp arrays
            for (int i = 0; i < leftArrayLength; i++)
            {
                leftTempArray[i] = arr[left + i];
            }
            for (int i = 0; i < rightArrayLength; i++)
            {
                rightTempArray[i] = arr[middel + 1 + i];
            }

            int leftArrayPointer = 0; 
            int rightArrayPointer = 0;
            int k = left;

            //merge two temp arrays based on comparison
            while (leftArrayPointer < leftArrayLength && rightArrayPointer < rightArrayLength)
            {
                if (leftTempArray[leftArrayPointer] <= rightTempArray[rightArrayPointer])
                {
                    arr[k] = leftTempArray[leftArrayPointer];
                    k++;
                    leftArrayPointer++;
                }
                else
                {
                    arr[k] = rightTempArray[rightArrayPointer];
                    k++;
                    rightArrayPointer++;
                }
            }

            //if there are any elements last in the left or right array
            while (leftArrayPointer < leftArrayLength)
            {
                arr[k] = leftTempArray[leftArrayPointer];
                k++;
                leftArrayPointer++;
            }
            while (rightArrayPointer < rightArrayLength)
            {
                arr[k] = rightTempArray[rightArrayPointer];
                k++;
                rightArrayPointer++;
            }
        }

        static int[] SortArray(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                SortArray(arr, left, middle);
                SortArray(arr, middle + 1, right);

                MergeArray(arr, left, middle, right);
            }
            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] {2,1,5};

            int[] result = SortArray(arr, 0, arr.Length-1);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}