import Vue from 'vue'
import App from './App.vue'
import router from './router'

import VueResource from 'vue-resource'
Vue.use(VueResource)

import moment from 'moment'
Vue.prototype.moment = moment

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
