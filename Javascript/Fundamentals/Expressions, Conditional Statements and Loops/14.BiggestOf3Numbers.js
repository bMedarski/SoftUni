function Solve(nums){

    if(nums[0]>=nums[1]&&nums[0]>=nums[2]){
        return nums[0];
    }
    if(nums[1]>=nums[0]&&nums[1]>=nums[2]){
        return nums[1];
    }
    return nums[2];
}