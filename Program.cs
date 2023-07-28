// C#
int[] sampleData = { 9, 1, 3, 2, 3, 6, 4 };
Sort sorter = new Sort();

sorter.MergeSort(0, sampleData.Length - 1, sampleData);
for (int i = 0; i < sampleData.Length; i++)
{
    Console.WriteLine(sampleData[i] + "  ");
}





public class Sort
{
    readonly Extras extras = new Extras();

    public void MergeSort(int l, int h, int[] arr)
    {
        if (l >= h)
        {
            return;
        }
        int mid = (h + l) / 2;
        int[] leftSubArray = extras.TrimArr(l, mid, arr);
        int[] rightSubArray = extras.TrimArr(mid , arr.Length, arr);

        MergeSort(l, mid, leftSubArray); //first half
        MergeSort(h, mid, rightSubArray); //second half

        Merge(l, h, mid, arr);
    }

    private void Merge(int l, int h, int mid, int[] arr)
    {
        int leftSide = mid - l + 1;
        int rightSide = h - mid;

        int[] tempLeft = new int[leftSide];
        int[] tempRight = new int[rightSide];

        for (int i = 0; i < leftSide; i++)
        {
            tempLeft[i] = arr[l + i];
        }
        for (int j = 0; j < rightSide; j++)
        {
            tempRight[j] = arr[mid + j];
        }

        int leftIndex = 0, rightIndex = 0;
        int currentIndex = l; // start at the lowest

        while (leftIndex < leftSide)
        {
            arr[currentIndex] = tempLeft[leftIndex];
            leftIndex++;
            currentIndex++;
        }
        while (rightIndex < rightSide)
        {
            arr[(currentIndex)] = tempRight[rightIndex];
            rightIndex++;
            currentIndex++;
        }
    }
    

}

public class Extras
{
    public int[] TrimArr(int initIndex , int length, int[] arr)
    {
        int[] response = new int[length - initIndex];

        for (int i = 0; i < (length - initIndex); i++)
        {
            response[i] = arr[i + initIndex];
        }
        return response;
    }
}

