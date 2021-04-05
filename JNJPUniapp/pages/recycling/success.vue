<template>
	<view class="padding-lr">
		<view class="solids-bottom padding-xs flex align-center">
			<view class="flex-sub text-center">
				<view class="solid-bottom text-xsl padding">
					<text class="cuIcon-roundcheckfill text-green"></text>
				</view>
				<view class="text-xl margin-tb-xs">回收成功，获得30积分</view>
			</view>
		</view>
		<view class="padding flex flex-direction">
			<button class="cu-btn bg-blue lg" @click="toIndex()">返回首页</button>
			<button class="cu-btn bg-olive lg margin-top-sm" @click="toProfile()">查看积分</button>
		</view>
	</view>
</template>

<script>
	export default {
		methods: {
			toIndex() {
				uni.reLaunch({
					url: '../index/index'
				})
			},
			toProfile() {
				uni.reLaunch({
					url: '../profile/profile'
				})
			}
		}
	}
</script>

<style>
</style>
