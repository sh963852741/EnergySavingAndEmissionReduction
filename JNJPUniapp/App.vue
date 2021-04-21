<script>
	export default {
		onLaunch: function() {

		},
		onShow: function() {
			// #ifndef H5
			uni.getUserInfo({
				success: (res) => {
					let userInfo = res.userInfo;
					uni.login({
						success: (res) => {
							uni.post("/api/security/WeChatLogin",{code: res.code, name: userInfo.nickName}, msg => {
								console.log(msg)
							})
						},
						fail: (err) => {
							console.error(err)
						}
					})
				}
			})
			
			// #endif
			
		},
		onHide: function() {

		}
	}
</script>

<style>
	/*每个页面公共css */
	@import "colorui/main.css";
	@import "colorui/icon.css";
	@import "colorui/animation.css";
</style>
