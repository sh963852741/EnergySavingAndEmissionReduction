<template>
	<view>
		<view class="flex">
			<view class="head flex align-center justify-center" :style="{'background-image':'url(' + bgImg + ')'}">
				<view>
					<view class="cu-avatar xl round" :style="{'background-image':'url(' + userAvatar + ')'}"></view>
					<view class="text-xxl margin-top-xs">宋润涵</view>
				</view>
			</view>
		</view>
		<view class="bg-white flex text-center justify-around padding-tb radius shadow-warp vertical-divider">
			<view class="text-block">
				<view class="text-xxl text-mauve">12</view>
				<view>化妆品</view>
			</view>
			<view class="text-block">
				<view class="text-xxl text-olive">215</view>
				<view>积分</view>
			</view>
		</view>
		<view class="cu-list menu card-menu margin-top-xl">
			<view class="cu-item arrow">
				<view class="content">
					<text class="cuIcon-refresh text-green"></text>
					<text class="text-grey">我的回收</text>
				</view>
			</view>
			<view class="cu-item arrow">
				<view class="content">
					<text class="cuIcon-info text-grey"></text>
					<text class="text-grey">关于</text>
				</view>
			</view>
		</view>
		<bottom-bar :selection="3"></bottom-bar>
	</view>
</template>

<script>
	const bgImg = require('@/static/profile-summer.jpeg')
	const userAvatar = require('@/static/logo.png')
	export default {
		data() {
			return {
				userAvatar,
				bgImg
			} 
		}
	}
</script>

<style>
	.vertical-divider > .text-block + .text-block{
		border-left: #e7ebed solid 2upx;
	}
	.vertical-divider >.text-block{
		width: 100%;
	}
	
	.head {
		height: 486rpx;
		width: 100%;
		background-repeat: no-repeat;
		background-size: cover;
		background-position: center;
		/* filter: blur(8px); */
	}
</style>
