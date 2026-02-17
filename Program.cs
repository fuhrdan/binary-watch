//*****************************************************************************
//** 401 Binary Watch                                               leetcode **
//*****************************************************************************
//** Four lights for hours, six for minutes bright,
//** We count each glowing bit that sparks the night.
//** From zero through eleven, fifty-nine we scan,
//** And print each valid time in careful C we plan.
//*****************************************************************************

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
static int countBits(int x)
{
    int count = 0;

    while (x > 0)
    {
        count += (x & 1);
        x >>= 1;
    }

    return count;
}

char** readBinaryWatch(int turnedOn, int* returnSize)
{
    int capacity = 720;
    char** result = (char**)malloc(sizeof(char*) * capacity);
    int count = 0;

    for (int h = 0; h < 12; h++)
    {
        for (int m = 0; m < 60; m++)
        {
            if (countBits(h) + countBits(m) == turnedOn)
            {
                result[count] = (char*)malloc(sizeof(char) * 6);
                sprintf(result[count], "%d:%02d", h, m);
                count++;
            }
        }
    }

    *returnSize = count;
    return result;
}