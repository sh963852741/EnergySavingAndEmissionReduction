<template>
	<view>
		<view class="padding text-center">
			<view class="text-lg">您选择的化妆品类别是：</view>
			<view class="text-sl text-orange margin-tb-xs">膏霜乳液类</view>
			<view class="">
				<text>
					膏霜乳液类化妆品是一种乳化体，即由油、脂、蜡等多种原料混合而成的一种物系。乳化是一种液体以极微小液滴均匀地分散在互不相溶的另一种液体中的作用。乳化即加入适当的表面活性剂在强烈的搅拌下，油被分散在水中，形成乳状液。破乳是指乳状液完全破坏，成为不相混溶的两相。
				</text>
			</view>
		</view>
		<view class="padding flex flex-direction">
			<button class="cu-btn lg bg-gradual-green" @click="toRecycle">开始回收</button>
		</view>
	</view>
</template>

<script>
	export default{
		data() {
			return {
				
			}
		},
		methods: {
			toRecycle(){
				uni.redirectTo({
					url:'./conduct'
				})
			}
		}
	}
</script>

<style>
</style>
