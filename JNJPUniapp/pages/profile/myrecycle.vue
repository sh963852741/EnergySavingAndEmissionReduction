<template>
	<view>
		<view class="margin">
			<text class="text-lg">总积分：</text>
			<text class="text-lg text-green">5分</text>
		</view>
		<view>
			<text class="margin-lr">积分明细：</text>
		</view>
		<view class="margin-lr cu-list grid col-3">
			<view class="cu-item">物品</view>
			<view class="cu-item">时间</view>
			<view class="cu-item">积分</view>
		</view>
		<view class="margin-lr cu-list grid col-3" style="margin-top: 0px;"
		v-for="(item,index) in recycleList" :key="index">
			<view class="cu-item">{{item.item}}</view>
			<view class="cu-item">{{item.time}}</view>
			<view class="cu-item">{{item.credit}}</view>
		</view>
	</view>
</template>

<script>
	export default{
		data() {
			return {
				recycleList:[
					{
						'item': '化妆水',
						'time': '2020-5-9',
						'credit': +5
					},
					{
						'item': '护手霜',
						'time': '2021-5-9',
						'credit': '待定'
					}
				]
			}
		}
	}
</script>

<style>
</style>
