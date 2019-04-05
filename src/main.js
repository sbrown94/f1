import Vue from 'vue'
import App from './App.vue'
import router from './router'

import VueResource from 'vue-resource'
Vue.use(VueResource)

import moment from 'moment'
Vue.prototype.moment = moment

Vue.config.productionTip = false

Vue.prototype.teamColors = {
  'Mercedes': '#00D2BE',
  'Ferrari': '#DC0000',
  'Red Bull Racing': '#1E41FF',
  'Renault': '#FFF500',
  'Haas': '#F0D787',
  'Racing Point': '#F596C8',
  'Toro Rosso': '#469BFF',
  'McLaren': '#FF8700',
  'Alfa Romeo Racing': '#9B0000',
  'Williams': '#FFFFFF'
}

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
