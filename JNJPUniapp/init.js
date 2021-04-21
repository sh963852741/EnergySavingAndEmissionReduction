let app = require("@/config");

uni.get = (url, params, callback) => {
	uni.request({
		url: app.domain + url,
		data: {
			...params
		},
		success(res) {
			if (typeof callback === 'function') {
				callback(res.data);
			}
		}
	})
}

uni.post = (url, params, callback) => {
	uni.request({
		url: app.domain + url,
		method: "POST",
		data: {
			...params
		},
		sslVerify: false,
		success(res) {
			if (typeof callback === 'function') {
				callback(res.data);
			}
		}
	})
}

uni.get = (url, params, callback) => {
	uni.request({
		url: app.domain + url,
		method: "GET",
		data: {
			...params
		},
		sslVerify: false,
		success(res) {
			if (typeof callback === 'function') {
				callback(res.data);
			}
		}
	})
}
