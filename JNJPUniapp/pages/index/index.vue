<template>
	<view>
		<view class="bg-white padding-lr padding-tb-sm" style="height: 80upx;">
			<text class="">请选择化妆品种类以进行回收。</text>
		</view>
		<view class="solids-top">
			<view class="cu-list grid col-3 no-border">
				<view @click="toRecycle()" class="cu-item" v-for="(item,index) in categoryList" :key="index">
					<view :class="['cuIcon-' + item.icon,'text-' + item.color]"></view>
					<text>{{item.name}}</text>
				</view>
			</view>
		</view>
		<bottom-bar :selection="1"></bottom-bar>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				categoryList:[
					{
						name: "膏霜乳液类",
						icon: "info",
						color: "maven"
					},
					{
						name: "化妆品分类",
						icon: "info",
						color: "blue"
					},
					{
						name: "化妆品分类",
						icon: "info",
						color: "blue"
					},
					{
						name: "化妆品分类",
						icon: "info",
						color: "blue"
					},
					{
						name: "化妆品分类",
						icon: "info",
						color: "blue"
					},
					{
						name: "帮我决定",
						icon: "question",
						color: "orange"
					}
				]
			};
		},
		methods: {
			toRecycle() {
				uni.navigateTo({
					url: '../recycling/confirm'
				})
			}
		}
	}
</script>

<style>

</style>
