<template>
	<view>
		<form>
			<view class="cu-form-group">
				<view class="title">化妆品分类</view>
				<input value="膏霜乳液类"></input>
			</view>
			<view class="cu-form-group">
				<view class="title">化妆品重量</view>
				<input value="300克"></input>
			</view>
			<view class="cu-form-group">
				<view class="title">用户姓名</view>
				<input value="张三"></input>
			</view>
			<view class="cu-form-group">
				<view class="title">预期积分</view>
				<input value="30分"></input>
			</view>
			<view class="cu-form-group">
				<view class="title">回收方式</view>
				<input value="吃掉"></input>
			</view>
		</form>
		<view class="padding flex flex-direction">
			<button class="cu-btn bg-gradual-blue lg" @click="recycle">回收它！！！</button>
			<button class="cu-btn bg-cyan light lg margin-top-sm">我再想想</button>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				formData: {
					category: "膏霜乳液类"
				}
			}
		},
		onLoad() {
			uni.showModal({
				title: "开始回收",
				content: "请将化妆品放入回收箱。",
				showCancel: false
			})
		},
		methods: {
			recycle() {
				uni.redirectTo({
					url: './success'
				})
			}
		}
	}
</script>

<style>
</style>
