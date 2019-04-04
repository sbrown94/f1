<template>
  <div class="home">
    <CurrentRace />
    <DriverStandings v-if="displaying=='driver-standings'"/>
        <div class="options">
          <div v-on:click="switchTo('driver-standings')" class="option">Driver Standings</div>
          <div v-on:click="switchTo('constructor-standings')" class="option">Constructor Standings</div>
          <div v-on:click="switchTo('')" class="option">Driver Search</div>
        </div>
  </div>
</template>

<script>
// @ is an alias to /src
import CurrentRace from '@/components/CurrentRace.vue'
import DriverStandings from '@/components/DriverStandings.vue'

export default {
  name: 'home',
  components: {
    CurrentRace,
    DriverStandings
  },
  data: function() {
      return {
          displaying: ''
      }
  },
  methods: {
    switchTo(option) {
      console.log("change display");
      this.displaying = option;
    }
  }
}
</script>
