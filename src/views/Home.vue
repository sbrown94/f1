<template>
  <div class="home">
    <CurrentRace />
      <div class="options-container">
        <div class="options">
          <div v-on:click="switchTo('driver-standings')" class="option">Driver Standings</div>
          <div v-on:click="switchTo('constructor-standings')" class="option">Constructor Standings</div>
          <div v-on:click="switchTo('')" class="option">Driver Search</div>
        </div>
      </div>
      <DriverStandings v-if="displaying=='driver-standings'"/>
      <ConstructorStandings v-if="displaying=='constructor-standings'" />
  </div>
</template>

<script>
// @ is an alias to /src
import CurrentRace from '@/components/CurrentRace.vue'
import DriverStandings from '@/components/DriverStandings.vue'
import ConstructorStandings from '@/components/ConstructorStandings.vue'

export default {
  name: 'home',
  components: {
    CurrentRace,
    DriverStandings,
    ConstructorStandings
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

<style scoped>

.options-container {
  background-color: lightcoral;
  padding: 20px;
}

.options {
  display: flex;
  justify-content: space-between;
  max-width: 800px;
  margin: 0 auto;
}

.option {
  background-color: pink;
  cursor: pointer;
  padding: 25px;
  box-shadow: 5px 5px black;
}

.option:hover {
  background-color: red;
  color: white;
}
</style>
