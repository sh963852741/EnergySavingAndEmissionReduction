import Vue from 'vue'
import App from './App'

import BottomBar from './components/bottombar.vue'
Vue.component('bottom-bar',BottomBar)

Vue.config.productionTip = false

App.mpType = 'app'

const app = new Vue({
    ...App
})
app.$mount()
