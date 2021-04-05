<template>
	<view style="height: 100upx;">
		<view class="cu-bar tabbar bg-white foot">
			<view class="action" :key="index" @click="toUrl(menu.to)" :class="{'text-green': selection === index + 1}"
				v-for="(menu, index) in menus">
				<view :class="menu.icon">
				</view>
				<view class="">{{menu.text}}</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		props: {
			selection: {
				required: true,
				type: Number
			}
		},
		data() {
			return {
				menus: [{
						icon: 'cuIcon-deliver',
						text: '分类回收',
						to: '/pages/index/index'
					},
					{
						icon: 'cuIcon-newshot',
						text: '通知公告',
						to: '/pages/article/list'
					},
					{
						icon: 'cuIcon-my',
						text: '我的信息',
						to: '/pages/profile/profile'
					},
				]
			}
		},
		methods: {
			toUrl(url) {
				uni.reLaunch({
					url
				})
			}
		}
	}
</script>

<style>

</style>
