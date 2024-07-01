public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int counter = 0;

        for (int i = 0; i < arr.Length; i++){

            if (arr[i] %2==0) {
                counter = 0;
            }

            else {
                counter ++;
            }

            if (counter == 3){
                return true;
            }

        }
        return false;
    }
}