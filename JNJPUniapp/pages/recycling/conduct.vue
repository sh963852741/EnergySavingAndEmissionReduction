<template>
	<view>
		<form>
			<view class="cu-form-group">
				<view class="title">化妆品分类</view>
				<picker mode="multiSelector" @change="handleChange" @columnchange="handleColumnChange" range-key="name" :value="categoryIndex" :range="categoryArray">
					<view class="picker">
						{{categoryIndex[0] > -1 ? categoryArray[0][categoryIndex[0]].name : '请选择'}} >> 
						{{categoryIndex[1] > -1 ?categoryArray[1][categoryIndex[1]].name : '请选择'}}
					</view>
				</picker>
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
				categoryIndex: [-1, -1],
				formData: {
					category: "膏霜乳液类"
				},
				categoryArray: [[],[]],
				source: [[],[]]
			}
		},
		onLoad() {
			uni.get('/api/category/GetCategory', {},msg => {
				if(msg.success){
					this.source = JSON.parse(JSON.stringify(msg.data));
					for(let category of msg.data){
						for(let s of category.subCategories){
							this.categoryArray[1].push(s);
							}
						delete category.subCategories;
						this.categoryArray[0].push(category);
					}
				}
			})
			uni.showModal({
				title: "开始回收",
				content: "请将化妆品放入回收箱。",
				showCancel: false
			})
		},
		methods: {
			handleChange(e) {
				this.categoryIndex = e.detail.value
			},
			handleColumnChange(e) {
				if(e.detail.column === 0){
					this.categoryArray[1] = this.source[e.detail.value].subCategories;
				}
			},
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
